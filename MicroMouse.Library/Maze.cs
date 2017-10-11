using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroMouse.Library
{
    public class Maze
    {
        public Object[,] objects;
        Cell[,] cells ;
        int currentRowIndex;
        int currentColumnIndex;

        public int InitialRowIndex { get; private set; }
        public int InitialColumnIndex { get; private set; }
        public int FinalRowIndex { get; private set; }
        public int FinalColumIndex { get; private set; }

        public Maze(int numberOfRows, int numberOfColumns,
            int startingRow, int startingColumn, int destinationRow, int destinationColumn,
            Object[,] mazeObjects)
        {
            objects = mazeObjects;
            cells = new Cell[numberOfRows, numberOfColumns];
            currentRowIndex = startingRow;
            currentColumnIndex = startingColumn;
            InitialRowIndex = startingRow;
            InitialColumnIndex = startingColumn;
            FinalRowIndex = destinationColumn;
            FinalColumIndex = destinationRow;

            for (int i = 0; i < numberOfRows*2+1; i++)
            {
                for (int j = 0; j < numberOfColumns*2+1; j++)
                {
                    if (objects[i, j] is Space || objects[i, j] == null)
                    {
                        cells[i / 2, j / 2] = new Cell(
                        northWall: (Wall)objects[i - 1, j],
                        eastWall: (Wall)objects[i, j + 1],
                        southWall: (Wall)objects[i + 1, j],
                        westWall: (Wall)objects[i, j - 1]);
                    }

                }
            }
        }

        public void Go(Direction direction)
        {
            
            if (cells[currentRowIndex, currentColumnIndex].IsWallOpen(direction))
            {
                if (direction == Direction.North) currentRowIndex--;
                if (direction == Direction.South) currentRowIndex++;
                if (direction == Direction.East) currentColumnIndex++;
                if (direction == Direction.West) currentColumnIndex--;
            }
            else
            {
                throw new Exception("You banged a wall");
            }

        }

        public bool AssertDestinationReached()
        {
            if (IsMazeSolved) return true;
            else throw new Exception("You are completely lost");
             
        }

        public bool DoesWallExist(Direction direction)
        {
            Cell currentCell = cells[currentRowIndex, currentColumnIndex];
            if (currentCell.IsWallOpen(direction)) return false;
            else return true;
        }

        private bool IsMazeSolved
        {
            get
            {
                if (currentColumnIndex == FinalRowIndex && currentRowIndex == FinalColumIndex) return true;
                else return false;
            }
        }
    }
}
