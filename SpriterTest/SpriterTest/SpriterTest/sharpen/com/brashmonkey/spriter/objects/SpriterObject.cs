/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;
using System;

namespace com.brashmonkey.spriter.objects
{
	/// <summary>A SpriterObject is an object which holds the transformations for an object which was animated in the Spriter editor.
	/// 	</summary>
	/// <remarks>
	/// A SpriterObject is an object which holds the transformations for an object which was animated in the Spriter editor.
	/// It also holds information about things which will be drawn on the screen, such as sprite, depth and transparency.
	/// </remarks>
	/// <author>Trixt0r</author>
	public class SpriterObject : com.brashmonkey.spriter.objects.SpriterAbstractObject
        , IComparable<com.brashmonkey.spriter.objects.SpriterObject>
	{
		internal float pivotX;

		internal float pivotY;

		internal float alpha;

		internal int zIndex;

		internal bool transientObject = false;

		internal bool visible = true;

		internal com.brashmonkey.spriter.file.Reference @ref;

		//internal com.brashmonkey.spriter.file.FileLoader loader = null;

		internal com.brashmonkey.spriter.SpriterRectangle rect = new com.brashmonkey.spriter.SpriterRectangle
			(0, 0, 0, 0);

		private com.brashmonkey.spriter.SpriterPoint[] boundingPoints;

		public SpriterObject()
		{
			boundingPoints = new com.brashmonkey.spriter.SpriterPoint[4];
			for (int i = 0; i < this.boundingPoints.Length; i++)
			{
				this.boundingPoints[i] = new com.brashmonkey.spriter.SpriterPoint(0, 0);
			}
		}

		public virtual void setRef(com.brashmonkey.spriter.file.Reference @ref)
		{
			this.@ref = @ref;
			this.rect.set(@ref.dimensions);
		}

		public virtual com.brashmonkey.spriter.file.Reference getRef()
		{
			return this.@ref;
		}

		public virtual float getPivotX()
		{
			return pivotX;
		}

		public virtual void setPivotX(float pivotX)
		{
			this.pivotX = pivotX;
		}

		public virtual float getPivotY()
		{
			return pivotY;
		}

		public virtual void setPivotY(float pivotY)
		{
			this.pivotY = pivotY;
		}

		public virtual int getZIndex()
		{
			return zIndex;
		}

		public virtual void setZIndex(int zIndex)
		{
			this.zIndex = zIndex;
		}

		public override void setAngle(float angle)
		{
			this.angle = angle;
		}

		public virtual float getAlpha()
		{
			return alpha;
		}

		public virtual void setAlpha(float alpha)
		{
			this.alpha = alpha;
		}

		public virtual bool isTransientObject()
		{
			return transientObject;
		}

		public virtual void setTransientObject(bool transientObject)
		{
			this.transientObject = transientObject;
		}

		/// <summary>Compares the z_index of the given SpriterObject with this.</summary>
		/// <remarks>Compares the z_index of the given SpriterObject with this.</remarks>
		/// <param name="o">SpriterObject to compare with.</param>
		public virtual int CompareTo(com.brashmonkey.spriter.objects.SpriterObject o)
		{
			if (this.zIndex < o.zIndex)
			{
				return -1;
			}
			else
			{
				if (this.zIndex > o.zIndex)
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
		}

		/*public virtual void setLoader(com.brashmonkey.spriter.file.FileLoader loader)
		{
			this.loader = loader;
		}*/

		/*public virtual com.brashmonkey.spriter.file.FileLoader getLoader()
		{
			return this.loader;
		}*/

		public virtual bool isVisible()
		{
			return visible;
		}

		public virtual void setVisible(bool visible)
		{
			this.visible = visible;
		}

		public override void copyValuesTo(com.brashmonkey.spriter.objects.SpriterAbstractObject
			 @object)
		{
			base.copyValuesTo(@object);
			if (!(@object is com.brashmonkey.spriter.objects.SpriterObject))
			{
				return;
			}
			((com.brashmonkey.spriter.objects.SpriterObject)@object).setAlpha(alpha);
			((com.brashmonkey.spriter.objects.SpriterObject)@object).setRef(@ref);
			((com.brashmonkey.spriter.objects.SpriterObject)@object).setPivotX(pivotX);
			((com.brashmonkey.spriter.objects.SpriterObject)@object).setPivotY(pivotY);
			((com.brashmonkey.spriter.objects.SpriterObject)@object).setTransientObject(transientObject
				);
			((com.brashmonkey.spriter.objects.SpriterObject)@object).setZIndex(zIndex);
			//((com.brashmonkey.spriter.objects.SpriterObject)@object).setLoader(loader);
			((com.brashmonkey.spriter.objects.SpriterObject)@object).setVisible(visible);
			((com.brashmonkey.spriter.objects.SpriterObject)@object).rect.set(this.rect);
		}

        public virtual void copyValuesTo(com.brashmonkey.spriter.draw.DrawInstruction instruction)
		{
			instruction.x = this.x;
			instruction.y = this.y;
			instruction.scaleX = this.scaleX;
			instruction.scaleY = this.scaleY;
			instruction.pivotX = this.pivotX;
			instruction.pivotY = this.pivotY;
			instruction.angle = this.angle;
			instruction.alpha = this.alpha;
			instruction.@ref = this.@ref;
			//instruction.loader = this.loader;
			instruction.obj = this;
		}

		public virtual com.brashmonkey.spriter.SpriterPoint[] getBoundingBox()
		{
			float width = this.@ref.dimensions.width * this.scaleX;
			float height = this.@ref.dimensions.height * this.scaleY;
			float pivotX = width * this.pivotX;
			float pivotY = height * this.pivotY;
			this.boundingPoints[0].set(-pivotX, -pivotY);
			this.boundingPoints[1].set(width - pivotX, -pivotY);
			this.boundingPoints[2].set(-pivotX, height - pivotY);
			this.boundingPoints[3].set(width - pivotX, height - pivotY);
			this.boundingPoints[0].rotate(angle);
			this.boundingPoints[1].rotate(angle);
			this.boundingPoints[2].rotate(angle);
			this.boundingPoints[3].rotate(angle);
			for (int i = 0; i < this.boundingPoints.Length; i++)
			{
				this.boundingPoints[i].translate(x, y);
			}
			return this.boundingPoints;
		}
	}
}
