using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D dirt;

        float PlayerVelocity = 6.0f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            
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
            dirt = new Texture2D(GraphicsDevice, 16, 16);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
          Level1 level = new Level1();
          GraphicsDevice.Clear(Color.CornflowerBlue);

          spriteBatch.Begin();

          for (int x = 0; x < level.Width; x++) {
            for (int y = 0; y < level.Height; y++) {
              spriteBatch.Draw(dirt, new Vector2(x * level.TileWidth, y * level.TileHeight), Color.Red);
            }
          }

          spriteBatch.End();
          // TODO: Add your drawing code here

          base.Draw(gameTime);
        }
    }
}
