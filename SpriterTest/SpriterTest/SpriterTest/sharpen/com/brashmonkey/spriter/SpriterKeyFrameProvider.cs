/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;
using com.brashmonkey.spriter.objects;

namespace com.brashmonkey.spriter
{
	/// <summary>
	/// This class provides the
	/// <see cref="generateKeyFramePool(com.discobeard.spriter.dom.SpriterData, com.discobeard.spriter.dom.Entity)
	/// 	">generateKeyFramePool(com.discobeard.spriter.dom.SpriterData, com.discobeard.spriter.dom.Entity)
	/// 	</see>
	/// method to generate all necessary data which
	/// <see cref="com.brashmonkey.spriter.player.SpriterPlayer">com.brashmonkey.spriter.player.SpriterPlayer
	/// 	</see>
	/// needs to animate.
	/// It is highly recommended to call this method only once for a SCML file since
	/// <see cref="com.brashmonkey.spriter.player.SpriterPlayer">com.brashmonkey.spriter.player.SpriterPlayer
	/// 	</see>
	/// does not modify the data you pass through the
	/// constructor and also to save memory.
	/// </summary>
	/// <author>Trixt0r</author>
	public class SpriterKeyFrameProvider
	{
		/// <summary>Generates all needed keyframes from the given spriter data.</summary>
		/// <remarks>Generates all needed keyframes from the given spriter data. This method sorts all objects by its z_index value to draw them in a proper way.
		/// 	</remarks>
		/// <param name="spriterData">SpriterData to generate from.</param>
		/// <returns>generated keyframe list.</returns>
		public static System.Collections.Generic.IList<com.brashmonkey.spriter.animation.SpriterAnimation
			> generateKeyFramePool(com.discobeard.spriter.dom.SpriterData data, com.discobeard.spriter.dom.Entity
			 entity)
		{
			System.Collections.Generic.IList<com.brashmonkey.spriter.animation.SpriterAnimation
				> spriterAnimations = new System.Collections.Generic.List<com.brashmonkey.spriter.animation.SpriterAnimation
				>();
			System.Collections.Generic.IList<com.discobeard.spriter.dom.Animation> animations
				 = entity.getAnimation();
			com.brashmonkey.spriter.mergers.SpriterAnimationBuilder frameBuilder = new com.brashmonkey.spriter.mergers.SpriterAnimationBuilder
				();
			foreach (com.discobeard.spriter.dom.Animation anim in animations)
			{
				com.brashmonkey.spriter.animation.SpriterAnimation spriterAnimation = frameBuilder
					.buildAnimation(anim);
				bool found = false;
				foreach (com.brashmonkey.spriter.animation.SpriterKeyFrame key in spriterAnimation
					.frames)
				{
					if (!found)
					{
						found = key.getTime() == anim.getLength();
					}
					sort(key.getObjects());
					foreach (com.brashmonkey.spriter.objects.SpriterBone bone in key.getBones())
					{
						foreach (com.brashmonkey.spriter.objects.SpriterBone bone2 in key.getBones())
						{
							if (bone2.hasParent())
							{
								if (!bone2.equals(bone) && bone2.getParentId() == bone.getId())
								{
									bone.addChildBone(bone2);
								}
							}
						}
						foreach (com.brashmonkey.spriter.objects.SpriterObject @object in key.getObjects(
							))
						{
							com.brashmonkey.spriter.file.Reference @ref = @object.getRef();
							com.discobeard.spriter.dom.File f = data.getFolder()[@ref.folder].getFile()[@ref.
								file];
							@ref.dimensions = new com.brashmonkey.spriter.SpriterRectangle(0, f.getHeight(), 
								f.getWidth(), 0f);
							if (bone.getId() == @object.getParentId())
							{
								bone.addChildObject(@object);
							}
						}
					}
				}
				spriterAnimations.Add(spriterAnimation);
			}
			return spriterAnimations;
		}

        public static void sort(SpriterObject[] objects)
        {
            bool PaarSortiert;
            do
            {
                PaarSortiert = true;
                for (int i = 0; i < objects.Length - 1; i++)
                {
                    if (objects[i].getZIndex() > objects[i + 1].getZIndex())
                    {
                        SpriterObject temp = objects[i];
                        objects[i] = objects[i + 1];
                        objects[i + 1] = temp;
                        PaarSortiert = false;
                    }
                }


            } while (!PaarSortiert);
        }
	}
}
