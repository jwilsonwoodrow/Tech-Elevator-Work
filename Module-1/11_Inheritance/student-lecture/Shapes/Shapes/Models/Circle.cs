﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models {
    public class Circle : Shape2D
    {
        
        public int Radius { get; set; }


        public override int Area 
        {
            get {
                return (int)Math.Round(Math.PI * (this.Radius * this.Radius),0);
            }
        }
        public override int Perimeter 
        {
            get {
                return (int)Math.Round((2*Math.PI*this.Radius),0);
            }
        }

        public Circle (int x, int y, ConsoleColor color, bool isFIlled, int radius) : base (x,y,color,isFIlled)
        {
                this.Radius = radius;
        }

        public override string ToString()
        {
            return $"A {Color} Circle with radius {this.Radius}, at location ({X}, {Y})";
        }


        public override void Draw()
        {
            SetConsoleColor();
            // We calculate output for each line
            string output;
            // Calculate the top as a ratio of total height of the window
            int originY = (int)(this.Y * Console.WindowHeight / 100.0);
            int originX = (int)(this.X * Console.WindowWidth / 100.0);
            int radiusLines = (int)(this.Radius * Console.WindowHeight / 100.0);

            int secondX = (int)Math.Ceiling(Math.Sqrt(radiusLines * radiusLines - (radiusLines - 1) * (radiusLines - 1)) / ASPECT_ADJUSTMENT) * 2 + 1;

            // Move down the screen line by line (y) and calculate what to draw on each line
            for (int y = radiusLines; y >= -radiusLines; y--)
            {
                // Calculate the y line
                int yDraw = originY - y;
                Console.CursorTop = Math.Max(yDraw, 0);
                int deltaX = (int)Math.Ceiling(Math.Sqrt(radiusLines * radiusLines - y * y) / ASPECT_ADJUSTMENT);
                if (deltaX == 0)
                {
                    // Top or bottom line. We make a solid line half the length of the second line (rather than one character)
                    output = new string(edgeSymbol, (secondX / 2));
                    deltaX = output.Length / 2;
                } else // All lines except the first and last
                {
                    // given y, calculate x on the circle. Equation for a circle: x*x + y*y = r*r
                    // We know y, so solve for x:  x = Sqrt( r*r - y*y )
                    // But we have to fatten the circle, so we divide by the skew factor
                    output = edgeSymbol + new string(IsFilled ? fillSymbol : ' ', deltaX * 2 - 1) + edgeSymbol;
                }
                Console.CursorLeft = Math.Max(originX - deltaX, 0);
                Console.Write(output);
            }
            ResetConsoleColor();
        }

    }
}
