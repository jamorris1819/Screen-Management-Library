using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Screen_Management_Library.Controls
{
    public class LinkLabel : Control
    {
        Color selectedColor = Color.Gray;

        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        public LinkLabel()
        {
            TabStop = true;
            HasFocus = false;
            Position = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            hasFocus = (new Rectangle((int)position.X, (int)position.Y, (int)spriteFont.MeasureString(text).X, (int)spriteFont.MeasureString(text).Y).Intersects(
                InputHandler.Mouse));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (hasFocus)
                spriteBatch.DrawString(SpriteFont, Text, Position, SelectedColor);
            else
                spriteBatch.DrawString(SpriteFont, Text, Position, Color);
        }

        public override void HandleInput()
        {
            if (!HasFocus)
                return;
            if (InputHandler.LeftMouseReleased())
                base.OnSelected(null);
        }
    }
}
