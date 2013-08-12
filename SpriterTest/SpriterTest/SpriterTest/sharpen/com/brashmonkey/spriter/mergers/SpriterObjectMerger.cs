/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.mergers
{
	public class SpriterObjectMerger : com.brashmonkey.spriter.mergers.ISpriterMerger
		<com.discobeard.spriter.dom.AnimationObjectRef, com.discobeard.spriter.dom.Key, 
		com.brashmonkey.spriter.objects.SpriterObject>
	{
		public virtual com.brashmonkey.spriter.objects.SpriterObject merge(com.discobeard.spriter.dom.AnimationObjectRef
			 @ref, com.discobeard.spriter.dom.Key key)
		{
			com.discobeard.spriter.dom.AnimationObject obj = key.getObject()[0];
			com.brashmonkey.spriter.objects.SpriterObject spriterObject = new com.brashmonkey.spriter.objects.SpriterObject
				();
			spriterObject.setId(@ref.getId());
			spriterObject.setParentId(@ref.getParent());
			spriterObject.setTimeline(@ref.getTimeline());
            spriterObject.setAngle(obj.getAngle().floatValue());
			spriterObject.setRef(new com.brashmonkey.spriter.file.Reference(obj.getFolder(), 
				obj.getFile()));
            spriterObject.setPivotX(obj.getPivotX().floatValue());
            spriterObject.setPivotY(obj.getPivotY().floatValue());
            spriterObject.setX(obj.getX().floatValue());
            spriterObject.setY(obj.getY().floatValue());
			spriterObject.setZIndex(@ref.getZIndex());
			spriterObject.setSpin(key.getSpin());
            spriterObject.setAlpha(obj.getA().floatValue());
            spriterObject.setScaleX(obj.getScaleX().floatValue());
            spriterObject.setScaleY(obj.getScaleY().floatValue());
			return spriterObject;
		}
	}
}
