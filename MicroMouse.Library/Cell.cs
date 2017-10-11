using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroMouse.Library
{
    public class Cell
    {

        Dictionary<Direction, Wall> cellWalls = new Dictionary<Direction, Wall>();

        public Cell(Wall northWall, Wall eastWall, Wall southWall, Wall westWall)
        {
            cellWalls.Add(Direction.North, northWall);
            cellWalls.Add(Direction.East, eastWall);
            cellWalls.Add(Direction.South, southWall);
            cellWalls.Add(Direction.West, westWall);
        }

        public bool IsWallOpen(Direction direction)
        {
            return cellWalls[direction].HasOpening();
        }
    }

}
