/**************************************************************************
 * Copyright 2013 by Trixt0r
 * (https://github.com/Trixt0r, Heinrich Reich, e-mail: trixter16@web.de)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
***************************************************************************/
using Sharpen;
using com.discobeard.spriter.dom;
using com.brashmonkey.spriter.objects;

namespace com.brashmonkey.spriter.mergers
{
	public class SpriterObjectMerger : com.brashmonkey.spriter.mergers.ISpriterMerger
		<AnimationObjectRef, Key, 
		SpriterObject>
	{
		public virtual SpriterObject merge(AnimationObjectRef
			 @ref, Key key)
		{
			AnimationObject obj = key.getObject()[0];
			SpriterObject spriterObject = new SpriterObject
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
