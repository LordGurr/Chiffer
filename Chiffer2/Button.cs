using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chiffer2
{
    internal class Button
    {
        public Rectangle rectangle { private set; get; }
        public Texture2D texture { private set; get; }
        public string text { private set; get; }
        public bool pressed { private set; get; }
        public Color color { private set; get; }

        public Button(Rectangle _rectangle, Texture2D _texture, string _text)
        {
            rectangle = _rectangle;
            texture = _texture;
            text = _text;
            pressed = false;
            color = Color.White;
        }

        public Button(Rectangle _rectangle, Texture2D _texture, string _text, Color _color)
        {
            rectangle = _rectangle;
            texture = _texture;
            text = _text;
            pressed = false;
            color = _color;
        }

        public bool Clicked()
        {
            if (pressed)
            {
                if (Input.GetButtonUp())
                {
                    if (Input.RectangleContainsPrevious(rectangle))
                    {
                        pressed = false;
                        return true;
                    }
                }
            }
            if (Input.GetButtonDown())
            {
                if (Input.RectangleContains(rectangle))
                {
                    pressed = true;
                }
            }
            else if (Input.GetButtonUp())
            {
                pressed = false;
            }
            return false;
        }

        public void setPos(int x, int y)
        {
            rectangle = new Rectangle(x, y, rectangle.Width, rectangle.Height);
            //rectangle.Y = y;
        }

        public void setPos(Vector2 pos)
        {
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, rectangle.Width, rectangle.Height);
            //rectangle.Y = y;
        }

        public void setSize(int width, int height)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y, width, height);
            //rectangle.Y = y;
        }

        public void setSize(Vector2 size)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y, (int)size.X, (int)size.Y);
            //rectangle.Y = y;
        }

        public void setRectangle(Rectangle _rectangle)
        {
            rectangle = _rectangle;
            //rectangle.Y = y;
        }

        public void Draw(SpriteBatch _spriteBatch, SpriteFont font/*, Vector3 offset*/)
        {
            //setPos(rectangle.X - (int)offset.X, rectangle.Y - (int)offset.Y);
            //_spriteBatch.Draw(texture, new Rectangle(rectangle.X - (int)offset.X, rectangle.Y - (int)offset.Y, rectangle.Width, rectangle.Height), Color.White);
            _spriteBatch.Draw(texture, rectangle, color);
            Vector2 size = font.MeasureString(text);
            _spriteBatch.DrawString(font, text, new Vector2(rectangle.X + rectangle.Width / 2 /*- offset.X*/, rectangle.Y + rectangle.Height / 2 /*- offset.Y*/), Color.White, 0, new Vector2(size.X / 2, size.Y / 2), 3, SpriteEffects.None, 1);
        }
    }
}