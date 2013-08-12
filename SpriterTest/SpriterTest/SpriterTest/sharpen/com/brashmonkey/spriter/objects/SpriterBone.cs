/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.objects
{
	/// <summary>A SpriterBone is a bone like in the Spriter editor.</summary>
	/// <remarks>A SpriterBone is a bone like in the Spriter editor. It can hold children (#SpriterObject and #SpriterBone) which get manipulated relative to this object.
	/// 	</remarks>
	/// <author>Trixt0r</author>
	public class SpriterBone : com.brashmonkey.spriter.objects.SpriterAbstractObject
	{
        internal System.Collections.Generic.LinkedList<com.brashmonkey.spriter.objects.SpriterBone
			> childBones;

        internal System.Collections.Generic.LinkedList<com.brashmonkey.spriter.objects.SpriterObject
			> childObjects;

		public com.brashmonkey.spriter.SpriterRectangle boundingBox;

		public SpriterBone()
		{
			this.childBones = new System.Collections.Generic.LinkedList<com.brashmonkey.spriter.objects.SpriterBone>();
			this.childObjects = new System.Collections.Generic.LinkedList<com.brashmonkey.spriter.objects.SpriterObject>();
			this.boundingBox = new com.brashmonkey.spriter.SpriterRectangle(0, 0, 0, 0);
		}

		public virtual void addChildBone(com.brashmonkey.spriter.objects.SpriterBone bone
			)
		{
			bone.setParent(this);
			childBones.AddLast(bone);
		}

        public virtual System.Collections.Generic.LinkedList<com.brashmonkey.spriter.objects.SpriterBone
			> getChildBones()
		{
			return childBones;
		}

		public virtual void addChildObject(com.brashmonkey.spriter.objects.SpriterObject 
			@object)
		{
			@object.setParent(this);
			childObjects.AddLast(@object);
		}

        public virtual System.Collections.Generic.LinkedList<com.brashmonkey.spriter.objects.SpriterObject
			> getChildObjects()
		{
			return childObjects;
		}

		public override void copyValuesTo(com.brashmonkey.spriter.objects.SpriterAbstractObject
			 bone)
		{
			base.copyValuesTo(bone);
			if (!(bone is com.brashmonkey.spriter.objects.SpriterBone))
			{
				return;
			}
			((com.brashmonkey.spriter.objects.SpriterBone)bone).childBones = this.childBones;
			((com.brashmonkey.spriter.objects.SpriterBone)bone).childObjects = this.childObjects;
		}

		public virtual void calcBoundingBox(com.brashmonkey.spriter.SpriterRectangle @base
			)
		{
			this.boundingBox.set(@base);
			foreach (com.brashmonkey.spriter.objects.SpriterObject @object in this.childObjects)
			{
				com.brashmonkey.spriter.SpriterPoint[] points = @object.getBoundingBox();
                this.boundingBox.left = System.Math.Min(System.Math.Min(System.Math.Min(System.Math
                    .Min(points[0].x, points[1].x), points[2].x), points[3].x), this.boundingBox.left
					);
                this.boundingBox.right = System.Math.Max(System.Math.Max(System.Math.Max(System.Math
                    .Max(points[0].x, points[1].x), points[2].x), points[3].x), this.boundingBox.right
					);
                this.boundingBox.top = System.Math.Max(System.Math.Max(System.Math.Max(System.Math
					.Max(points[0].y, points[1].y), points[2].y), points[3].y), this.boundingBox.top
					);
                this.boundingBox.bottom = System.Math.Min(System.Math.Min(System.Math.Min(System.Math
                    .Min(points[0].y, points[1].y), points[2].y), points[3].y), this.boundingBox.bottom
					);
			}
			foreach (com.brashmonkey.spriter.objects.SpriterBone child in this.childBones)
			{
				child.calcBoundingBox(boundingBox);
				this.boundingBox.set(child.boundingBox);
			}
		}
	}
}
