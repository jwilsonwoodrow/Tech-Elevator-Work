using System;

namespace Shapes.Models
{
    /// <summary>
    /// A two-dimensional shape that can be drawn on the screen
    /// </summary>
    public class Shape2D
    {
        #region statics
        public static char edgeSymbol = '*';
        public static char fillSymbol = '*'; //'█';
        protected const double ASPECT_ADJUSTMENT = 0.45;
        #endregion

        #region Fields
        // A place to save the current color for restoring after the draw
        private ConsoleColor savedColor = ConsoleColor.White;
        #endregion

        #region Properties
        public ConsoleColor Color { get; set; }

        #endregion

        #region Constructors

        #endregion


        #region Public Methods

        #endregion

        #region Helper Methods
        protected void SetConsoleColor()
        {
            this.savedColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
        }

        protected void ResetConsoleColor()
        {
            Console.ForegroundColor = savedColor;
        }
        #endregion
    }
}

