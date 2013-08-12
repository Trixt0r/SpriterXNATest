/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.interpolation
{
	public class SpriterLinearInterpolator : com.brashmonkey.spriter.interpolation.SpriterInterpolator
	{
		public virtual float interpolate(float a, float b, float timeA, float timeB, float
			 currentTime)
		{
			return com.brashmonkey.spriter.SpriterCalculator.calculateInterpolation(a, b, timeA
				, timeB, currentTime);
		}

		public virtual float interpolateAngle(float a, float b, float timeA, float timeB, 
			float currentTime)
		{
			return com.brashmonkey.spriter.SpriterCalculator.calculateAngleInterpolation(a, b
				, timeA, timeB, currentTime);
		}

		public static readonly com.brashmonkey.spriter.interpolation.SpriterLinearInterpolator
			 interpolator = new com.brashmonkey.spriter.interpolation.SpriterLinearInterpolator
			();
	}
}
