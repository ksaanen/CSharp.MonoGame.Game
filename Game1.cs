using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Game1 : Game
    {
        int screenWidth = 800;
        int screenHeight = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D dirt;
        Actor actor = new Actor();
        Level1 level = new Level1();

        Offset offset = new Offset();
        
        Camera camera = new Camera();

        VisibleTiles visibleTiles;

        Vector2 TileOffset;

        float PlayerVelocity = 6.0f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            visibleTiles = new VisibleTiles(screenWidth, screenHeight, Level1.TileWidth, Level1.TileHeight);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dirt = Content.Load<Texture2D>("dirt");
            actor.Sprite = Content.Load<Texture2D>("dirt");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                actor.Position.Y -= 1.0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                actor.Position.X += 1.0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                actor.Position.Y += 1.0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                actor.Position.X -= 1.0f;

            // TODO: Add your update logic here
            camera.X = actor.Position.X;
            camera.Y = actor.Position.Y;
            offset.X = camera.X - ((float)visibleTiles.X / 2.0f);
            offset.Y = camera.Y - ((float)visibleTiles.Y / 2.0f);

            actor.VelocityX = 0.0f;
            actor.VelocityY = 0.0f;
            

            // Clamp camera
            if (offset.X < 0) offset.X = 0;
            if (offset.Y < 0) offset.Y = 0;
            if (offset.X > Level1.Width - visibleTiles.X) offset.X = Level1.Width - visibleTiles.X;
            if (offset.Y > Level1.Height - visibleTiles.Y) offset.Y = Level1.Height - visibleTiles.Y;

            float TileOffsetX = (offset.X - (int)offset.X) * Level1.TileWidth;
		    float TileOffsetY = (offset.Y - (int)offset.Y) * Level1.TileHeight;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
          
          GraphicsDevice.Clear(Color.CornflowerBlue);

          spriteBatch.Begin();

          for (int x = -1; x < visibleTiles.X + 1; x++)
          {
			for (int y = -1; y < visibleTiles.Y + 1; y++)
            {
               char tileID = Level1.getTile(x + (int)offset.X, y + (int)offset.Y);
                switch (tileID) {
                    case '#':
                        spriteBatch.Draw(dirt, new Vector2(x * Level1.TileWidth - TileOffset.X, y * Level1.TileHeight - TileOffset.Y), Color.White);
                        break;
                    case '.':
                        
                        break;
                    default:

                        break;
                }
              
            }
          }

          spriteBatch.Draw(actor.Sprite, new Vector2((actor.Position.X - offset.X) * Level1.TileWidth, (actor.Position.Y - offset.Y) * Level1.TileHeight), Color.White);

          spriteBatch.End();
          // TODO: Add your drawing code here

          base.Draw(gameTime);
        }
    }
}
