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
using com.brashmonkey.spriter.objects;
using com.brashmonkey.spriter.player;

namespace com.brashmonkey.spriter.ik
{
	public class SpriterCCDResolver : com.brashmonkey.spriter.ik.SpriterIKResolver
	{
		protected override void resolve(float x, float y, int chainLength, SpriterAbstractObject effector, SpriterAbstractPlayer player)
		{
			base.updateRecursively(player, effector);
			float xx = effector.getX() + (float)System.Math.Cos(SpriterCalculator.DegreeToRadian(effector
				.getAngle())) * com.brashmonkey.spriter.draw.AbstractDrawer.BONE_LENGTH * effector
				.getScaleX();
			float yy = effector.getY() + (float)System.Math.Sin(SpriterCalculator.DegreeToRadian(effector
				.getAngle())) * com.brashmonkey.spriter.draw.AbstractDrawer.BONE_LENGTH * effector
				.getScaleX();
			effector.setAngle(com.brashmonkey.spriter.SpriterCalculator.angleBetween(effector
				.getX(), effector.getY(), x, y));
			if (player.getFlipX() == -1)
			{
				effector.setAngle(effector.getAngle() + 180f);
			}
			SpriterBone parent = null;
			if (effector.hasParent())
			{
				parent = player.getRuntimeBones()[effector.getParentId()];
			}
			//effector.copyValuesTo(temp);
			//SpriterCalculator.reTranslateRelative(parent, temp);
			//if(effector instanceof SpriterBone)	temp.copyValuesTo(player.lastFrame.getBones()[effector.getId()]);
			//else temp.copyValuesTo(player.lastFrame.getObjects()[effector.getId()]);
			for (int i = 0; i < chainLength && parent != null; i++)
			{
				if (com.brashmonkey.spriter.SpriterCalculator.distanceBetween(xx, yy, x, y) <= this
					.tolerance)
				{
					SpriterBone p = null;
					if (parent.hasParent())
					{
						p = player.getRuntimeBones()[parent.getParentId()];
					}
					int j = 0;
					while (p != null && j < chainLength)
					{
						base.updateRecursively(player, p);
						if (p.hasParent())
						{
							p = player.getRuntimeBones()[p.getParentId()];
						}
						else
						{
							p = null;
						}
						j++;
					}
					return;
				}
				parent.setAngle(parent.getAngle() + com.brashmonkey.spriter.SpriterCalculator.angleDifference
					(com.brashmonkey.spriter.SpriterCalculator.angleBetween(parent.getX(), parent.getY
					(), x, y), com.brashmonkey.spriter.SpriterCalculator.angleBetween(parent.getX(), 
					parent.getY(), xx, yy)));
				base.updateRecursively(player, parent);
				if (parent.hasParent())
				{
					parent = player.getRuntimeBones()[parent.getParent().getId()];
				}
				else
				{
					parent = null;
				}
				xx = effector.getX() + (float)System.Math.Cos(SpriterCalculator.DegreeToRadian(effector.getAngle
					())) * com.brashmonkey.spriter.draw.AbstractDrawer.BONE_LENGTH * effector.getScaleX
					();
				yy = effector.getY() + (float)System.Math.Sin(SpriterCalculator.DegreeToRadian(effector.getAngle
					())) * com.brashmonkey.spriter.draw.AbstractDrawer.BONE_LENGTH * effector.getScaleX
					();
			}
		}
	}
}
