using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroMouse.Library
{
    public class Mouse
    {
        Maze _maze;
        int[,] _floodValues;
        bool[,] _visitValues;
        
        public List<Direction> directionsTakenByMouse = new List<Direction>();
        public event Action<Direction> Moved;
        public event Action SetCursorPosition;

        public int LocationRow { get; private set; }
        public int LocationColumn { get; private set; }

        public Mouse(Maze maze)
        {
            _maze = maze;
            int numberOfRows = (maze.objects.GetLength(0) - 1) / 2;
            int numberOfColumns = (maze.objects.GetLength(1) - 1) / 2;
            _floodValues = new int[numberOfRows, numberOfColumns];
            _visitValues = new bool[numberOfRows, numberOfColumns];

            for (int i = 0; i < 5;i++ )
            {
                for (int j = 0; j < 5; j++)
                {
                    _visitValues[i, j] = false;
                    _floodValues[i, j] = (maze.FinalRowIndex - i) + (maze.FinalColumIndex - j);
                }
            }
            LocationRow = maze.InitialRowIndex;
            LocationColumn = maze.InitialColumnIndex;
        }

        public void SolveMaze()
        {
            while(LocationRow != _maze.FinalRowIndex||LocationColumn !=_maze.FinalColumIndex)
            {
                List<Direction> directions = new List<Direction> { Direction.North, Direction.East, Direction.South, Direction.West };
                Dictionary<Direction, int> floodAndVisitValues = new Dictionary<Direction, int>();
                
                foreach (var direction in directions)
                {
                    bool wallExists = _maze.DoesWallExist(direction);
                    if (!wallExists)
                    {
                        const int VisitValueWeight = 1;
                        const int FloodValueWeightFactor = 10;
                        var floodAndVisitvalue = GetFloodValueOfAdjacentCellInDirection(direction) * FloodValueWeightFactor;
                        if (GetVisitValueOfAdjacentCellInDirection(direction))
                            floodAndVisitvalue = floodAndVisitvalue + VisitValueWeight;
                        floodAndVisitValues.Add(direction, floodAndVisitvalue);
                    }

                }

                var sortedFloodValues = floodAndVisitValues.OrderBy(x => x.Value).ToList();
                var directionToGo = sortedFloodValues.ElementAt(0).Key;
                
                if (GetCurrentCellFloodValue() <= GetFloodValueOfAdjacentCellInDirection(directionToGo))
                {
                    _floodValues[LocationRow, LocationColumn] = GetFloodValueOfAdjacentCellInDirection(directionToGo) + 1;
                }

                Go(directionToGo);
            }
            if (SetCursorPosition != null) SetCursorPosition();
            _maze.AssertDestinationReached();
        }

        private void Go(Direction direction)
        {
            if (direction == Direction.North) LocationRow--;
            else if (direction == Direction.South) LocationRow++;
            else if (direction == Direction.East) LocationColumn++;
            else if (direction == Direction.West) LocationColumn--;
            _visitValues[LocationRow, LocationColumn] = true;
            _maze.Go(direction);
            directionsTakenByMouse.Add(direction);
            if(Moved!=null) Moved(direction);
        }

        private bool DoesWallExist(Direction direction)
        {
            return _maze.DoesWallExist(direction);
        }

        private void GetCoorinatesofAdjacentCellInDirection(Direction direction, out int row, out int column)
        { 
            var nextRowIndex = LocationRow;
            var nextColumnIndex = LocationColumn;
            if (direction == Direction.North) nextRowIndex = LocationRow - 1;
            if (direction == Direction.South) nextRowIndex = LocationRow + 1;
            if (direction == Direction.East) nextColumnIndex = LocationColumn + 1;
            if (direction == Direction.West) nextColumnIndex = LocationColumn - 1;
            row = nextRowIndex;
            column = nextColumnIndex;
        }

        private int GetFloodValueOfAdjacentCellInDirection(Direction direction)
        {
            int nextRowIndex = 0;
            int nextColumnIndex = 0;
            GetCoorinatesofAdjacentCellInDirection(direction, out nextRowIndex, out nextColumnIndex);
            return _floodValues[nextRowIndex, nextColumnIndex];
        }

        private bool GetVisitValueOfAdjacentCellInDirection(Direction direction)
        {
            int nextRowIndex = 0;
            int nextColumnIndex = 0;
            GetCoorinatesofAdjacentCellInDirection(direction, out nextRowIndex, out nextColumnIndex);
            return _visitValues[nextRowIndex, nextColumnIndex];
        }

        private int GetCurrentCellFloodValue()
        {
            return _floodValues[LocationRow, LocationColumn];
        }
    }

}
