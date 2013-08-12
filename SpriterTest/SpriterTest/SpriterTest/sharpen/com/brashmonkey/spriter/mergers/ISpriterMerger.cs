/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.mergers
{
	public interface ISpriterMerger<T, K, V>
	{
		V merge(T from1, K from2);
	}
}
