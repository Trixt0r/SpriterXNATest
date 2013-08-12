/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.player
{
	public interface ISpriterIKResolver
	{
		/// <summary>Resolves the inverse kinematics constraint with a specific algtorithm</summary>
		/// <param name="x">the target x value</param>
		/// <param name="y">the target y value</param>
		/// <param name="chainLength">number of parents which are affected</param>
		/// <param name="effector">the actual effector where the resolved information has to be stored in.
		/// 	</param>
		void resolve(float x, float y, int chainLength, com.brashmonkey.spriter.objects.SpriterAbstractObject
			 effector);

		void setTarget(com.brashmonkey.spriter.player.SpriterAbstractPlayer player);
	}
}
