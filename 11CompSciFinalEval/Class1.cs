using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace _11CompSciFinalEval
{
    class snakeSquare : Label
    {
        public snakeSquare(int x, int y)
        {
            //Class created for the snake square piece
            //Set location for snake based on existing x and y coordinates 
            Location = new System.Drawing.Point(x, y);
            //Set the size to 20 by 20, same as food and timer and in line with number of columns and rows relative to count
            Size = new System.Drawing.Size(20, 20);
            //Sets colour of snake to lime green
            BackColor = System.Drawing.Color.LimeGreen;
        }
    }
}
