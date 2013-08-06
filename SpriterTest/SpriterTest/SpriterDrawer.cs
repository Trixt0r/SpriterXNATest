using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using com.brashmonkey.spriter;
using com.brashmonkey.spriter.objects;
using com.brashmonkey.spriter.draw;
using com.brashmonkey.spriter.file;
using com.brashmonkey.spriter.player;

namespace SpriterTest
{
    class SpriterDrawer: AbstractDrawer
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch batch;
        private Texture2D blank;

        public SpriterDrawer(SpriterLoader loader, GraphicsDeviceManager graphics) 
            : base(loader)
        {
            this.graphics = graphics;
            this.blank = new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            this.blank.SetData(new[] { Color.White });
        }

        public SpriterDrawer(GraphicsDeviceManager graphics)
            : this(null, graphics)
        {
        }

        public void dispose()
        {
            this.blank.Dispose();
        }

        public override void draw(DrawInstruction instruction)
        {
            draw(instruction.getRef(), instruction.getX(), instruction.getY(), instruction.getPivotX(),
                instruction.getPivotY(), instruction.getScaleX(), instruction.getScaleY(), instruction.getAngle(),
                instruction.getAlpha());
        }

        public override void draw(SpriterAbstractPlayer player)
        {
            this.loader = player.loader;
            base.draw(player);
        }

        private void draw(Reference reference, float x, float y, float pivotX, float pivotY, float scaleX, float scaleY,
            float angle, float alpha)
        {
            if (reference == null ) return;
            Texture2D sprite = ((SpriterLoader)this.loader).getSprite(reference);
            if(sprite == null) return;
            Vector2 position = new Vector2(x, -y);
            Vector2 origin = new Vector2(reference.dimensions.width * pivotX, reference.dimensions.height * (1 - pivotY));
            Vector2 scale = new Vector2(scaleX, scaleY);
            Color color = new Color(1,1,1, alpha);
            this.batch.Draw(sprite, position, null, color, this.DegreeToRadian(-angle), origin, scale, SpriteEffects.None, 1);
        }

        private float DegreeToRadian(float angle)
        {
            return (float)(Math.PI * angle / 180.0);
        }

        public void debugDraw(SpriterAbstractPlayer player)
        {
		    for(int i = 0; i < player.getRuntimeBones().Length; i++){
			    SpriterBone bone =  player.getRuntimeBones()[i];
                DrawLine(new Vector2(bone.getX(), -bone.getY()),
                    new Vector2(bone.getX() + (float)Math.Cos(DegreeToRadian(-bone.getAngle())) * 200 * bone.getScaleX(),
                        -bone.getY() + (float)Math.Sin(DegreeToRadian(-bone.getAngle())) * 200 * bone.getScaleX()), this.CreateColorColor(i));
		    }
            DrawRectangle(player.getBoundingBox().left, -player.getBoundingBox().top, player.getBoundingBox().right, -player.getBoundingBox().bottom, Color.White);
		
		    for(int j = 0; j< player.getObjectsToDraw(); j++){
                SpriterPoint[] points = player.getRuntimeObjects()[j].getBoundingBox();

                DrawLine(new Vector2(points[0].x, -points[0].y), new Vector2(points[1].x, -points[1].y), this.CreateColorColor(j));
                DrawLine(new Vector2(points[1].x, -points[1].y), new Vector2(points[3].x, -points[3].y), this.CreateColorColor(j));
                DrawLine(new Vector2(points[3].x, -points[3].y), new Vector2(points[2].x, -points[2].y), this.CreateColorColor(j));
                DrawLine(new Vector2(points[2].x, -points[2].y), new Vector2(points[0].x, -points[0].y), this.CreateColorColor(j));
		    }

            }

        void DrawLine(SpriteBatch batch, Texture2D blank, float width, Color color, Vector2 point1, Vector2 point2)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);
 
            batch.Draw(blank, point1, null, color,
                        angle, Vector2.Zero, new Vector2(length, width),
                        SpriteEffects.None, 0);
        }

        void DrawLine(Vector2 point1, Vector2 point2)
        {
            this.DrawLine(this.batch, this.blank, 1f, Color.White, point1, point2);
        }

        void DrawLine(Vector2 point1, Vector2 point2, Color color)
        {
            this.DrawLine(this.batch, this.blank, 1f, color, point1, point2);
        }

        void DrawRectangle(float left, float top, float right, float bottom)
        {
            this.DrawLine(new Vector2(left, top), new Vector2(right, top));
            this.DrawLine(new Vector2(right, top), new Vector2(right, bottom));
            this.DrawLine(new Vector2(right, bottom), new Vector2(left, bottom));
            this.DrawLine(new Vector2(left, top), new Vector2(left, bottom));
        }

        void DrawRectangle(float left, float top, float right, float bottom, Color color)
        {
            this.DrawLine(new Vector2(left, top), new Vector2(right, top), color);
            this.DrawLine(new Vector2(right, top), new Vector2(right, bottom), color);
            this.DrawLine(new Vector2(right, bottom), new Vector2(left, bottom), color);
            this.DrawLine(new Vector2(left, top), new Vector2(left, bottom), color);
        }

        private Color CreateColorColor(int i)
        {
            switch (i % 8)
            {
                case 0: return Color.White;
                case 1: return Color.Red;
                case 2: return Color.Blue;
                case 3: return Color.Yellow;
                case 4: return Color.Violet;
                case 5: return Color.Green;
                case 6: return Color.LightCyan;
                default: return Color.Black;
            }
        }
    }
}
