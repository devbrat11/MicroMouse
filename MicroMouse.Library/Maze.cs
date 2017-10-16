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
        Cell[,] cells;
        int currentRowIndex;
        int currentColumnIndex;

        public int InitialRowIndex { get; private set; }
        public int InitialColumnIndex { get; private set; }
        public int FinalRowIndex { get; private set; }
        public int FinalColumnIndex { get; private set; }

        public Maze(int numberOfRows, int numberOfColumns,
            int startingRow, int startingColumn, int destinationRow, int destinationColumn,
            Object[,] mazeObjects)
        {
            objects = mazeObjects;
            cells = new Cell[numberOfRows, numberOfColumns];
            if (startingRow > -1 && startingRow < numberOfRows )
            {
                currentRowIndex = startingRow;
                InitialRowIndex = startingRow;
            }
            else
                throw new ArgumentOutOfRangeException("Starting Row Index is not within the range of the board");
            
            if(startingColumn>-1&&startingColumn<numberOfColumns)
            {

                currentColumnIndex = startingColumn;
                InitialColumnIndex = startingColumn;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Starting Column Index is not within the range of the board");
            }

            if (destinationColumn > -1 && destinationColumn < numberOfColumns) FinalRowIndex = destinationColumn;
            else throw new ArgumentOutOfRangeException("Destination Column Index is not within the range of the board");

            if (destinationRow > -1 && destinationRow < numberOfColumns) FinalColumnIndex = destinationRow;
            else throw  new ArgumentOutOfRangeException("Destination Row Index is not within the range of the board");
            
            for (int i = 0; i < numberOfRows * 2 + 1; i++)
            {
                for (int j = 0; j < numberOfColumns * 2 + 1; j++)
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

        public void AssertDestinationReached()
        {
            if (IsMazeSolved) return;
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
                if (currentColumnIndex == FinalRowIndex && currentRowIndex == FinalColumnIndex) return true;
                else return false;
            }
        }
    }
}
