/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.converters
{
	public class SpriterObjectConverter : com.brashmonkey.spriter.converters.Converter
		<com.discobeard.spriter.dom.AnimationObject, com.brashmonkey.spriter.objects.SpriterObject
		>
	{
		public virtual com.brashmonkey.spriter.objects.SpriterObject convert(com.discobeard.spriter.dom.AnimationObject
			 from)
		{
			com.brashmonkey.spriter.objects.SpriterObject @object = new com.brashmonkey.spriter.objects.SpriterObject
				();
            @object.setAlpha(from.getA().floatValue());
            @object.setAngle(from.getAngle().floatValue());
			@object.setRef(new com.brashmonkey.spriter.file.Reference(from.getFolder(), from.
				getFile()));
            @object.setPivotX(from.getPivotX().floatValue());
            @object.setPivotY(from.getPivotY().floatValue());
            @object.setScaleX(from.getScaleX().floatValue());
            @object.setScaleY(from.getScaleY().floatValue());
            @object.setX(from.getX().floatValue());
            @object.setY(from.getY().floatValue());
			@object.setZIndex(from.getZIndex());
			@object.setTransientObject(true);
			return @object;
		}
	}
}
