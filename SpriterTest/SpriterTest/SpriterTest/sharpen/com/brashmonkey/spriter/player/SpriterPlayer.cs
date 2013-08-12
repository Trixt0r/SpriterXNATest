/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.player
{
	/// <summary>A SpriterPlayer is the core of a spriter animation.</summary>
	/// <remarks>
	/// A SpriterPlayer is the core of a spriter animation.
	/// Here you can get as many information as you need.
	/// SpriterPlayer plays the given data with the method
	/// <see cref="SpriterAbstractPlayer.update(float, float)">SpriterAbstractPlayer.update(float, float)
	/// 	</see>
	/// . You have to call this method by your own in your main game loop.
	/// SpriterPlayer updates the frames by its own. See
	/// <see cref="SpriterAbstractPlayer.setFrameSpeed(int)">SpriterAbstractPlayer.setFrameSpeed(int)
	/// 	</see>
	/// for setting the playback speed.
	/// The animations can be drawn by
	/// <see cref="#draw()">#draw()</see>
	/// which draws all objects with your own implemented Drawer.
	/// Accessing bones and animations via names is also possible. See
	/// <see cref="getAnimationIndexByName(string)">getAnimationIndexByName(string)</see>
	/// and
	/// <see cref="SpriterAbstractPlayer.getBoneIndexByName(string)">SpriterAbstractPlayer.getBoneIndexByName(string)
	/// 	</see>
	/// .
	/// You can modify the whole animation or only bones at runtime with some fancy methods provided by this class.
	/// Have a look at
	/// <see cref="SpriterAbstractPlayer.setAngle(float)">SpriterAbstractPlayer.setAngle(float)
	/// 	</see>
	/// ,
	/// <see cref="SpriterAbstractPlayer.flipX()">SpriterAbstractPlayer.flipX()</see>
	/// ,
	/// <see cref="SpriterAbstractPlayer.flipY()">SpriterAbstractPlayer.flipY()</see>
	/// ,
	/// <see cref="SpriterAbstractPlayer.setScale(float)">SpriterAbstractPlayer.setScale(float)
	/// 	</see>
	/// for animation moddification.
	/// And see
	/// <see cref="#setBoneAngle(int,float)">#setBoneAngle(int,float)</see>
	/// ,
	/// <see cref="#setBoneScaleX(int,float)">#setBoneScaleX(int,float)</see>
	/// ,
	/// <see cref="#setBoneScaleY(int,float)">#setBoneScaleY(int,float)</see>
	/// .
	/// All stuff you set you can also receive by the corresponding getters ;) .
	/// </remarks>
	/// <author>Trixt0r</author>
	public class SpriterPlayer : com.brashmonkey.spriter.player.SpriterAbstractPlayer
	{
		private static System.Collections.Generic.Dictionary<com.discobeard.spriter.dom.Entity
			, com.brashmonkey.spriter.player.SpriterPlayer> loaded = new System.Collections.Generic.Dictionary
			<com.discobeard.spriter.dom.Entity, com.brashmonkey.spriter.player.SpriterPlayer
			>();

		protected internal com.discobeard.spriter.dom.Entity entity;

		private com.brashmonkey.spriter.animation.SpriterAnimation animation;

		private int transitionSpeed = 30;

		private int animationIndex = 0;

		private int currentKey = 0;

		internal com.brashmonkey.spriter.animation.SpriterKeyFrame lastRealFrame;

		internal com.brashmonkey.spriter.animation.SpriterKeyFrame firstKeyFrame;

		internal com.brashmonkey.spriter.animation.SpriterKeyFrame secondKeyFrame;

		internal bool transitionTempFixed = true;

		private int fixCounter = 0;

		private int fixMaxSteps = 100;

		protected internal bool updateObjects = true;

		protected internal bool updateBones = true;

		/// <summary>Constructs a new SpriterPlayer object which animates the given Spriter entity.
		/// 	</summary>
		/// <remarks>Constructs a new SpriterPlayer object which animates the given Spriter entity.
		/// 	</remarks>
		/// <param name="data">
		/// 
		/// <see cref="com.discobeard.spriter.dom.SpriterData">com.discobeard.spriter.dom.SpriterData
		/// 	</see>
		/// which provides a method to load all needed data to animate. See
		/// <see cref="Spriter#getSpriter(String,com.spriter.file.FileLoader)">Spriter#getSpriter(String,com.spriter.file.FileLoader)
		/// 	</see>
		/// for mor information.
		/// </param>
		/// <param name="entityIndex">The entity which should be handled by this player.</param>
		/// <param name="loader">The loader which has loaded all necessary sprites for the scml file.
		/// 	</param>
		public SpriterPlayer(com.discobeard.spriter.dom.SpriterData data, com.discobeard.spriter.dom.Entity
			 entity, com.brashmonkey.spriter.file.FileLoader loader) : base(loader, null)
		{
			this.entity = entity;
			this.frame = 0;
			if (!alreadyLoaded(entity))
			{
				this.animations = com.brashmonkey.spriter.SpriterKeyFrameProvider.generateKeyFramePool
					(data, entity);
				loaded.Add(entity, this);
			}
			else
			{
				this.animations = loaded[entity].animations;
			}
			this.generateData();
			this.animation = this.animations[0];
			this.firstKeyFrame = this.animation.frames[0];
			this.update(0, 0);
		}

		/// <summary>Constructs a new SpriterPlayer object which animates the given Spriter entity.
		/// 	</summary>
		/// <remarks>Constructs a new SpriterPlayer object which animates the given Spriter entity.
		/// 	</remarks>
		/// <param name="data">
		/// 
		/// <see cref="com.discobeard.spriter.dom.SpriterData">com.discobeard.spriter.dom.SpriterData
		/// 	</see>
		/// which provides a method to load all needed data to animate. See
		/// <see cref="Spriter#getSpriter(String,com.spriter.file.FileLoader)">Spriter#getSpriter(String,com.spriter.file.FileLoader)
		/// 	</see>
		/// for mor information.
		/// </param>
		/// <param name="entityIndex">The index of the entity which should be handled by this player.
		/// 	</param>
		/// <param name="loader">The loader which has loaded all necessary sprites for the scml file.
		/// 	</param>
		public SpriterPlayer(com.discobeard.spriter.dom.SpriterData data, int entityIndex
			, com.brashmonkey.spriter.file.FileLoader loader) : this(data, data.getEntity
			()[entityIndex], loader)
		{
		}

		/// <summary>Constructs a new SpriterPlayer object which animates the given Spriter entity.
		/// 	</summary>
		/// <remarks>Constructs a new SpriterPlayer object which animates the given Spriter entity.
		/// 	</remarks>
		/// <param name="data">
		/// 
		/// <see cref="com.brashmonkey.spriter.Spriter">com.brashmonkey.spriter.Spriter</see>
		/// which provides a method to load all needed data to animate. See
		/// <see cref="Spriter#getSpriter(String,com.spriter.file.FileLoader)">Spriter#getSpriter(String,com.spriter.file.FileLoader)
		/// 	</see>
		/// for mor information.
		/// </param>
		/// <param name="entityIndex">The index of the entity which should be handled by this player.
		/// 	</param>
		/// <param name="loader">The loader which has loaded all necessary sprites for the scml file.
		/// 	</param>
		public SpriterPlayer(com.brashmonkey.spriter.Spriter spriter, int entityIndex, com.brashmonkey.spriter.file.FileLoader
            loader) : this(spriter.getSpriterData(), spriter.getSpriterData().getEntity
			()[entityIndex], loader)
		{
		}

		protected internal override void step(float xOffset, float yOffset)
		{
			//Fetch information
			//SpriterAnimation anim = this.animation;
			System.Collections.Generic.IList<com.brashmonkey.spriter.animation.SpriterKeyFrame
				> frameList = this.animation.frames;
			if (this.transitionFixed && this.transitionTempFixed)
			{
				//anim = this.animation;
				if (this.frameSpeed >= 0)
				{
					firstKeyFrame = frameList[this.currentKey];
					secondKeyFrame = frameList[(this.currentKey + 1) % frameList.Count];
				}
				else
				{
					secondKeyFrame = frameList[this.currentKey];
					firstKeyFrame = frameList[(this.currentKey + 1) % frameList.Count];
				}
				//Update
				this.frame += this.frameSpeed;
				if (this.frame >= this.animation.length)
				{
					this.frame = 0;
					this.currentKey = 0;
					firstKeyFrame = frameList[this.currentKey];
					secondKeyFrame = frameList[(this.currentKey + 1) % frameList.Count];
				}
				if (this.currentKey == frameList.Count - 1)
				{
					frameList[0].setTime(this.animation.length);
				}
				else
				{
					frameList[0].setTime(0);
					if (this.frame > secondKeyFrame.getTime() && this.frameSpeed >= 0)
					{
						this.currentKey = (this.currentKey + 1) % frameList.Count;
						this.frame = frameList[this.currentKey].getTime();
					}
					else
					{
						if (this.frame < firstKeyFrame.getTime())
						{
							this.currentKey = ((this.currentKey - 1) + frameList.Count) % frameList.Count;
							this.frame = frameList[this.currentKey].getTime();
						}
					}
				}
			}
			else
			{
				firstKeyFrame = frameList[0];
				secondKeyFrame = this.lastRealFrame;
				float temp = (float)(this.fixCounter) / (float)this.fixMaxSteps;
				this.frame = this.lastRealFrame.getTime() + (long)(this.fixMaxSteps * temp);
				this.fixCounter = System.Math.Min(this.fixCounter + this.transitionSpeed, this.fixMaxSteps
					);
				//Update
				if (this.fixCounter == this.fixMaxSteps)
				{
					this.frame = 0;
					this.fixCounter = 0;
					if (this.lastRealFrame.Equals(this.lastFrame))
					{
						this.transitionFixed = true;
					}
					else
					{
						this.transitionTempFixed = true;
					}
					firstKeyFrame.setTime(0);
				}
			}
			//Interpolate
			this.currenObjectsToDraw = firstKeyFrame.getObjects().Length;
			this.currentBonesToAnimate = firstKeyFrame.getBones().Length;
			if (this.updateBones)
			{
				this.transformBones(firstKeyFrame, secondKeyFrame, xOffset, yOffset);
			}
			if (this.updateObjects)
			{
				this.transformObjects(firstKeyFrame, secondKeyFrame, xOffset, yOffset);
			}
		}

		/// <summary>Sets the animationIndex for this to the given animationIndex.</summary>
		/// <remarks>
		/// Sets the animationIndex for this to the given animationIndex.
		/// This method can make sure that the switching between to animations is smooth.
		/// By setting transitionSpeed and transitionSteps to appropriate values, you can have nice transitions between two animations.
		/// Setting transitionSpeed to 1 and transitionSteps to 20 means, that this player will need 20 steps to translate the current animation to the given one.
		/// </remarks>
		/// <param name="animationIndex">
		/// Index of animation to set. Get the index with
		/// <see cref="getAnimationIndexByName(string)">getAnimationIndexByName(string)</see>
		/// .
		/// </param>
		/// <param name="transitionSpeed">Speed for the switch between the current animation and the one which has been set.
		/// 	</param>
		/// <param name="transitionSteps">Steps needed for the transition</param>
		/// <exception cref="System.Exception"></exception>
		public virtual void setAnimatioIndex(int animationIndex, int transitionSpeed, int
			 transitionSteps)
		{
			if (animationIndex >= this.entity.getAnimation().Count || animationIndex < 0)
			{
				throw new System.Exception("The given animation index does not exist: " + animationIndex
					 + "\n" + "Index range goes from 0 to " + (this.entity.getAnimation().Count - 1)
					);
			}
			if (this.animationIndex != animationIndex)
			{
				if (this.transitionFixed)
				{
					this.lastRealFrame = this.lastFrame;
					this.transitionFixed = false;
					this.transitionTempFixed = true;
				}
				else
				{
					this.lastRealFrame = this.lastTempFrame;
					this.transitionTempFixed = false;
					this.transitionFixed = true;
				}
				this.transitionSpeed = transitionSpeed;
				this.fixMaxSteps = transitionSteps;
				this.lastRealFrame.setTime(this.frame + 1);
				this.animation = this.animations[animationIndex];
				this.animation.frames[0].setTime(this.frame + 1 + this.fixMaxSteps);
				this.currentKey = 0;
				this.fixCounter = 0;
				this.animationIndex = animationIndex;
			}
		}

		/// <exception cref="System.Exception"></exception>
		public virtual void setAnimationIndex(int animationIndex)
		{
			this.setAnimatioIndex(animationIndex, 1, 1);
		}

		public virtual void setAnimation(string animationName, int transitionSpeed, int transitionSteps
			)
		{
			int index = getAnimationIndexByName(animationName);
			if (index >= this.entity.getAnimation().Count || index < 0)
			{
				throw new System.Exception("The animation \"" + animationName + "\" does not exist!"
					);
			}
			this.setAnimatioIndex(index, transitionSpeed, transitionSteps);
		}

		/// <summary>Searches for the animation index with the given name and returns the right one
		/// 	</summary>
		/// <param name="name">name of the animation.</param>
		/// <returns>index of the animation if the given name was found, otherwise it returns -1
		/// 	</returns>
		public virtual int getAnimationIndexByName(string name)
		{
			com.discobeard.spriter.dom.Animation anim = this.getAnimationByName(name);
			if (this.getAnimationByName(name) == null)
			{
				return -1;
			}
			else
			{
				return anim.getId();
			}
		}

		/// <summary>Searches for the animation with the given name and returns the right one
		/// 	</summary>
		/// <param name="name">of the animation.</param>
		/// <returns>nimation if the given name was found, otherwise it returns null.</returns>
		public virtual com.discobeard.spriter.dom.Animation getAnimationByName(string name
			)
		{
			System.Collections.Generic.IList<com.discobeard.spriter.dom.Animation> anims = this
				.entity.getAnimation();
			foreach (com.discobeard.spriter.dom.Animation anim in anims)
			{
				if (anim.getName().Equals(name))
				{
					return anim;
				}
			}
			return null;
		}

		/// <returns>current animation index, which has same numbering as in the scml file.</returns>
		public virtual int getAnimationIndex()
		{
			return this.animationIndex;
		}

		/// <returns>the entity, which was read from the scml file you loaded before.</returns>
		public virtual com.discobeard.spriter.dom.Entity getEntity()
		{
			return entity;
		}

		/// <param name="entity">the entity to set</param>
		public virtual void setEntity(com.discobeard.spriter.dom.Entity entity)
		{
			this.entity = entity;
		}

		/// <returns>the current animation with all its raw data which was read from the scml file.
		/// 	</returns>
		public virtual com.brashmonkey.spriter.animation.SpriterAnimation getAnimation()
		{
			return animation;
		}

		private static bool alreadyLoaded(com.discobeard.spriter.dom.Entity entity)
		{
			return loaded.ContainsKey(entity);
		}
	}
}
