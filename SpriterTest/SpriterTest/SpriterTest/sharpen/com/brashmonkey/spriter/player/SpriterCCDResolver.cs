/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.player
{
	public class SpriterCCDResolver : com.brashmonkey.spriter.player.ISpriterIKResolver
	{
		private com.brashmonkey.spriter.player.SpriterAbstractPlayer player;

		private com.brashmonkey.spriter.objects.SpriterAbstractObject temp;

		public SpriterCCDResolver(com.brashmonkey.spriter.player.SpriterAbstractPlayer target
			)
		{
			this.player = target;
			this.temp = new com.brashmonkey.spriter.objects.SpriterBone();
		}

		public virtual void resolve(float x, float y, int chainLength, com.brashmonkey.spriter.objects.SpriterAbstractObject
			 effector)
		{
			float xx = effector.getX() + (float)System.Math.Cos(SpriterCalculator.DegreeToRadian(effector
				.getAngle())) * SpriterCalculator.BONE_LENGTH * effector
				.getScaleX();
            float yy = effector.getY() + (float)System.Math.Sin(SpriterCalculator.DegreeToRadian(effector
                .getAngle())) * SpriterCalculator.BONE_LENGTH * effector
				.getScaleX();
			effector.setAngle(com.brashmonkey.spriter.SpriterCalculator.angleBetween(effector
				.getX(), effector.getY(), x, y));
			if (this.player.getFlipX() == -1)
			{
				effector.setAngle(effector.getAngle() + 180f);
			}
			com.brashmonkey.spriter.objects.SpriterBone parent = null;
			if (effector.hasParent())
			{
				parent = player.getRuntimeBones()[effector.getParentId()];
				effector.copyValuesTo(temp);
				com.brashmonkey.spriter.SpriterCalculator.reTranslateRelative(parent, temp);
				if (effector is com.brashmonkey.spriter.objects.SpriterBone)
				{
					temp.copyValuesTo(player.lastFrame.getBones()[effector.getId()]);
				}
				else
				{
					temp.copyValuesTo(player.lastFrame.getObjects()[effector.getId()]);
				}
			}
			for (int i = 0; i < chainLength && parent != null; i++)
			{
				if (com.brashmonkey.spriter.SpriterCalculator.distanceBetween(xx, yy, x, y) <= 1)
				{
					return;
				}
				parent.setAngle(parent.getAngle() + com.brashmonkey.spriter.SpriterCalculator.angleDifference
					(com.brashmonkey.spriter.SpriterCalculator.angleBetween(parent.getX(), parent.getY
					(), x, y), com.brashmonkey.spriter.SpriterCalculator.angleBetween(parent.getX(), 
					parent.getY(), xx, yy)));
				this.player.updateRecursively(parent);
				if (parent.hasParent())
				{
					parent = player.getRuntimeBones()[parent.getParent().getId()];
				}
				else
				{
					parent = null;
				}
                xx = effector.getX() + (float)System.Math.Cos(SpriterCalculator.DegreeToRadian(effector.getAngle
                    ())) * SpriterCalculator.BONE_LENGTH * effector.getScaleX
					();
                yy = effector.getY() + (float)System.Math.Sin(SpriterCalculator.DegreeToRadian(effector.getAngle
                    ())) * SpriterCalculator.BONE_LENGTH * effector.getScaleX
					();
			}
		}

		public virtual void setTarget(com.brashmonkey.spriter.player.SpriterAbstractPlayer
			 player)
		{
			this.player = player;
		}
	}
}
