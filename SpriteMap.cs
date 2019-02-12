using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame {

  public class SpriteMap {

    public Texture2D Texture {get; set;}
    public int Columns {get; set;}
    public int Rows {get; set;}

    private int _tileWidth;

    private int _tileHeight;

    public SpriteMap(Texture2D texture, int columns, int rows)
    {
      Columns = columns;
      Rows = rows;
      Texture = texture;
      _tileWidth = Texture.Width / Columns;
      _tileHeight = Texture.Height / Rows;
    }

    public void getTile(int x, int y)
    {
      
    }

    public void getTiles(int x, int y, int cols, int rows)
    {

    }

    public void Draw(SpriteBatch spriteBatch, int column, int row,  Vector2 location)
    {
      int width = Texture.Width / Columns;
      int height = Texture.Height / Rows;

      Rectangle sourceRectangle = new Rectangle(column * _tileWidth, row * _tileHeight, _tileWidth, _tileHeight);
      Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, _tileWidth, _tileHeight);

      spriteBatch.Begin();
      spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
      spriteBatch.End();
    }

  }

}