/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter
{
	public class SpriterPoint
	{
		public float x;

		public float y;

		public SpriterPoint(float x, float y)
		{
			this.set(x, y);
		}

		public virtual void translate(float x, float y)
		{
			this.x += x;
			this.y += y;
		}

		public virtual void set(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public virtual void rotate(float degree)
		{
			double angle = SpriterCalculator.DegreeToRadian(degree);
			float cos = (float)System.Math.Cos(angle);
			float sin = (float)System.Math.Sin(angle);
			float xx = x * cos - y * sin;
			float yy = x * sin + y * cos;
			this.x = xx;
			this.y = yy;
		}
	}
}
