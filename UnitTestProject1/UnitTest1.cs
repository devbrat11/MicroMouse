using System;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

using MicroMouse.Library;
using MicroMouse.LibraryTests;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        private static IEnumerable TestCases
        {
            get
            {
                yield return TestData.TestMaze1();
                yield return TestData.TestMaze2();
                yield return TestData.TestMaze3();
                yield return TestData.TestMaze4();
            }
        }

        [Test, TestCaseSource("TestCases")]
        public void TestMethod1(TestData testData)
        {
            int numberOfRows = (testData.MazeConstructionObjects.GetLength(0) - 1) / 2;
            int numberOfColumn = (testData.MazeConstructionObjects.GetLength(1) - 1) / 2;
            int startingRow = testData.StartingRow;
            int startingColumn = testData.StartingColumn;
            int destinationRow = testData.DestinationRow;
            int destinationColumn = testData.DestinationColumn;

            Maze maze = new Maze(numberOfRows, numberOfColumn, startingRow,
                startingColumn, destinationRow, destinationColumn, testData.MazeConstructionObjects);
            Mouse mouse = new Mouse(maze);

            mouse.SolveMaze();
            NUnit.Framework.Assert.Multiple(() =>
                {
                    NUnit.Framework.Assert.AreEqual(mouse.LocationRow,destinationRow);
                   // NUnit.Framework.Assert.AreEqual(mouse.LocationColumn, destinationColumn);
                    NUnit.Framework.CollectionAssert.AreEquivalent(testData.MazeSolvingDirections, mouse.directionsTakenByMouse);
                });
            

        }
    }
}

