using System;

namespace MyGame
{
  public class VisibleTiles
  {
    public int X {get; set;}
    public int Y {get; set;}

    public VisibleTiles(int screenWidth, int screenHeight, int tileWidth, int tileHeight) {
      X = screenWidth / tileWidth;
      Y = screenHeight / tileHeight;
    }

  }

}