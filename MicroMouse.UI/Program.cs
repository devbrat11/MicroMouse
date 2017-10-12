using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroMouse.Library;
using MicroMouse.Printer;
using MicroMouse.LibraryTests;

namespace MicroMouse.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            TestData testData = TestData.TestMaze4();
            Object[,] mazeObjects = testData.MazeConstructionObjects;
            int numberOfRows = (mazeObjects.GetLength(0) - 1) / 2;
            int numberOfColumn = (mazeObjects.GetLength(1) - 1) / 2;
            int startingRow = testData.StartingRow;
            int startingColumn = testData.StartingColumn;
            int destinationRow = testData.DestinationRow;
            int destinationColumn = testData.DestinationColumn;
            
            Maze maze = new Maze(numberOfRows, numberOfColumn, startingRow,
                startingColumn, destinationRow, destinationColumn, mazeObjects);
            Mouse mouse = new Mouse(maze);
            var printer = new MazePrinter(mouse, maze);
            
            try
            {
                mouse.SolveMaze();
                Console.WriteLine("You have succeeded!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("You have failed!");
            }
            printer.PrintDirectionsTakenByMouseToReachDestination();
        }
    }
}
