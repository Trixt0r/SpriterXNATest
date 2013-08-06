using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using com.brashmonkey.spriter.file;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace SpriterTest
{
    class SpriterLoader: FileLoader
    {
        private Game game;

        public SpriterLoader(Game game)
        {
            this.game = game;
        }

        public override void load(Reference reference, string path)
        {
            try
            {
                FileStream filestream = new FileStream(path, FileMode.Open);
                Texture2D sprite = Texture2D.FromStream(game.GraphicsDevice, filestream);
                files.put(reference, sprite);
                filestream.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public Texture2D getSprite(Reference reference)
        {
            return (Texture2D)this.files.get(reference);
        }

        public void dispose()
        {
            java.util.Iterator it = files.keySet().iterator();
            while (it.hasNext())
            {
                Texture2D sprite = (Texture2D)files.get(it.next());
                sprite.Dispose();
            }
        }
    }
}
