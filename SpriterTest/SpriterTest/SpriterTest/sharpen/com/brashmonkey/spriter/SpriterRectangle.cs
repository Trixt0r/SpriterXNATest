/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter
{
	public class SpriterRectangle
	{
		public float left;

		public float top;

		public float right;

		public float bottom;

		public float width;

		public float height;

		public SpriterRectangle(float left, float top, float right, float bottom)
		{
			this.set(left, top, right, bottom);
			this.calculateSize();
		}

		public SpriterRectangle(com.brashmonkey.spriter.SpriterRectangle rect)
		{
			this.set(rect);
		}

		public virtual bool isInisde(float x, float y)
		{
			return x >= this.left && x <= this.right && y <= this.top && y >= this.bottom;
		}

		public virtual void calculateSize()
		{
			this.width = right - left;
			this.height = top - bottom;
		}

		public virtual void set(com.brashmonkey.spriter.SpriterRectangle rect)
		{
			if (rect == null)
			{
				return;
			}
			this.bottom = rect.bottom;
			this.left = rect.left;
			this.right = rect.right;
			this.top = rect.top;
			this.calculateSize();
		}

		public virtual void set(float left, float top, float right, float bottom)
		{
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		public static bool areIntersecting(com.brashmonkey.spriter.SpriterRectangle rect1
			, com.brashmonkey.spriter.SpriterRectangle rect2)
		{
			return rect1.isInisde(rect2.left, rect2.top) || rect1.isInisde(rect2.right, rect2
				.top) || rect1.isInisde(rect2.left, rect2.bottom) || rect1.isInisde(rect2.right, 
				rect2.bottom);
		}
	}
}
