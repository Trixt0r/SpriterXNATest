/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter
{
	/// <summary>
	/// A class which provides methods to calculate Spriter specific issues,
	/// like linear interpolation and rotation around a parent object.
	/// </summary>
	/// <remarks>
	/// A class which provides methods to calculate Spriter specific issues,
	/// like linear interpolation and rotation around a parent object.
	/// Other interpolation types are coming with the next releases of Spriter.
	/// </remarks>
	/// <author>Trixt0r</author>
	public class SpriterCalculator
    {

        public static float BONE_LENGTH = 200;

        public static float BONE_WIDTH = 10;
		/// <summary>Calculates interpolated value for positions and scale.</summary>
		/// <remarks>Calculates interpolated value for positions and scale.</remarks>
		/// <param name="a">first value</param>
		/// <param name="b">second value</param>
		/// <param name="timeA">first time</param>
		/// <param name="timeB">second time</param>
		/// <param name="currentTime"></param>
		/// <returns>interpolated value between a and b.</returns>
		public static float calculateInterpolation(float a, float b, float timeA, float timeB
			, float currentTime)
		{
			return a + ((b - a) * ((currentTime - timeA) / (timeB - timeA)));
		}

		/// <summary>Calculates interpolated value for angles.</summary>
		/// <remarks>Calculates interpolated value for angles.</remarks>
		/// <param name="a">first angle</param>
		/// <param name="b">second angle</param>
		/// <param name="timeA">first time</param>
		/// <param name="timeB">second time</param>
		/// <param name="currentTime"></param>
		/// <returns>interpolated angle</returns>
		public static float calculateAngleInterpolation(float a, float b, float timeA, float
			 timeB, float currentTime)
		{
			return a + (angleDifference(b, a) * ((currentTime - timeA) / (timeB - timeA)));
		}

		/// <summary>Calculates the smallest difference between angle a and b.</summary>
		/// <remarks>Calculates the smallest difference between angle a and b.</remarks>
		/// <param name="a">first angle (in degrees)</param>
		/// <param name="b">second angle (in degrees)</param>
		/// <returns>Smallest difference between a and b (between 180° and -180°).</returns>
		public static float angleDifference(float a, float b)
		{
			return ((((a - b) % 360) + 540) % 360) - 180;
		}

		/// <summary>Rotates the given child around the given parent.</summary>
		/// <remarks>Rotates the given child around the given parent.</remarks>
		/// <param name="parent"></param>
		/// <param name="child"></param>
		public static void translateRelative(com.brashmonkey.spriter.objects.SpriterAbstractObject
			 parent, com.brashmonkey.spriter.objects.SpriterAbstractObject child)
		{
			translateRelative(parent, child.getX(), child.getY(), child);
		}

		/// <summary>Rotates the given point around the given parent.</summary>
		/// <remarks>Rotates the given point around the given parent.</remarks>
		/// <param name="parent"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="target">save new position in</param>
		public static void translateRelative(com.brashmonkey.spriter.objects.SpriterAbstractObject
			 parent, float x, float y, com.brashmonkey.spriter.objects.SpriterAbstractObject
			 target)
		{
			float px = x * (parent.getScaleX());
			float py = y * (parent.getScaleY());
			float s = (float)System.Math.Sin(DegreeToRadian(parent.getAngle()));
            float c = (float)System.Math.Cos(DegreeToRadian(parent.getAngle()));
			float xnew = (px * c) - (py * s);
			float ynew = (px * s) + (py * c);
			xnew += parent.getX();
			ynew += parent.getY();
			target.setX(xnew);
			target.setY(ynew);
		}

		public static void reTranslateRelative(com.brashmonkey.spriter.objects.SpriterAbstractObject
			 parent, com.brashmonkey.spriter.objects.SpriterAbstractObject child)
		{
			reTranslateRelative(parent, child.getX(), child.getY(), child);
		}

		public static void reTranslateRelative(com.brashmonkey.spriter.objects.SpriterAbstractObject
			 parent, float x, float y, com.brashmonkey.spriter.objects.SpriterAbstractObject
			 target)
		{
			target.setAngle(target.getAngle() - parent.getAngle());
			target.setScaleX(target.getScaleX() / parent.getScaleX());
			target.setScaleY(target.getScaleY() / parent.getScaleY());
			float xx = x - parent.getX();
			float yy = y - parent.getY();
            double angle = DegreeToRadian(parent.getAngle());
			float cos = (float)System.Math.Cos(angle);
			float sin = (float)System.Math.Sin(angle);
			float newX = yy * sin + xx * cos;
			float newY = yy * cos - xx * sin;
			target.setX(newX / parent.getScaleX());
			target.setY(newY / parent.getScaleY());
		}

		/// <param name="x1">x coordinate of first point.</param>
		/// <param name="y1">y coordinate of first point.</param>
		/// <param name="x2">x coordinate of second point.</param>
		/// <param name="y2">y coordinate of second point.</param>
		/// <returns>Angle between the two given points.</returns>
		public static float angleBetween(float x1, float y1, float x2, float y2)
		{
            return DegreeToRadian((float)System.Math.Atan2(y2 - y1, x2 - x1));
		}

		/// <param name="x1">x coordinate of first point.</param>
		/// <param name="y1">y coordinate of first point.</param>
		/// <param name="x2">x coordinate of second point.</param>
		/// <param name="y2">y coordinate of second point.</param>
		/// <returns>Distance between the two given points.</returns>
		public static float distanceBetween(float x1, float y1, float x2, float y2)
		{
			return (float)System.Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
		}

        public static float DegreeToRadian(float angle)
        {
            return (float)(System.Math.PI * angle / 180.0);
        }
	}
}
