using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using com.brashmonkey.spriter;
using com.brashmonkey.spriter.player;

namespace SpriterTest
{
    /// <summary>
    /// Dies ist der Haupttyp für Ihr Spiel
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriterDrawer drawer;
        SpriterLoader loader1;
        SpriterPlayer player1;
        private KeyboardState oldState;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            oldState = new KeyboardState();
        }

        /// <summary>
        /// Ermöglicht dem Spiel die Durchführung einer Initialisierung, die es benötigt, bevor es ausgeführt werden kann.
        /// Dort kann es erforderliche Dienste abfragen und nicht mit der Grafik
        /// verbundenen Content laden.  Bei Aufruf von base.Initialize werden alle Komponenten aufgezählt
        /// sowie initialisiert.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Fügen Sie Ihre Initialisierungslogik hier hinzu

            base.Initialize();
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent wird einmal pro Spiel aufgerufen und ist der Platz, wo
        /// Ihr gesamter Content geladen wird.
        /// </summary>
        protected override void LoadContent()
        {
            // Erstellen Sie einen neuen SpriteBatch, der zum Zeichnen von Texturen verwendet werden kann.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            loader1 = new SpriterLoader(this);
            player1 = new SpriterPlayer(Spriter.getSpriter("monster/basic.scml", loader1), 0, loader1);
            player1.update(0, 0);
            //player1.setAnimation("idle", 0, 0);

            this.drawer = new SpriterDrawer(this.graphics);
            this.drawer.batch = this.spriteBatch;
            this.drawer.loader = this.loader1;
        }

        /// <summary>
        /// UnloadContent wird einmal pro Spiel aufgerufen und ist der Ort, wo
        /// Ihr gesamter Content entladen wird.
        /// </summary>
        protected override void UnloadContent()
        {
            this.loader1.dispose();
            this.drawer.dispose();
            this.spriteBatch.Dispose();
        }

        /// <summary>
        /// Ermöglicht dem Spiel die Ausführung der Logik, wie zum Beispiel Aktualisierung der Welt,
        /// Überprüfung auf Kollisionen, Erfassung von Eingaben und Abspielen von Ton.
        /// </summary>
        /// <param name="gameTime">Bietet einen Schnappschuss der Timing-Werte.</param>
        protected override void Update(GameTime gameTime)
        {
            // Ermöglicht ein Beenden des Spiels
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState newState = Keyboard.GetState();

            // Is the SPACE key down?
            if (newState.IsKeyDown(Keys.Space))
            {
            }
            else if (oldState.IsKeyDown(Keys.Space))
            {
                this.player1.setAnimatioIndex((player1.getAnimationIndex() + 1) % player1.getEntity().getAnimation().size(), 1, 10);
            }

            oldState = newState;

            this.player1.update(this.graphics.PreferredBackBufferWidth/2, -this.graphics.PreferredBackBufferHeight/2);
            this.player1.calcBoundingBox(null);

            // TODO: Fügen Sie Ihre Aktualisierungslogik hier hinzu

            base.Update(gameTime);
        }

        /// <summary>
        /// Dies wird aufgerufen, wenn das Spiel selbst zeichnen soll.
        /// </summary>
        /// <param name="gameTime">Bietet einen Schnappschuss der Timing-Werte.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
                this.drawer.draw(player1);
                this.drawer.debugDraw(player1);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
