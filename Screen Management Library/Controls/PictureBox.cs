using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Screen_Management_Library.Controls
{
    public class PictureBox : Control
    {
        Texture2D image;
        Rectangle sourceRect;
        Rectangle destRect;

        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

        public Rectangle SourceRectangle
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        public Rectangle DestinationRectangle
        {
            get { return destRect; }
            set { destRect = value; }
        }

        public PictureBox(Texture2D image, Rectangle destination)
        {
            Image = image;
            DestinationRectangle = destination;
            SourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            Color = Color.White;
        }

        public PictureBox(Texture2D image, Vector2 pos)
        {
            Image = image;
            DestinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, image.Width, image.Height);
            SourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            Color = Color.White;
        }

        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            Image = image;
            DestinationRectangle = destination;
            SourceRectangle = source;
            Color = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, destRect, sourceRect, Color);
        }

        public override void HandleInput()
        {
        }

        public void SetPosition(Vector2 newPosition)
        {
            destRect = new Rectangle(
                (int)newPosition.X,
                (int)newPosition.Y,
                sourceRect.Width,
                sourceRect.Height);
        }
    }
}
