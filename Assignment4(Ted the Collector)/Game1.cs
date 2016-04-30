using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProgrammingAssignment4
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

        // teddy support
        Texture2D teddySprite;
        TeddyBear teddy;
        Rectangle drawRectangle;


        // pickup support
        Texture2D pickupSprite;
        List<Pickup> pickups = new List<Pickup>();

        // click processing
        bool rightClickStarted = false;
        bool rightButtonReleased = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // STUDENTS: set resolution and make mouse visible
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

            // STUDENTS: load teddy and pickup sprites
            teddySprite = Content.Load<Texture2D>(@"graphics\teddybear");
            pickupSprite = Content.Load<Texture2D>(@"graphics\pickup");


            // STUDENTS: create teddy object centered in window
            teddy = new TeddyBear(teddySprite, new Vector2(WindowWidth / 2, WindowHeight / 2));

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

            // STUDENTS: get current mouse state and update teddy
            MouseState mouse = Mouse.GetState();
            if (pickups.Count > 0)
            {

                teddy.Update(gameTime, mouse);
            }

            // check for right click started
            if (mouse.RightButton == ButtonState.Pressed &&
                rightButtonReleased)
            {
                rightClickStarted = true;
                rightButtonReleased = false;
            }
            else if (mouse.RightButton == ButtonState.Released)
            {
                rightButtonReleased = true;

                // if right click finished, add new pickup to list
                if (rightClickStarted)
                {
                    rightClickStarted = false;

                    // STUDENTS: add a new pickup to the end of the list of pickups
                    Vector2 pickupPosition = new Vector2(mouse.X, mouse.Y);
                    Pickup pick = new Pickup(pickupSprite, pickupPosition);
                    pickups.Add(pick);


                    // STUDENTS: if this is the first pickup in the list, set teddy target
                    if (pickups.Count > 0)
                    {
                        teddy.SetTarget(new Vector2(pickups[0].CollisionRectangle.Center.X,
                                pickups[0].CollisionRectangle.Center.Y));
                    }
                }
            }

            // check for collision between collecting teddy and targeted pickup
            if (teddy.Collecting &&
                teddy.CollisionRectangle.Intersects(pickups[0].CollisionRectangle))
            {
                // STUDENTS: remove targeted pickup from list (it's always at location 0)
                pickups.RemoveAt(0);

                // STUDENTS: if there's another pickup to collect, set teddy target
                // If not, clear teddy target and stop the teddy from collecting
                if (pickups.Count > 0)
                {
                    

                    teddy.SetTarget(new Vector2(pickups[0].CollisionRectangle.Center.X, pickups[0].CollisionRectangle.Center.Y));
                } else {

                    //clear teddy target
                    teddy.ClearTarget();

                    teddy.Collecting = false;

                    base.Update(gameTime);
                }

            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // draw game objects
            spriteBatch.Begin();
            teddy.Draw(spriteBatch);
            foreach (Pickup pickup in pickups)
            {
                pickup.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

        /// <summary>
        /// Updates the teddy
        /// </summary>
        /// <param name="gameTime">game time</param>
        /// <param name="mouse">current mouse state</param>
        public void Update(GameTime gameTime, MouseState mouse)
        {
            // STUDENTS: update location based on velocity if teddy is collecting
            // Be sure to update the location field first, then center the
            // draw rectangle on the location
            location.X = location.X + velocity.X * gameTime.ElapsedGameTime.Milliseconds;
            location.Y = location.Y + velocity.Y * gameTime.ElapsedGameTime.Milliseconds;
        
            drawRectangle.X = (int)(location.X - halfDrawRectangleWidth);
            drawRectangle.Y = (int)(location.Y - halfDrawRectangleHeight);

            // check for mouse over teddy
            if (drawRectangle.Contains(mouse.X, mouse.Y))
            {
                // check for left click started on teddy
                if (mouse.LeftButton == ButtonState.Pressed &&
                    leftButtonReleased)
                {
                    leftClickStarted = true;
                    leftButtonReleased = false;
                }
                else if (mouse.LeftButton == ButtonState.Released)
                {
                    leftButtonReleased = true;

                    // if click finished on teddy, start collecting if target set
                    if (leftClickStarted)
                    {
                        if (targetSet)
                        {
                            collecting = true;
                        }
                        leftClickStarted = false;
                    }
                }
            }
            else
            {
                // no clicking on teddy
                leftClickStarted = false;
                leftButtonReleased = false;
            }
        }

        /// <summary>
        /// Draws the teddy
        /// </summary>
        /// <param name="spriteBatch">sprite batch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // STUDENTS: use the sprite batch to draw the teddy
            spriteBatch.Draw(this.sprite, drawRectangle, Color.White);
        }

        /// <summary>
        /// Sets a target for the teddy to move toward
        /// </summary>
        /// <param name="target">target</param>
        public void SetTarget(Vector2 target)
        {
			targetSet = true;

            // STUDENTS: set teddy velocity based on teddy center location and target
            Vector2 distance = new Vector2();
            distance.X = target.X - drawRectangle.Center.X;
            distance.Y = target.Y - drawRectangle.Center.Y;
            distance.Normalize();
            this.velocity.X = distance.X * BaseSpeed;
            this.velocity.Y = distance.Y * BaseSpeed;
        }

        /// <summary>
        /// Clears the target for the teddy (it no longer has a target)
        /// </summary>
        public void ClearTarget()
        {
            targetSet = false;
        }

        #endregion
    }
}
