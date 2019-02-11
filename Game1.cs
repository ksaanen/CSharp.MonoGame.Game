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
                actor.NewPosY -= 1.0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                actor.NewPosX += 1.0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                actor.NewPosY += 1.0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                actor.NewPosX -= 1.0f;

            // TODO: Add your update logic here
            camera.X = actor.NewPosX;
            camera.Y = actor.NewPosY;
            offset.X = camera.X - ((float)visibleTiles.X / 2.0f);
            offset.Y = camera.Y - ((float)visibleTiles.Y / 2.0f);

            actor.VelX = 0.0f;
            actor.VelY = 0.0f;

            float grafity = 0.5f;
            actor.NewPosY += grafity;
            

            // Clamp camera
            if (offset.X < 0) offset.X = 0;
            if (offset.Y < 0) offset.Y = 0;
            if (offset.X > Level1.TilesX - visibleTiles.X) offset.X = Level1.TilesX - visibleTiles.X;
            if (offset.Y > Level1.TilesY - visibleTiles.Y) offset.Y = Level1.TilesY - visibleTiles.Y;
            
            // Clamp actor
            if (actor.NewPosX < 0) actor.NewPosX = 0;
            if (actor.NewPosY < 0) actor.NewPosY = 0;
            if (actor.NewPosX > Level1.TilesX - 1) actor.NewPosX = Level1.TilesX - 1;
            if (actor.NewPosY > Level1.TilesY - 1) actor.NewPosY = Level1.TilesY - 1;

            // Collission detection
            if (Level1.getTile((int)actor.NewPosX, (int)actor.NewPosY) == '#') {
                actor.NewPosX = actor.PosX;
                actor.NewPosY = actor.PosY;
            }

            float TileOffsetX = (offset.X - (int)offset.X) * Level1.TilesX;
		    float TileOffsetY = (offset.Y - (int)offset.Y) * Level1.TilesY;

            // Update actor position
            actor.PosX = actor.NewPosX;
            actor.PosY = actor.NewPosY;

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

          spriteBatch.Draw(actor.Sprite, new Vector2((actor.PosX - offset.X) * Level1.TileWidth, (actor.PosY - offset.Y) * Level1.TileHeight), Color.White);

          spriteBatch.End();
          // TODO: Add your drawing code here

          base.Draw(gameTime);
        }
    }
}
