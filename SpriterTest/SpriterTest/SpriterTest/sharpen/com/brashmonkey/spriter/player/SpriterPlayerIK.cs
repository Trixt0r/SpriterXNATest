/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;
using com.brashmonkey.spriter.objects;

namespace com.brashmonkey.spriter.player
{
	public class SpriterPlayerIK : com.brashmonkey.spriter.player.SpriterPlayer
	{
		private bool resovling;

		private System.Collections.Generic.Dictionary<com.brashmonkey.spriter.objects.SpriterIKObject
			, com.brashmonkey.spriter.objects.SpriterAbstractObject> ikMap;

		private float tolerance;

		private com.brashmonkey.spriter.player.ISpriterIKResolver resolver;

		private com.brashmonkey.spriter.objects.SpriterAbstractObject temp;

		public SpriterPlayerIK(com.discobeard.spriter.dom.SpriterData data, com.discobeard.spriter.dom.Entity
			 entity, com.brashmonkey.spriter.file.FileLoader loader) : base(data, entity
			, loader)
		{
			this.resovling = true;
			this.tolerance = 0.5f;
			this.resolver = new com.brashmonkey.spriter.player.SpriterCCDResolver(this);
			base.step(0, 0);
			this.updateObjects = false;
			this.ikMap = new System.Collections.Generic.Dictionary<com.brashmonkey.spriter.objects.SpriterIKObject
				, com.brashmonkey.spriter.objects.SpriterAbstractObject>();
			this.temp = new com.brashmonkey.spriter.objects.SpriterBone();
		}

		public SpriterPlayerIK(com.brashmonkey.spriter.Spriter spriter, int entityIndex, 
			com.brashmonkey.spriter.file.FileLoader loader) : this(spriter.getSpriterData
			(), spriter.getSpriterData().getEntity()[entityIndex], loader)
		{
		}

		public SpriterPlayerIK(com.discobeard.spriter.dom.SpriterData data, int entityIndex
			, com.brashmonkey.spriter.file.FileLoader loader) : this(data, data.getEntity
			()[entityIndex], loader)
		{
		}

		protected internal override void step(float xOffset, float yOffset)
		{
			base.step(xOffset, yOffset);
			if (this.resovling)
			{
				this.resolve(xOffset, yOffset);
			}
			this.transformObjects(firstKeyFrame, this.secondKeyFrame, xOffset, yOffset);
			for (int i = 0; i < this.currenObjectsToDraw; i++)
			{
				this.tempObjects[i].copyValuesTo(this.instructions[i]);
			}
		}

		private void resolve(float xOffset, float yOffset)
		{
			foreach (System.Collections.Generic.KeyValuePair<com.brashmonkey.spriter.objects.SpriterIKObject
				, com.brashmonkey.spriter.objects.SpriterAbstractObject> entry in this.ikMap.EntrySet())
			{
				for (int j = 0; j < entry.Key.iterations; j++)
				{
                    SpriterAbstractObject obj;
                    if (entry.Value is com.brashmonkey.spriter.objects.SpriterBone) obj = this.tempBones[entry.Value.getId()];
                    else obj = this.tempObjects[entry.Value.getId()];
					this.resolver.resolve(entry.Key.getX(), entry.Key.getY(), entry.Key.chainLength,obj);
				}
			}
		}

		/// <returns>the resovling</returns>
		public virtual bool isResovling()
		{
			return resovling;
		}

		/// <param name="resovling">the resovling to set</param>
		public virtual void setResovling(bool resovling)
		{
			this.resovling = resovling;
		}

		/// <summary>Adds the given object to the internal SpriterIKObject - SpriterBone map, which works like a HashMap.
		/// 	</summary>
		/// <remarks>
		/// Adds the given object to the internal SpriterIKObject - SpriterBone map, which works like a HashMap.
		/// This means, the values of the given object affect the mapped bone.
		/// </remarks>
		/// <param name="object"></param>
		/// <param name="bone"></param>
		public virtual void mapIKObject(com.brashmonkey.spriter.objects.SpriterIKObject @object
			, com.brashmonkey.spriter.objects.SpriterAbstractObject abstractObject)
		{
			this.ikMap.Add(@object, abstractObject);
		}

		/// <summary>Removes the given object from the internal map.</summary>
		/// <remarks>Removes the given object from the internal map.</remarks>
		/// <param name="object"></param>
		public virtual void unmapIKObject(com.brashmonkey.spriter.objects.SpriterIKObject
			 @object)
		{
			Sharpen.Collections.Remove(this.ikMap, @object);
		}

		public virtual float getTolerance()
		{
			return tolerance;
		}

		public virtual void setTolerance(float tolerance)
		{
			this.tolerance = tolerance;
		}

		/// <summary>Changes the state of each effector to unactive.</summary>
		/// <remarks>Changes the state of each effector to unactive. The effect results in non animated bodyparts.
		/// 	</remarks>
		/// <param name="parents">indicates whether parents of the effectors have to be deactivated or not.
		/// 	</param>
		public virtual void deactivateEffectors(bool parents)
		{
			foreach (System.Collections.Generic.KeyValuePair<com.brashmonkey.spriter.objects.SpriterIKObject
				, com.brashmonkey.spriter.objects.SpriterAbstractObject> entry in this.ikMap.EntrySet())
			{
                com.brashmonkey.spriter.objects.SpriterAbstractObject obj = entry.Value;
                if (entry.Value is com.brashmonkey.spriter.objects.SpriterBone) obj = this.tempBones[entry.Value.getId()];
                else obj = this.tempObjects[entry.Value.getId()];
				obj.tween = false;
				if (!parents)
				{
					continue;
				}
				com.brashmonkey.spriter.objects.SpriterBone par = (com.brashmonkey.spriter.objects.SpriterBone
					)entry.Value.getParent();
				for (int j = 0; j < entry.Key.chainLength && par != null; j++)
				{
					this.tempBones[par.getId()].tween = false;
					par = (com.brashmonkey.spriter.objects.SpriterBone)par.getParent();
				}
			}
		}

		public virtual void activateEffectors()
		{
			foreach (System.Collections.Generic.KeyValuePair<com.brashmonkey.spriter.objects.SpriterIKObject
				, com.brashmonkey.spriter.objects.SpriterAbstractObject> entry in this.ikMap.EntrySet())
			{
                com.brashmonkey.spriter.objects.SpriterAbstractObject obj = entry.Value;
                if (entry.Value is com.brashmonkey.spriter.objects.SpriterBone) obj = this.tempBones[entry.Value.getId()];
                else obj = this.tempObjects[entry.Value.getId()];
				obj.tween = true;
				com.brashmonkey.spriter.objects.SpriterBone par = (com.brashmonkey.spriter.objects.SpriterBone
					)entry.Value.getParent();
				for (int j = 0; j < entry.Key.chainLength && par != null; j++)
				{
					this.tempBones[par.getId()].tween = false;
					par = (com.brashmonkey.spriter.objects.SpriterBone)par.getParent();
				}
			}
		}

		/// <returns>the resolver</returns>
		public virtual com.brashmonkey.spriter.player.ISpriterIKResolver getResolver()
		{
			return resolver;
		}

		/// <param name="resolver">the resolver to set</param>
		public virtual void setResolver(com.brashmonkey.spriter.player.ISpriterIKResolver
			 resolver)
		{
			this.resolver = resolver;
		}

		protected internal override void updateBone(com.brashmonkey.spriter.objects.SpriterBone
			 bone)
		{
			base.updateBone(bone);
			bone.copyValuesTo(temp);
			com.brashmonkey.spriter.objects.SpriterAbstractObject parent = (bone.hasParent())
				 ? getRuntimeBones()[bone.getParent().getId()] : this.tempParent;
			com.brashmonkey.spriter.SpriterCalculator.reTranslateRelative(parent, temp);
			temp.copyValuesTo(this.lastFrame.getBones()[temp.getId()]);
		}
	}
}
