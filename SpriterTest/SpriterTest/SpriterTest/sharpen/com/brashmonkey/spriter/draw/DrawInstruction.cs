/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.draw
{
	/// <summary>A DrawIntruction is an object which holds all information you need to draw the previous transformed objects.
	/// 	</summary>
	/// <remarks>A DrawIntruction is an object which holds all information you need to draw the previous transformed objects.
	/// 	</remarks>
	/// <author>Trixt0r</author>
	public class DrawInstruction
	{
		public com.brashmonkey.spriter.file.Reference @ref;

		public float x;

		public float y;

		public float pivotX;

		public float pivotY;

		public float angle;

		public float alpha;

		public float scaleX;

		public float scaleY;

		public com.brashmonkey.spriter.objects.SpriterObject obj = null;

		//public com.brashmonkey.spriter.file.FileLoader<I> loader = null;

		public com.brashmonkey.spriter.SpriterRectangle rect = null;

		public DrawInstruction(com.brashmonkey.spriter.file.Reference @ref, float x, float
			 y, float pivotX, float pivotY, float scaleX, float scaleY, float angle, float alpha
			)
		{
			this.@ref = @ref;
			//rect = new SpriterRectangle(ref.dimensions);
			this.x = x;
			this.y = y;
			this.pivotX = pivotX;
			this.pivotY = pivotY;
			this.angle = angle;
			this.alpha = alpha;
			this.scaleX = scaleX;
			this.scaleY = scaleY;
		}

		/// <returns>the ref</returns>
		public virtual com.brashmonkey.spriter.file.Reference getRef()
		{
			return @ref;
		}

		/// <returns>the x</returns>
		public virtual float getX()
		{
			return x;
		}

		/// <returns>the y</returns>
		public virtual float getY()
		{
			return y;
		}

		/// <returns>the pivotX</returns>
		public virtual float getPivotX()
		{
			return pivotX;
		}

		/// <returns>the pivotY</returns>
		public virtual float getPivotY()
		{
			return pivotY;
		}

		/// <returns>the angle</returns>
		public virtual float getAngle()
		{
			return angle;
		}

		/// <returns>the alpha</returns>
		public virtual float getAlpha()
		{
			return alpha;
		}

		/// <returns>the scaleX</returns>
		public virtual float getScaleX()
		{
			return scaleX;
		}

		/// <returns>the scaleY</returns>
		public virtual float getScaleY()
		{
			return scaleY;
		}

		/// <returns>the obj</returns>
		public virtual com.brashmonkey.spriter.objects.SpriterObject getObj()
		{
			return obj;
		}
	}
}
