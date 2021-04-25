using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace Chiffer2
{
    internal static class Input
    {
        public static TouchCollection currentTouchState { private set; get; }
        public static TouchCollection previousTouchState { private set; get; }

        public static void GetState()
        {
            previousTouchState = currentTouchState;
            currentTouchState = TouchPanel.GetState(); ;
        }

        public static bool GetButton()
        {
            return currentTouchState.Count > 0;
        }

        public static bool GetButtonDown()
        {
            //bool temp = currentKeyState.IsKeyDown(key);
            //bool temp2 = previousKeyState.IsKeyDown(key);

            return currentTouchState.Count > 0 && previousTouchState.Count <= 0;
        }

        public static bool GetButtonUp()
        {
            return currentTouchState.Count <= 0 && previousTouchState.Count > 0;
        }

        public static bool RectangleContains(Rectangle rectangle)
        {
            for (int i = 0; i < currentTouchState.Count; i++)
            {
                if (rectangle.Contains(new Vector2(currentTouchState[i].Position.X, currentTouchState[i].Position.Y)))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool RectangleContainsPrevious(Rectangle rectangle)
        {
            for (int i = 0; i < previousTouchState.Count; i++)
            {
                if (rectangle.Contains(new Vector2(previousTouchState[i].Position.X, previousTouchState[i].Position.Y)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}