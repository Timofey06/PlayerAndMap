using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace HotLine__Laba.Classes
{
    class Map
    {
        private Texture2D map;
        private int width;
        private int height;
        private Vector2 position;
        public Map()
        {
            map = null;
            position = Vector2.Zero;

        }
        public void LoadContent(ContentManager content)
        {
            map = content.Load<Texture2D>("unknown");

        }
        public void Update(Vector2 position)
        {
            this.position = position;
        }
        public void Draw(SpriteBatch brushe)
        {
            brushe.Draw(map,position,Color.White);
        }
    }
}
