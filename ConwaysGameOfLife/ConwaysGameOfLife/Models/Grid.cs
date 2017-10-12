using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConwaysGameOfLife.Models;
using System.Threading.Tasks;

namespace ConwaysGameOfLife.Models
{
    public class Grid
    {
        public int SizeX;
        public int SizeY;
        public bool[,] GridArray;

        public Grid(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.GridArray = new bool[this.SizeX, this.SizeY];
        }
    }
}
