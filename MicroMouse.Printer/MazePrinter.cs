using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroMouse.Library;

namespace MicroMouse.Printer
{
    public class MazePrinter
    {
        Mouse _mouse;
        Maze _maze;
        List<Direction> _directionsTakenByMouse = new List<Direction>();
        public MazePrinter(Mouse mouse, Maze maze)
        {
            _mouse = mouse;
            _maze = maze;
            _directionsTakenByMouse = mouse.directionsTakenByMouse;
            _mouse.Moved += (direction) => PrintCurrentState();
            _mouse.SetCursorPosition+=SetMazeSolvedStatusPosition;
        }

        public void PrintDirectionsTakenByMouseToReachDestination()
        {
            foreach(var direction in _directionsTakenByMouse)
            {
                Console.WriteLine(direction);
            }
        }

        private void PrintCurrentState()
        {
            Console.Clear();
            PrintMazeInfo(_maze);
            PrintVisitedCell(_mouse.LocationRow, _mouse.LocationColumn);
            System.Threading.Thread.Sleep(500);
        }

        private void SetMazeSolvedStatusPosition()
        {
            Console.SetCursorPosition(0, 11);
        }

        private void PrintVisitedCell(int visitedCellRowIndex, int visitedCellColumnIndex)
        {
            Console.SetCursorPosition((visitedCellColumnIndex * 2 + 1), (visitedCellRowIndex * 2 + 1));
            Console.Write("*");
        }

        private void PrintMazeInfo(MicroMouse.Library.Maze maze)
        {

            for (int x = 0; x < 11; x++)
            {
                for (int y = 0; y < 11; y++)
                {
                    if (maze.objects[x, y] is Point) Console.Write(" ");
                    if (maze.objects[x, y] is Space) Console.Write(" ");
                    if (maze.objects[x, y] == null) Console.Write(" ");
                    if (maze.objects[x, y] is Wall)
                    {
                        if ((maze.objects[x, y] as Wall).HasOpening())
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write(x % 2 == 0 ? "-" : "|");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

    }

}
