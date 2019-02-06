using System;

namespace MyGame
{
  public class Camera
  {
    public float X {get; set;}
    public float Y {get; set;}

    public int Width {get; set;}
    public int Height {get; set;}

    public void reset()
    {
      X = 0;
      Y = 0;
    }

    

  }

}