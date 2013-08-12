/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.mergers
{
	public class SpriterBoneMerger : com.brashmonkey.spriter.mergers.ISpriterMerger<com.discobeard.spriter.dom.BoneRef
		, com.discobeard.spriter.dom.Key, com.brashmonkey.spriter.objects.SpriterBone>
	{
		public virtual com.brashmonkey.spriter.objects.SpriterBone merge(com.discobeard.spriter.dom.BoneRef
			 @ref, com.discobeard.spriter.dom.Key key)
		{
			com.discobeard.spriter.dom.Bone obj = key.getBone();
			com.brashmonkey.spriter.objects.SpriterBone bone = new com.brashmonkey.spriter.objects.SpriterBone
				();
			bone.setTimeline(@ref.getTimeline());
			bone.setId(@ref.getId());
			bone.setParentId(@ref.getParent());
			bone.setAngle(obj.getAngle().floatValue());
            bone.setScaleX(obj.getScaleX().floatValue());
            bone.setScaleY(obj.getScaleY().floatValue());
            bone.setX(obj.getX().floatValue());
            bone.setY(obj.getY().floatValue());
			bone.setSpin(key.getSpin());
			return bone;
		}
	}
}
