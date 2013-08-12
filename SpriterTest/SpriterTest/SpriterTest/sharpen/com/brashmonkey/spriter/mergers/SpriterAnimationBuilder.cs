/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.mergers
{
	public class SpriterAnimationBuilder
	{
		private readonly com.brashmonkey.spriter.mergers.SpriterBoneMerger boneMerger = new 
			com.brashmonkey.spriter.mergers.SpriterBoneMerger();

		private readonly com.brashmonkey.spriter.mergers.SpriterObjectMerger objectMerger
			 = new com.brashmonkey.spriter.mergers.SpriterObjectMerger();

		internal System.Collections.Generic.Dictionary<com.brashmonkey.spriter.objects.SpriterBone
			, int> bonesToTween;

		internal System.Collections.Generic.Dictionary<com.brashmonkey.spriter.objects.SpriterObject
			, int> objectsToTween;

		//import com.brashmonkey.spriter.converters.SpriterObjectConverter;
		//import com.discobeard.spriter.dom.AnimationObject;
		//final private SpriterObjectConverter objectConverter = new SpriterObjectConverter();
		public virtual com.brashmonkey.spriter.animation.SpriterAnimation buildAnimation(
			com.discobeard.spriter.dom.Animation animation)
		{
			com.discobeard.spriter.dom.MainLine mainline = animation.getMainline();
			System.Collections.Generic.IList<com.discobeard.spriter.dom.TimeLine> timeLines = 
				animation.getTimeline();
			System.Collections.Generic.IList<com.discobeard.spriter.dom.Key> keyFrames = mainline
				.getKey();
			bonesToTween = new System.Collections.Generic.Dictionary<com.brashmonkey.spriter.objects.SpriterBone
				, int>();
			objectsToTween = new System.Collections.Generic.Dictionary<com.brashmonkey.spriter.objects.SpriterObject
				, int>();
			com.brashmonkey.spriter.animation.SpriterAnimation spriterAnimation = new com.brashmonkey.spriter.animation.SpriterAnimation
				(animation.getId(), animation.getName(), animation.getLength());
			for (int k = 0; k < keyFrames.Count; k++)
			{
				com.discobeard.spriter.dom.Key mainlineKey = keyFrames[k];
				System.Collections.Generic.IList<com.brashmonkey.spriter.objects.SpriterObject> tempObjects
					 = new System.Collections.Generic.List<com.brashmonkey.spriter.objects.SpriterObject
					>();
				System.Collections.Generic.IList<com.brashmonkey.spriter.objects.SpriterBone> tempBones
					 = new System.Collections.Generic.List<com.brashmonkey.spriter.objects.SpriterBone
					>();
				com.brashmonkey.spriter.animation.SpriterKeyFrame frame = new com.brashmonkey.spriter.animation.SpriterKeyFrame
					();
				frame.setTime(mainlineKey.getTime());
				frame.setId(mainlineKey.getId());
				foreach (com.discobeard.spriter.dom.BoneRef boneRef in mainlineKey.getBoneRef())
				{
					com.discobeard.spriter.dom.TimeLine timeline = timeLines[boneRef.getTimeline()];
					com.discobeard.spriter.dom.Key timelineKey = timeline.getKey()[boneRef.getKey()];
					com.brashmonkey.spriter.objects.SpriterBone bone = boneMerger.merge(boneRef, timelineKey
						);
					bone.setName(timeline.getName());
					if (mainlineKey.getTime() != timelineKey.getTime())
					{
						bonesToTween.Add(bone, k);
					}
					else
					{
						tempBones.Add(bone);
					}
				}
				//}
				foreach (com.discobeard.spriter.dom.AnimationObjectRef objectRef in mainlineKey.getObjectRef
					())
				{
					com.discobeard.spriter.dom.TimeLine timeline = timeLines[objectRef.getTimeline()];
					com.discobeard.spriter.dom.Key timelineKey = timeline.getKey()[objectRef.getKey()
						];
					com.brashmonkey.spriter.objects.SpriterObject @object = objectMerger.merge(objectRef
						, timelineKey);
					@object.setName(timeline.getName());
					if (mainlineKey.getTime() != timelineKey.getTime())
					{
						objectsToTween.Add(@object, k);
					}
					else
					{
						tempObjects.Add(@object);
					}
				}
				//}
				frame.setObjects(Sharpen.Collections.ToArray(tempObjects, new com.brashmonkey.spriter.objects.SpriterObject
					[tempObjects.Count]));
				frame.setBones(Sharpen.Collections.ToArray(tempBones, new com.brashmonkey.spriter.objects.SpriterBone
					[tempBones.Count]));
				spriterAnimation.frames.Add(frame);
			}
			this.tweenBones(spriterAnimation);
			this.tweenObjects(spriterAnimation);
			return spriterAnimation;
		}

		public virtual void tweenBones(com.brashmonkey.spriter.animation.SpriterAnimation
			 animation)
		{
			foreach (System.Collections.Generic.KeyValuePair<com.brashmonkey.spriter.objects.SpriterBone
				, int> entry in bonesToTween.EntrySet())
			{
				com.brashmonkey.spriter.objects.SpriterBone toTween = entry.Key;
				com.brashmonkey.spriter.animation.SpriterKeyFrame frame = animation.frames[entry.
					Value];
				long time = frame.getTime();
				com.brashmonkey.spriter.animation.SpriterKeyFrame currentFrame = animation.getPreviousFrameForBone
					(toTween, time);
				com.brashmonkey.spriter.animation.SpriterKeyFrame nextFrame = animation.getNextFrameFor
					(toTween, currentFrame, 1);
				if (nextFrame != currentFrame)
				{
					com.brashmonkey.spriter.objects.SpriterBone bone1 = currentFrame.getBoneFor(toTween
						);
					com.brashmonkey.spriter.objects.SpriterBone bone2 = nextFrame.getBoneFor(toTween);
					this.interpolateAbstractObject(toTween, bone1, bone2, currentFrame.getTime(), nextFrame
						.getTime(), time);
				}
				com.brashmonkey.spriter.objects.SpriterBone[] bones = new com.brashmonkey.spriter.objects.SpriterBone
					[frame.getBones().Length + 1];
				for (int i = 0; i < bones.Length - 1; i++)
				{
					bones[i] = frame.getBones()[i];
				}
				bones[bones.Length - 1] = toTween;
				frame.setBones(bones);
			}
		}

		public virtual void tweenObjects(com.brashmonkey.spriter.animation.SpriterAnimation
			 animation)
		{
			foreach (System.Collections.Generic.KeyValuePair<com.brashmonkey.spriter.objects.SpriterObject
				, int> entry in objectsToTween.EntrySet())
			{
				com.brashmonkey.spriter.objects.SpriterObject toTween = entry.Key;
				com.brashmonkey.spriter.animation.SpriterKeyFrame frame = animation.frames[entry.
					Value];
				long time = frame.getTime();
				com.brashmonkey.spriter.animation.SpriterKeyFrame currentFrame = animation.getPreviousFrameForObject
					(toTween, time);
				com.brashmonkey.spriter.animation.SpriterKeyFrame nextFrame = animation.getNextFrameFor
					(toTween, currentFrame, 1);
				if (nextFrame != currentFrame)
				{
					com.brashmonkey.spriter.objects.SpriterObject object1 = currentFrame.getObjectFor
						(toTween);
					com.brashmonkey.spriter.objects.SpriterObject object2 = nextFrame.getObjectFor(toTween
						);
					this.interpolateSpriterObject(toTween, object1, object2, currentFrame.getTime(), 
						nextFrame.getTime(), time);
				}
				com.brashmonkey.spriter.objects.SpriterObject[] objects = new com.brashmonkey.spriter.objects.SpriterObject
					[frame.getObjects().Length + 1];
				for (int i = 0; i < objects.Length - 1; i++)
				{
					objects[i] = frame.getObjects()[i];
				}
				objects[objects.Length - 1] = toTween;
				frame.setObjects(objects);
			}
		}

		private void interpolateAbstractObject(com.brashmonkey.spriter.objects.SpriterAbstractObject
			 target, com.brashmonkey.spriter.objects.SpriterAbstractObject obj1, com.brashmonkey.spriter.objects.SpriterAbstractObject
			 obj2, float startTime, float endTime, float frame)
		{
			if (obj2 == null)
			{
				return;
			}
			target.setX(this.interpolate(obj1.getX(), obj2.getX(), startTime, endTime, frame)
				);
			target.setY(this.interpolate(obj1.getY(), obj2.getY(), startTime, endTime, frame)
				);
			target.setScaleX(this.interpolate(obj1.getScaleX(), obj2.getScaleX(), startTime, 
				endTime, frame));
			target.setScaleY(this.interpolate(obj1.getScaleY(), obj2.getScaleY(), startTime, 
				endTime, frame));
			target.setAngle(this.interpolateAngle(obj1.getAngle(), obj2.getAngle(), startTime
				, endTime, frame));
		}

		private void interpolateSpriterObject(com.brashmonkey.spriter.objects.SpriterObject
			 target, com.brashmonkey.spriter.objects.SpriterObject obj1, com.brashmonkey.spriter.objects.SpriterObject
			 obj2, float startTime, float endTime, float frame)
		{
			if (obj2 == null)
			{
				return;
			}
			this.interpolateAbstractObject(target, obj1, obj2, startTime, endTime, frame);
			target.setPivotX(this.interpolate(obj1.getPivotX(), obj2.getPivotX(), startTime, 
				endTime, frame));
			target.setPivotY(this.interpolate(obj1.getPivotY(), obj2.getPivotY(), startTime, 
				endTime, frame));
			target.setAlpha(this.interpolateAngle(obj1.getAlpha(), obj2.getAlpha(), startTime
				, endTime, frame));
		}

		/// <summary>
		/// See
		/// <see cref="com.brashmonkey.spriter.SpriterCalculator.calculateInterpolation(float, float, float, float, float)
		/// 	">com.brashmonkey.spriter.SpriterCalculator.calculateInterpolation(float, float, float, float, float)
		/// 	</see>
		/// Can be inherited, to handle other interpolation techniques. Standard is linear interpolation.
		/// </summary>
		protected internal virtual float interpolate(float a, float b, float timeA, float
			 timeB, float currentTime)
		{
			return com.brashmonkey.spriter.interpolation.SpriterLinearInterpolator.interpolator
				.interpolate(a, b, timeA, timeB, currentTime);
		}

		/// <summary>
		/// See
		/// <see cref="com.brashmonkey.spriter.SpriterCalculator.calculateInterpolation(float, float, float, float, float)
		/// 	">com.brashmonkey.spriter.SpriterCalculator.calculateInterpolation(float, float, float, float, float)
		/// 	</see>
		/// Can be inherited, to handle other interpolation techniques. Standard is linear interpolation.
		/// </summary>
		protected internal virtual float interpolateAngle(float a, float b, float timeA, 
			float timeB, float currentTime)
		{
			return com.brashmonkey.spriter.interpolation.SpriterLinearInterpolator.interpolator
				.interpolateAngle(a, b, timeA, timeB, currentTime);
		}
	}
}
