using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MyGame
{

  class Actor{
    public Texture2D Sprite {get; set;}

    public float VelX {get; set;}
    public float VelY {get; set;}

    public float PosX {get; set;}
    public float PosY {get; set;}

    private float walkSpeed = 4.0f;

    public Actor(int _x = 0, int _y = 0)
    {
      PosX = _x;
      PosY = _y;
    }

  }

}