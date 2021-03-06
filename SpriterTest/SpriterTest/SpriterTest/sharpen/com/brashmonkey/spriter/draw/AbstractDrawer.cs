/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.draw
{
	/// <summary>An AbstractDrawer is an object which is able to draw an animated entity.
	/// 	</summary>
	/// <remarks>
	/// An AbstractDrawer is an object which is able to draw an animated entity.
	/// To use a drawer, you have to implement
	/// <see cref="AbstractDrawer{L}.draw(DrawInstruction)">AbstractDrawer&lt;L&gt;.draw(DrawInstruction)
	/// 	</see>
	/// which fits to your environment.
	/// </remarks>
	/// <author>Trixt0r</author>
	/// <?></?>
	public abstract class AbstractDrawer
	{
		public com.brashmonkey.spriter.file.FileLoader loader;

		public bool drawBone = true;

		public bool drawBox = true;

		public AbstractDrawer(com.brashmonkey.spriter.file.FileLoader loader)
		{
			this.loader = loader;
		}

		/// <summary>Draws a sprite with the given instruction.</summary>
		/// <remarks>Draws a sprite with the given instruction.</remarks>
		/// <param name="instruction">Instruction to draw with.</param>
		public abstract void draw(com.brashmonkey.spriter.draw.DrawInstruction instruction);

		/// <summary>
		/// Draws the playing animation in <code>player</code> with all bones (if
		/// <see cref="AbstractDrawer{L}.drawBone">AbstractDrawer&lt;L&gt;.drawBones</see>
		/// is true) and bounding boxes (if
		/// <see cref="AbstractDrawer{L}.drawBox">AbstractDrawer&lt;L&gt;.drawBoxes</see>
		/// is true) but without the corresponding sprites.
		/// </summary>
		/// <param name="player">
		/// 
		/// <see>[com.brashmonkey.spriter.player.]SpriterAbstractPlayer AbstractPlayer</see>
		/// to draw
		/// </param>
		public virtual void debugDraw(com.brashmonkey.spriter.player.SpriterAbstractPlayer
			 player)
		{
			if (drawBox)
			{
				this.drawBoxes(player);
			}
			if (drawBone)
			{
				this.drawBones(player);
			}
		}

		protected virtual void drawBones(com.brashmonkey.spriter.player.SpriterAbstractPlayer
			 player)
		{
			this.setDrawColor(1, 0, 0, 1);
			for (int i = 0; i < player.getBonesToAnimate(); i++)
			{
				com.brashmonkey.spriter.objects.SpriterBone bone = player.getRuntimeBones()[i];
				float xx = bone.getX() + (float)System.Math.Cos(DegreeToRadian(bone.getAngle
					())) * 5;
                float yy = bone.getY() + (float)System.Math.Sin(DegreeToRadian(bone.getAngle
					())) * 5;
                float x2 = (float)System.Math.Cos(DegreeToRadian(bone.getAngle() + 90)) * 
					(SpriterCalculator.BONE_WIDTH / 2) * bone.getScaleY();
                float y2 = (float)System.Math.Sin(DegreeToRadian(bone.getAngle() + 90)) *
                    (SpriterCalculator.BONE_WIDTH / 2) * bone.getScaleY();
                float targetX = bone.getX() + (float)System.Math.Cos(DegreeToRadian(bone.getAngle
                    ())) * SpriterCalculator.BONE_LENGTH * bone.getScaleX();
                float targetY = bone.getY() + (float)System.Math.Sin(DegreeToRadian(bone.getAngle
                    ())) * SpriterCalculator.BONE_LENGTH * bone.getScaleX();
				float upperPointX = xx + x2;
				float upperPointY = yy + y2;
				this.drawLine(bone.getX(), bone.getY(), upperPointX, upperPointY);
				this.drawLine(upperPointX, upperPointY, targetX, targetY);
				float lowerPointX = xx - x2;
				float lowerPointY = yy - y2;
				this.drawLine(bone.getX(), bone.getY(), lowerPointX, lowerPointY);
				this.drawLine(lowerPointX, lowerPointY, targetX, targetY);
				this.drawLine(bone.getX(), bone.getY(), targetX, targetY);
			}
		}

		protected virtual void drawBoxes(com.brashmonkey.spriter.player.SpriterAbstractPlayer
			 player)
		{
			this.setDrawColor(0f, .25f, 1f, 1f);
			this.drawRectangle(player.getBoundingBox().left, player.getBoundingBox().bottom, 
				player.getBoundingBox().width, player.getBoundingBox().height);
			for (int j = 0; j < player.getObjectsToDraw(); j++)
			{
				com.brashmonkey.spriter.SpriterPoint[] points = player.getRuntimeObjects()[j].getBoundingBox
					();
				this.drawLine(points[0].x, points[0].y, points[1].x, points[1].y);
				this.drawLine(points[1].x, points[1].y, points[3].x, points[3].y);
				this.drawLine(points[3].x, points[3].y, points[2].x, points[2].y);
				this.drawLine(points[2].x, points[2].y, points[0].x, points[0].y);
			}
		}

		protected abstract void setDrawColor(float r, float g, float b, float a);

		protected abstract void drawLine(float x1, float y1, float x2, float y2);

		protected abstract void drawRectangle(float x, float y, float width, float
			 height);

		/// <summary>Draws the given player with its sprites.</summary>
		/// <remarks>Draws the given player with its sprites.</remarks>
		/// <param name="player">Player to draw.</param>
		public virtual void draw(com.brashmonkey.spriter.player.SpriterAbstractPlayer player
			)
		{
			com.brashmonkey.spriter.draw.DrawInstruction[] instructions = player.getDrawInstructions
				();
			for (int i = 0; i < player.getObjectsToDraw(); i++)
			{
				if (instructions[i].obj.isVisible())
				{
					this.draw(instructions[i]);
				}
				foreach (com.brashmonkey.spriter.player.SpriterAbstractPlayer pl in player.getAttachedPlayers
					())
				{
					if (player.getZIndex() == i)
					{
						draw(pl);
						pl.drawn = true;
					}
				}
			}
			foreach (com.brashmonkey.spriter.player.SpriterAbstractPlayer pl_1 in player.getAttachedPlayers
				())
			{
				if (!player.drawn)
				{
					draw(pl_1);
				}
				player.drawn = false;
			}
		}

		protected internal virtual object getFile(com.brashmonkey.spriter.file.Reference reference
			)
		{
			return loader.get(reference);
		}



        protected float DegreeToRadian(float angle)
        {
            return SpriterCalculator.DegreeToRadian(angle);
        }
	}
}
