using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace HotLine__Laba.Classes
{
    enum PlayerStatus
    {
        stay,go,die
    }
    enum Vector
    {
        up,down,left,righ,upRight,upLeft,downRight,downLeft
    }
    class Player
    {
        private Texture2D texture;
        private Texture2D texture2;
        private Vector2 position;
        private int speed;
        private Vector napravlenie;
        private PlayerStatus status;
        private float interval;
        private Texture2D stay;
        private Vector2 origin2;
        private int currentFrame;
        private int spriteWidth;
        private int spriteHeight;
        private bool rightOrLeft;
        private Rectangle sourceRectangle;
        int animeitPause;
        private Vector2 mapPosition;
        private int spriteWidth1;
        private int spriteHeight1;
        private float rotation;
        private int health;
        bool isUp = false;
        bool isDown = false;
        bool isLeft = false;
        bool isRight = true;

        private bool freecam;
        public Rectangle bound { get; set; }
    
      
     
        public Player(Vector2 pos)
        {
            napravlenie = Vector.righ;
            texture = null;
            texture2 = null;
            stay = null;
            position = pos;
            mapPosition = Vector2.Zero;
            speed = 3;
            status = PlayerStatus.go;
            freecam = ;
            origin2 = new Vector2(45/2, 29/2);
            spriteHeight = 29;
            spriteWidth = 45;
            spriteHeight1 = 33;
            spriteWidth1 = 26;
            currentFrame = 0;
            animeitPause = 3;
            rotation = 0f;
            rightOrLeft = true;

        }
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("right2");
            texture2 = content.Load<Texture2D>("right");
            stay = content.Load<Texture2D>("Stay_Player");
        }
        public void Draw(SpriteBatch brushe)
        {
            switch (status)
            {
                case PlayerStatus.stay:
                    brushe.Draw(stay, position, sourceRectangle, Color.White,
                       rotation, origin2, 1, SpriteEffects.None, 0);
                    break;
                case PlayerStatus.go:
                    if (rightOrLeft)
                    {
                        brushe.Draw(texture, position, sourceRectangle, Color.White,
                        rotation, origin2, 1, SpriteEffects.None, 0);
                    }
                    else
                    {
                        brushe.Draw(texture2, position, sourceRectangle, Color.White,
                        rotation, origin2, 1, SpriteEffects.None, 0);
                        
                    }
                    break;
                case PlayerStatus.die:
                    break;
                default:
                    break;
            }
            
               
            
        }
        public Vector2 Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

           

            if (keyboardState.IsKeyDown(Keys.W))
            {
                status = PlayerStatus.go;
                if (freecam)
                {
                    position.Y -= speed;
                }
                else
                {
                    mapPosition.Y += speed;
                }
                mapPosition.Y += speed;
                isDown = true;
                isUp = false;
                  
                
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                status = PlayerStatus.go;
                if (freecam)
                {
                    position.Y += speed;
                }
                else
                {
                    mapPosition.Y -= speed;
                }
                isDown = false;
                isUp = true;

            }
            else
            {
                status = PlayerStatus.go;
                isDown = false;
                isUp = false;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                status = PlayerStatus.go;
                if (freecam)
                {
                    position.X -= speed;
                }
                else
                {
                    mapPosition.X += speed;
                }
                isLeft = true;
                isRight = false;

            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                status = PlayerStatus.go;
                if (freecam)
                {
                    position.X += speed;
                }
                else
                {
                    mapPosition.X -= speed;
                }
                isRight = true;
                isLeft = false;

            }
            else
            {
                status = PlayerStatus.go;
                isRight = false;
                isLeft = false;
            }


            if (status==PlayerStatus.go)
            {
                if (isUp && isRight)
                {
                    napravlenie = Vector.upRight;
                    rotation = (float)(Math.PI / 4);


                }
                else if (isUp && isLeft)
                {
                    napravlenie = Vector.upLeft;
                    rotation = (float)(Math.PI * 0.75);

                }
                else if (isDown && isLeft)
                {
                    napravlenie = Vector.downLeft;
                    rotation = (float)(Math.PI * 1.25);
                }
                else if (isDown && isRight)
                {
                    napravlenie = Vector.downRight;
                    rotation = (float)(Math.PI * 1.75);
                }
                else if (isUp)
                {
                    napravlenie = Vector.up;
                    rotation = (float)(Math.PI / 2);
                }
                else if (isDown)
                {
                    napravlenie = Vector.down;
                    rotation = (float)(Math.PI * 1.5);

                }
                else if (isRight)
                {
                    napravlenie = Vector.righ;
                    rotation = 0f;
                }
                else if (isLeft)
                {
                    napravlenie = Vector.left;
                    rotation = (float)(Math.PI);

                }
                else
                {
                    status = PlayerStatus.stay;
                }
            }



            if (status==PlayerStatus.go)
            {
                if (rightOrLeft)
                {
                    sourceRectangle = new Rectangle(spriteWidth * currentFrame, 0, spriteWidth, spriteHeight);
                    if (animeitPause <= 0)
                    {
                        if (currentFrame < 9)
                        {
                            currentFrame++;

                        }
                        else
                        {
                            currentFrame = 0;
                            rightOrLeft = false;
                        }
                        animeitPause = 3;
                    }
                    animeitPause--;
                }
                else
                {
                    sourceRectangle = new Rectangle(spriteWidth * currentFrame, 0, spriteWidth, spriteHeight);
                    if (animeitPause <= 0)
                    {
                        if (currentFrame < 9)
                        {
                            currentFrame++;

                        }
                        else
                        {
                            currentFrame = 0;
                            rightOrLeft = true;
                        }
                        animeitPause = 3;
                    }
                    animeitPause--;
                }
            }
            

            if (status==PlayerStatus.stay)
            {
                sourceRectangle = new Rectangle( 0, spriteHeight1 * currentFrame, spriteWidth1, spriteHeight1);
                if (animeitPause <= 0)
                {
                    if (currentFrame < 5)
                    {
                        currentFrame++;

                    }
                    else
                    {
                        currentFrame = 0;
                        
                    }
                    animeitPause = 20;
                }
                animeitPause--;
            }
            return mapPosition;
        }
    }
}
