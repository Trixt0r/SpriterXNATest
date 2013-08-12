/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.interpolation
{
	public interface SpriterInterpolator
	{
		float interpolate(float a, float b, float timeA, float timeB, float currentTime);

		float interpolateAngle(float a, float b, float timeA, float timeB, float currentTime
			);
	}
}
