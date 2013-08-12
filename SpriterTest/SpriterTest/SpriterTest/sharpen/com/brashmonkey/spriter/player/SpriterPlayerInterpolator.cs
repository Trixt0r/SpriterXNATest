/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.player
{
	/// <summary>This class is made to interpolate between two running animations.</summary>
	/// <remarks>
	/// This class is made to interpolate between two running animations.
	/// The idea is, to give an instance of this class two AbstractSpriterPlayer objects which hold and animate the same spriter entity.
	/// This will interpolate the runtime transformations of the bones and objects with a weight between 0 and 1.
	/// You will be also able to interpolate SpriterPlayerInterpolators with each other, since it extends  #SpriterAbstractPlayer.
	/// Note that this #SpriterAbstractPlayer needs 3 times more calculation effort than a normal #SpriterPlayer.
	/// </remarks>
	/// <author>Trixt0r</author>
	public class SpriterPlayerInterpolator : com.brashmonkey.spriter.player.SpriterAbstractPlayer
	{
		private com.brashmonkey.spriter.player.SpriterAbstractPlayer first;

		private com.brashmonkey.spriter.player.SpriterAbstractPlayer second;

		private float weight;

		private bool interpolateSpeed = false;

		/// <summary>Returns an instance of this class, which will manage the interpolation between two #SpriterAbstractPlayer instances.
		/// 	</summary>
		/// <remarks>Returns an instance of this class, which will manage the interpolation between two #SpriterAbstractPlayer instances.
		/// 	</remarks>
		/// <param name="first">player to interpolate with the second one.</param>
		/// <param name="second">player to interpolate with the first one.</param>
		public SpriterPlayerInterpolator(com.brashmonkey.spriter.player.SpriterAbstractPlayer
			 first, com.brashmonkey.spriter.player.SpriterAbstractPlayer second) : base(first
			.loader, first.animations)
		{
			this.weight = 0.5f;
			setPlayers(first, second);
			this.generateData();
			this.update(0, 0);
		}

		/// <summary>Note: Make sure, that both instances hold the same bone and object structure.
		/// 	</summary>
		/// <remarks>
		/// Note: Make sure, that both instances hold the same bone and object structure.
		/// Otherwise you will not get the interpolation you wish.
		/// </remarks>
		/// <param name="first">SpriterPlayer instance to interpolate.</param>
		/// <param name="second">SpriterPlayer instance to interpolate.</param>
		public virtual void setPlayers(com.brashmonkey.spriter.player.SpriterAbstractPlayer
			 first, com.brashmonkey.spriter.player.SpriterAbstractPlayer second)
		{
			this.first = first;
			this.second = second;
			this.moddedBones = this.first.moddedBones;
			this.moddedObjects = this.first.moddedObjects;
			this.first.setRootParent(this.rootParent);
			this.second.setRootParent(this.rootParent);
		}

		/// <param name="weight">
		/// to set. 0 means the animation of the first player will get played back.
		/// 1 means the second player will get played back.
		/// </param>
		public virtual void setWeight(float weight)
		{
			this.weight = weight;
		}

		/// <returns>The current weight.</returns>
		public virtual float getWeight()
		{
			return this.weight;
		}

		/// <returns>The first player.</returns>
		public virtual com.brashmonkey.spriter.player.SpriterAbstractPlayer getFirst()
		{
			return this.first;
		}

		/// <returns>The second player.</returns>
		public virtual com.brashmonkey.spriter.player.SpriterAbstractPlayer getSecond()
		{
			return this.second;
		}

		protected internal override void step(float xOffset, float yOffset)
		{
			int firstLastSpeed = first.frameSpeed;
			int secondLastSpeed = second.frameSpeed;
			int speed = this.frameSpeed;
			if (this.interpolateSpeed)
			{
				speed = (int)this.interpolate(first.frameSpeed, second.frameSpeed, 0, 1, this.weight
					);
			}
			this.first.frameSpeed = speed;
			this.second.frameSpeed = speed;
			this.moddedBones = (this.weight <= 0.5f) ? this.first.moddedBones : this.second.moddedBones;
			this.moddedObjects = (this.weight <= 0.5f) ? this.first.moddedObjects : this.second
				.moddedObjects;
			if (this.weight == 0)
			{
				this.first.update(xOffset, yOffset);
				this.instructions = this.first.instructions;
				this.currenObjectsToDraw = first.currenObjectsToDraw;
				this.currentBonesToAnimate = first.currentBonesToAnimate;
			}
			else
			{
				if (this.weight == 1)
				{
					this.second.update(xOffset, yOffset);
					this.instructions = this.second.instructions;
					this.currenObjectsToDraw = second.currenObjectsToDraw;
					this.currentBonesToAnimate = second.currentBonesToAnimate;
				}
				else
				{
					this.currenObjectsToDraw = System.Math.Min(first.currenObjectsToDraw, second.currenObjectsToDraw);
					this.currentBonesToAnimate = System.Math.Min(first.currentBonesToAnimate, second.
						currentBonesToAnimate);
					this.first.update(xOffset, yOffset);
					this.second.update(xOffset, yOffset);
					com.brashmonkey.spriter.animation.SpriterKeyFrame key1 = (first.transitionFixed) ? 
						first.lastFrame : first.lastTempFrame;
					com.brashmonkey.spriter.animation.SpriterKeyFrame key2 = (second.transitionFixed)
						 ? second.lastFrame : second.lastTempFrame;
					this.transformBones(key1, key2, xOffset, yOffset);
					this.transformObjects(key1, key2, xOffset, yOffset);
				}
			}
			this.first.frameSpeed = firstLastSpeed;
			this.second.frameSpeed = secondLastSpeed;
		}

		protected internal override void setInstructionRef(com.brashmonkey.spriter.draw.DrawInstruction
			 dI, com.brashmonkey.spriter.objects.SpriterObject obj1, com.brashmonkey.spriter.objects.SpriterObject
			 obj2)
		{
			dI.@ref = (this.weight <= 0.5f || obj2 == null) ? obj1.getRef() : obj2.getRef();
			//dI.loader = (this.weight <= 0.5f || obj2 == null) ? obj1.getLoader() : obj2.getLoader	();
			dI.obj = (this.weight <= 0.5f || obj2 == null) ? obj1 : obj2;
		}

		/// <summary>
		/// See
		/// <see cref="com.brashmonkey.spriter.SpriterCalculator.calculateInterpolation(float, float, float, float, float)
		/// 	">com.brashmonkey.spriter.SpriterCalculator.calculateInterpolation(float, float, float, float, float)
		/// 	</see>
		/// Can be inherited, to handle other interpolation techniques. Standard is linear interpolation.
		/// </summary>
		protected internal override float interpolate(float a, float b, float timeA, float
			 timeB, float currentTime)
		{
			return this.interpolator.interpolate(a, b, 0, 1, this.weight);
		}

		/// <summary>
		/// See
		/// <see cref="com.brashmonkey.spriter.SpriterCalculator.calculateInterpolation(float, float, float, float, float)
		/// 	">com.brashmonkey.spriter.SpriterCalculator.calculateInterpolation(float, float, float, float, float)
		/// 	</see>
		/// Can be inherited, to handle other interpolation techniques. Standard is linear interpolation.
		/// </summary>
		protected internal override float interpolateAngle(float a, float b, float timeA, 
			float timeB, float currentTime)
		{
			return this.interpolator.interpolateAngle(a, b, 0, 1, this.weight);
		}

		/// <returns>true if this player also interpolates the speed of both players. false if not.
		/// 	</returns>
		public virtual bool interpolatesSpeed()
		{
			return this.interpolateSpeed;
		}

		/// <param name="inter">
		/// indicates whether this player has to interpolate the speed of bother players or not.
		/// If it set to false, this player will set for both players the speed which this player has. See
		/// <see cref="SpriterAbstractPlayer.setFrameSpeed(int)">SpriterAbstractPlayer.setFrameSpeed(int)
		/// 	</see>
		/// </param>
		public virtual void setInterpolateSpeed(bool inter)
		{
			this.interpolateSpeed = inter;
		}

		public override com.brashmonkey.spriter.objects.SpriterBone[] getRuntimeBones()
		{
			if (this.weight == 0)
			{
				return this.first.getRuntimeBones();
			}
			else
			{
				if (this.weight == 1)
				{
					return this.second.getRuntimeBones();
				}
				else
				{
					return this.tempBones;
				}
			}
		}

		public override com.brashmonkey.spriter.objects.SpriterObject[] getRuntimeObjects
			()
		{
			if (this.weight == 0)
			{
				return this.first.getRuntimeObjects();
			}
			else
			{
				if (this.weight == 1)
				{
					return this.second.getRuntimeObjects();
				}
				else
				{
					return this.tempObjects;
				}
			}
		}

		public override com.brashmonkey.spriter.SpriterRectangle getBoundingBox()
		{
			if (this.weight == 0)
			{
				return this.first.getBoundingBox();
			}
			else
			{
				if (this.weight == 1)
				{
					return this.second.getBoundingBox();
				}
				else
				{
					return this.rect;
				}
			}
		}

		public override void calcBoundingBox(com.brashmonkey.spriter.objects.SpriterBone 
			parent)
		{
			if (this.weight == 0)
			{
				this.first.calcBoundingBox(parent);
			}
			else
			{
				if (this.weight == 1)
				{
					this.second.calcBoundingBox(parent);
				}
				else
				{
					base.calcBoundingBox(parent);
				}
			}
		}
	}
}
