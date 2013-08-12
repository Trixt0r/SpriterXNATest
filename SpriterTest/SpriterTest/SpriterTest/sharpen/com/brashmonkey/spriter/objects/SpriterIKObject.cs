/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.objects
{
	public class SpriterIKObject : com.brashmonkey.spriter.objects.SpriterAbstractObject
	{
		public int chainLength;

		public int iterations;

		public SpriterIKObject() : this(0, 1)
		{
		}

		public SpriterIKObject(int length, int iterations)
		{
			this.chainLength = length;
			this.iterations = iterations;
		}

		public SpriterIKObject(int length, int iterations, float x, float y)
		{
			this.chainLength = length;
			this.iterations = iterations;
			this.x = x;
			this.y = y;
		}
	}
}
