using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TeddyMineExplosion;
namespace ProgrammingAssignment5
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WindowWidth = 800;
        const int WindowHeight = 600;

        const int INITIAL_NUM_TEDDIES = 1;


        //TeddyBear, Mine and Explosion Object
        Texture2D bearSprite;
        Random rand = new Random();
        List<TeddyBear> bears = new List<TeddyBear>();


        int TOTAL_SPAWN_DELAY_MILLISECONDS = 1000;
        int elapsedSpawnDelayMilliseconds = 0;

        Texture2D mineSprite;
        List<Mine> mines = new List<Mine>();

        Texture2D explosionSprite;
        List<Explosion> explosions = new List<Explosion>();

        const float BEAR_SPEED_RANGE = 0.2f;
        bool leftClickStarted = false;
        bool leftButtonReleased = true;

        ButtonState PreviousButtonState = ButtonState.Released;


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

            // TODO: use this.Content to load your game content here
            elapsedSpawnDelayMilliseconds = 0;

            //set a new random spawn delay 1-3 seconds

            int randomNumber = rand.Next(1000, 3000);

            //load sprites

            bearSprite = Content.Load<Texture2D>(@"bin\graphics\teddybear");
            mineSprite = Content.Load<Texture2D>(@"bin\graphics\mine");
            explosionSprite = Content.Load<Texture2D>(@"bin\graphics\explosion");

        }



        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            MouseState mouse = Mouse.GetState();


            // TODO: Add your update logic here
            Vector2 teddyVelocity = new Vector2((float)(rand.NextDouble() - 0.5),

            (float)(rand.NextDouble() - 0.5));

            // spawn teddies as appropriate

            elapsedSpawnDelayMilliseconds += gameTime.ElapsedGameTime.Milliseconds;

            if (elapsedSpawnDelayMilliseconds >= TOTAL_SPAWN_DELAY_MILLISECONDS)

            {

                elapsedSpawnDelayMilliseconds = 0;

                bears.Add(new TeddyBear(bears, new Vector2((float)(rand.NextDouble() - 0.5), (float)(rand.NextDouble() - 0.5)),

                WindowWidth, WindowHeight));

                TOTAL_SPAWN_DELAY_MILLISECONDS = rand.Next(1000, 3000);

            }

            for (int i = 0; i < bears.Count; i++)
            {
                bears[i].Update(gameTime);
            }


            if (mouse.LeftButton == ButtonState.Pressed && leftButtonReleased)
            {
                leftClickStarted = true;
                leftClickStarted = false;

            }

            else if (mouse.LeftButton == ButtonState.Released)

            {

                leftButtonReleased = true;

                if (leftClickStarted)

                {

                    leftClickStarted = false;

                    mines.Add(new Mine(mineSprite, mouse.X, mouse.Y));

                }

                foreach (Explosion bang in explosions)

                {

                    bang.Update(gameTime);

                }

                //Remove explosions

                for (int i = explosions.Count - 1; i >= 0; i--)

                {

                    if (!explosions[i].Playing)

                    {

                        explosions.RemoveAt(i);

                    }

                }

                for (int k = mines.Count - 1; k >= 0; k--)

                {

                    if (!mines[k].Active)

                    {

                        mines.RemoveAt(k);

                    }

                }

                for (int i = -1; i >= 0; i--)

                {

                    if (!bears[i].Active)

                    {

                        bears.RemoveAt(i);

                    }

                }

                foreach (TeddyBear teddy in bears)

                {

                    foreach (Mine mine in mines)

                    {

                        if (teddy.CollisionRectangle.Intersects(mine.CollisionRectangle))

                        {

                            teddy.Active = false;

                            mine.Active = false;

                            Explosion explosion = new Explosion(explosionSprite, (mine.CollisionRectangle.Center.X), (mine.CollisionRectangle.Center.Y));

                        }

                    }

                }

                //update explosions

                foreach (Explosion explosion in explosions)

                {

                    explosion.Update(gameTime);

                }

                //Remove explosions

                if (explosions.Count > 0)

                {

                    for (int i = explosions.Count - 1; i >= 0; i--)

                    {

                        if (!explosions[i].Playing)

                        {

                            explosions.RemoveAt(i);

                        }

                    }

                }

            }

            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            foreach (TeddyBear teddy in bears)
            {
                teddy.Draw(spriteBatch);
            }

            foreach (Mine mine in mines)
            {
                mine.Draw(spriteBatch);
            }

            foreach (Explosion explosion in explosions)
            {
                explosion.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}