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
    class SpriterLoader : FileLoader
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
                files.Add(reference, sprite);
                filestream.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void dispose()
        {
            foreach (KeyValuePair<Reference, object> pair in files)
                ((Texture2D)pair.Value).Dispose();
        }
    }
}
