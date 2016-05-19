using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ExplodingTeddies;

namespace Lab11
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int WindowWidth = 800;
        public const int WindowHeight = 600;

        const int NUM_TEDDIES = 1;

        Texture2D bearSprite;

        //game objects
        List<TeddyBear> bears = new List<TeddyBear>();

        const int TOTAL_SPAWN_DELAY_MILLISECONDS = 1000;
        int elapsedSpawnDelayMilliseconds = 0;

        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;

            IsMouseVisible = true;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

            bearSprite = Content.Load<Texture2D>(@"graphics\teddybear");

            //create game objects
            for (int i = 0; i < NUM_TEDDIES; i++)
            {
                bears.Add(GetRandomBear());
            }


        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //for (int i = 0; i < bears.Count; i++)
            //
               // bears[i].Update(gameTime);
            //}

            foreach (TeddyBear bear in bears)
            {
                bear.Update(gameTime);

            }

            base.Update(gameTime);
        }

        // TODO: Add your update logic here




        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            for (int i = 0; i < bears.Count; i++)
            {
                bears[i].Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }


        private TeddyBear GetRandomBear()
        {
            Texture2D sprite = Sprites[rand.Next(3)];
            return new TeddyBear(sprite,
                rand.Next(WindowWidth - sprite.Width),
                rand.Next(WindowHeight - sprite.Height),
                WindowWidth, WindowHeight);
        }
    }
}
