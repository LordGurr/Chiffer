using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chiffer2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Button button;
        private SpriteFont font;
        private bool buttonPushed = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            int[] size = new int[] { Window.ClientBounds.Width / 5, Window.ClientBounds.Height / 10 };
            Rectangle rectangle = new Rectangle(Window.ClientBounds.Width / 2 - size[0] / 2, Window.ClientBounds.Height / 2 - size[1] / 2, size[0], size[1]);
            Texture2D square = Content.Load<Texture2D>("Square4");
            button = new Button(rectangle, square, "Halla!", Color.Orange);
            font = Content.Load<SpriteFont>("font");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (!buttonPushed)
            {
                if (button.Clicked())
                {
                    buttonPushed = true;
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            button.Draw(_spriteBatch, font);
            // TODO: Add your drawing code here
            if (buttonPushed)
            {
                string text = "Button pushed!";
                Vector2 size = font.MeasureString(text);
                _spriteBatch.DrawString(font, text, new Vector2(button.rectangle.X + button.rectangle.Width / 2 /*- offset.X*/, button.rectangle.Y + button.rectangle.Height / 2 + 100 /*- offset.Y*/), Color.White, 0, new Vector2(size.X / 2, size.Y / 2), 3, SpriteEffects.None, 1);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}