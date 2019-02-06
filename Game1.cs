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
        VisibleTiles visibleTiles;

        float PlayerVelocity = 6.0f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            visibleTiles = new VisibleTiles(screenWidth, screenHeight, level.TileWidth, level.TileHeight);
            
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
                actor.Position.Y -= 5;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                actor.Position.X += 5;

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                actor.Position.Y += 5;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                actor.Position.X -= 5;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
          
          GraphicsDevice.Clear(Color.CornflowerBlue);

          spriteBatch.Begin();

          for (int x = 0; x < Level1.Width; x++) {
            for (int y = 0; y < Level1.Height; y++) {
                char tileID = Level1.getTile(x, y);
                switch (tileID) {
                    case '#':
                        spriteBatch.Draw(dirt, new Vector2(x * level.TileWidth, y * level.TileHeight), Color.Red);
                        break;
                    case '.':
                        
                        break;
                    default:
                    
                        break;
                }
              
            }
          }

          spriteBatch.Draw(actor.Sprite, new Vector2(actor.Position.X, actor.Position.Y), Color.White);

          spriteBatch.End();
          // TODO: Add your drawing code here

          base.Draw(gameTime);
        }
    }
}
