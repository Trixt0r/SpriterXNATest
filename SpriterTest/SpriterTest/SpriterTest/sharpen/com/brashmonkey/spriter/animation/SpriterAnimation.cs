/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.animation
{
	public class SpriterAnimation
	{
		public readonly System.Collections.Generic.List<com.brashmonkey.spriter.animation.SpriterKeyFrame
			> frames;

		public readonly string name;

		public readonly int id;

		public readonly long length;

		public SpriterAnimation(int id, string name, long length)
		{
			this.frames = new System.Collections.Generic.List<com.brashmonkey.spriter.animation.SpriterKeyFrame
				>();
			this.id = id;
			this.name = name;
			this.length = length;
		}

		/// <summary>Searches for a keyframe in this animation which has a smaller or equal starting time as the given time.
		/// 	</summary>
		/// <remarks>Searches for a keyframe in this animation which has a smaller or equal starting time as the given time.
		/// 	</remarks>
		/// <param name="time"></param>
		/// <returns>A keyframe object which has a smaller or equal starting time than the given time.
		/// 	</returns>
		public virtual com.brashmonkey.spriter.animation.SpriterKeyFrame getPreviousFrame
			(long time)
		{
			com.brashmonkey.spriter.animation.SpriterKeyFrame frame = null;
			foreach (com.brashmonkey.spriter.animation.SpriterKeyFrame key in this.frames)
			{
				if (key.getTime() <= time)
				{
					frame = key;
				}
				else
				{
					break;
				}
			}
			return frame;
		}

		/// <summary>Searches for a keyframe in this animation which has a smaller or equal starting time as the given time and contains the given bone.
		/// 	</summary>
		/// <remarks>Searches for a keyframe in this animation which has a smaller or equal starting time as the given time and contains the given bone.
		/// 	</remarks>
		/// <param name="bone"></param>
		/// <param name="time"></param>
		/// <returns>A keyframe object which has a smaller or equal starting time than the given time and contains the given bone.
		/// 	</returns>
		public virtual com.brashmonkey.spriter.animation.SpriterKeyFrame getPreviousFrameForBone
			(com.brashmonkey.spriter.objects.SpriterBone bone, long time)
		{
			com.brashmonkey.spriter.animation.SpriterKeyFrame frame = null;
			foreach (com.brashmonkey.spriter.animation.SpriterKeyFrame key in this.frames)
			{
				if (!key.containsBone(bone))
				{
					continue;
				}
				if (key.getTime() <= time)
				{
					frame = key;
				}
				else
				{
					break;
				}
			}
			return frame;
		}

		/// <summary>Searches for a keyframe in this animation which has a smaller or equal starting time as the given time and contains the given object.
		/// 	</summary>
		/// <remarks>Searches for a keyframe in this animation which has a smaller or equal starting time as the given time and contains the given object.
		/// 	</remarks>
		/// <param name="object"></param>
		/// <param name="time"></param>
		/// <returns>A keyframe object which has a smaller or equal starting time than the given time and contains the given object.
		/// 	</returns>
		public virtual com.brashmonkey.spriter.animation.SpriterKeyFrame getPreviousFrameForObject
			(com.brashmonkey.spriter.objects.SpriterObject @object, long time)
		{
			com.brashmonkey.spriter.animation.SpriterKeyFrame frame = null;
			foreach (com.brashmonkey.spriter.animation.SpriterKeyFrame key in this.frames)
			{
				if (!key.containsObject(@object))
				{
					continue;
				}
				if (key.getTime() <= time)
				{
					frame = key;
				}
				else
				{
					break;
				}
			}
			return frame;
		}

		/// <returns>number of frames in this animation.</returns>
		public virtual int numberOfFrames()
		{
			return this.frames.Count;
		}

		public virtual com.brashmonkey.spriter.animation.SpriterKeyFrame getNextFrameFor(
			com.brashmonkey.spriter.objects.SpriterAbstractObject @object, com.brashmonkey.spriter.animation.SpriterKeyFrame
			 currentFrame, int direction)
		{
			com.brashmonkey.spriter.animation.SpriterKeyFrame nextFrame = null;
			int cnt = 0;
			bool isBone = @object is com.brashmonkey.spriter.objects.SpriterBone;
			for (int j = (currentFrame.getId() + direction + this.numberOfFrames()) % this.numberOfFrames(); 
				nextFrame == null && cnt < this.numberOfFrames(); j = (j + direction + this.numberOfFrames()) % 
				this.numberOfFrames(), cnt++)
			{
				com.brashmonkey.spriter.animation.SpriterKeyFrame frame = this.frames[j];
				bool contains = (isBone) ? frame.containsBone((com.brashmonkey.spriter.objects.SpriterBone
					)@object) : frame.containsObject((com.brashmonkey.spriter.objects.SpriterObject)
					@object);
				if (contains)
				{
					com.brashmonkey.spriter.objects.SpriterAbstractObject objectInFrame;
                    if(isBone) objectInFrame = frame.getBoneFor((com.brashmonkey.spriter.objects.SpriterBone)@object);
                    else objectInFrame = frame.getObjectFor((com.brashmonkey.spriter.objects.SpriterObject)@object);
					if (@object.equals(objectInFrame))
					{
						nextFrame = frame;
					}
				}
			}
			return nextFrame;
		}
	}
}
