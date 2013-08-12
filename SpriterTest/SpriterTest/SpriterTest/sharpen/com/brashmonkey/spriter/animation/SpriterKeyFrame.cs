/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.animation
{
	/// <summary>A SpriterKeyFrame holds an array of #SpriterBone and an array of #SpriterObject and their transformations.
	/// 	</summary>
	/// <remarks>
	/// A SpriterKeyFrame holds an array of #SpriterBone and an array of #SpriterObject and their transformations.
	/// It also holds an start and end time, which are necessary to interpolate the data with the data of another #SpriterKeyFrame.
	/// </remarks>
	/// <author>Trixt0r</author>
	public class SpriterKeyFrame
	{
		private com.brashmonkey.spriter.objects.SpriterBone[] bones;

		private com.brashmonkey.spriter.objects.SpriterObject[] objects;

		private long time;

		private int id;

		/// <returns>array of bones, this keyframe holds.</returns>
		public virtual com.brashmonkey.spriter.objects.SpriterBone[] getBones()
		{
			return bones;
		}

		/// <param name="bones">to set to this keyframe.</param>
		public virtual void setBones(com.brashmonkey.spriter.objects.SpriterBone[] bones)
		{
			this.bones = bones;
		}

		/// <returns>array of objects, this keyframe holds.</returns>
		public virtual com.brashmonkey.spriter.objects.SpriterObject[] getObjects()
		{
			return objects;
		}

		/// <param name="objects">to set to this keyframe.</param>
		public virtual void setObjects(com.brashmonkey.spriter.objects.SpriterObject[] objects
			)
		{
			this.objects = objects;
		}

		/// <returns>start time of this frame.</returns>
		public virtual long getTime()
		{
			return time;
		}

		/// <param name="startTime">of this frame.</param>
		public virtual void setTime(long startTime)
		{
			this.time = startTime;
		}

		/// <returns>the id</returns>
		public virtual int getId()
		{
			return id;
		}

		/// <param name="id">the id to set</param>
		public virtual void setId(int id)
		{
			this.id = id;
		}

		/// <summary>Returns whether this frame has information about the given object.</summary>
		/// <remarks>Returns whether this frame has information about the given object.</remarks>
		/// <param name="object"></param>
		/// <returns>True if this frame contains the object, false otherwise.</returns>
		public virtual bool containsObject(com.brashmonkey.spriter.objects.SpriterObject 
			@object)
		{
			return this.getObjectFor(@object) != null;
		}

		/// <summary>Returns whether this frame has information about the given bone.</summary>
		/// <remarks>Returns whether this frame has information about the given bone.</remarks>
		/// <param name="bone"></param>
		/// <returns>True if this frame contains the bone, false otherwise.</returns>
		public virtual bool containsBone(com.brashmonkey.spriter.objects.SpriterBone bone
			)
		{
			return this.getBoneFor(bone) != null;
		}

		public virtual com.brashmonkey.spriter.objects.SpriterBone getBoneFor(com.brashmonkey.spriter.objects.SpriterBone
			 bone)
		{
			foreach (com.brashmonkey.spriter.objects.SpriterBone b in this.bones)
			{
				if (b.equals(bone))
				{
					return b;
				}
			}
			return null;
		}

		public virtual com.brashmonkey.spriter.objects.SpriterObject getObjectFor(com.brashmonkey.spriter.objects.SpriterObject
			 @object)
		{
			foreach (com.brashmonkey.spriter.objects.SpriterObject obj in this.objects)
			{
				if (obj.equals(@object))
				{
					return obj;
				}
			}
			return null;
		}
	}
}
