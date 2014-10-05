using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Screen_Management_Library
{
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;
        static MouseState mouseState;
        static MouseState lastMouseState;

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        public static MouseState MouseState
        {
            get { return mouseState; }
        }

        public static MouseState LastMouseState
        {
            get { return lastMouseState; }
        }

        public static Rectangle Mouse
        {
            get
            {
                return new Rectangle(Microsoft.Xna.Framework.Input.Mouse.GetState().X,
                    Microsoft.Xna.Framework.Input.Mouse.GetState().Y, 2, 2);
            }
        }

        public InputHandler(Game game)
            : base(game)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            lastMouseState = mouseState;
            mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            
            base.Update(gameTime);
        }

        public static void Flush()
        {
            lastKeyboardState = keyboardState;
            lastMouseState = mouseState;
        }

        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        public static bool LeftMouseReleased()
        {
            return (mouseState.LeftButton == ButtonState.Released) && (lastMouseState.LeftButton == ButtonState.Pressed);
        }

        public static bool LeftMousePressed()
        {
            return (mouseState.LeftButton == ButtonState.Pressed) && (lastMouseState.LeftButton == ButtonState.Released);
        }

        public static bool LeftMouseDown()
        {
            return (mouseState.LeftButton == ButtonState.Pressed);
        }
    }
}
