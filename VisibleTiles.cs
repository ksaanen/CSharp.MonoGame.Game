using System;

namespace MyGame
{
  public class VisibleTiles
  {
    public int X;
    public int Y;

    public VisibleTiles(int screenWidth, int screenHeight, int tileWidth, int tileHeight) {
      X = screenWidth / tileWidth;
      Y = screenHeight / tileHeight;
    }

  }

}