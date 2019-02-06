using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MyGame
{

  class Actor{

    public Vector2 Position = new Vector2();
    public Texture2D Sprite;

    public float VelocityX {get; set;}
    public float VelocityY {get; set;}

    private float walkSpeed = 4.0f;

    public Actor(int _x = 0, int _y = 0)
    {
      Position.X = _x;
      Position.Y = _y;
    }

    public void moveLeft()
    {
      Position.X -= walkSpeed;
    }

    public void moveRight()
    {
      Position.X += walkSpeed;
    }

  }

}