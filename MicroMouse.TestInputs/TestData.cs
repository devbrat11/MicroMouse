using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroMouse.Library;

namespace MicroMouse.LibraryTests
{
    public class TestData
    {
        static Wall ClosedWall = new Wall(false);
        static Wall OpenedWall = new Wall(true);
        static Space space = new Space();
        static Point FillerPont = new Point();
        static Space[,] spacs = new Space[5, 5];
        public int StartingRow { get; private set; }
        public int StartingColumn { get; private set; }
        public int DestinationRow { get; private set; }
        public int DestinationColumn { get; private set; }
        public Object[,] MazeConstructionObjects { get; private set; }
        public Direction[] MazeSolvingDirections { get; private set; }

        static public TestData TestMaze1()
        {
            InitialiseSpaceReference();
            Object[,] objects = new Object[,]
                {
                    {FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                    {ClosedWall,spacs[0,0],ClosedWall,spacs[0,1],ClosedWall,spacs[0,2],ClosedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],ClosedWall,spacs[0,1],OpenedWall,spacs[0,2],OpenedWall,spacs[0,3],ClosedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],ClosedWall,spacs[0,2],ClosedWall,spacs[0,3],ClosedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],ClosedWall,spacs[0,2],ClosedWall,spacs[0,3],ClosedWall,spacs[0,4],ClosedWall},
                    {FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],OpenedWall,spacs[0,2],OpenedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                };
            return new TestData
            {
                MazeConstructionObjects = objects,
                MazeSolvingDirections = new Direction[] 
                {
                    Direction.South,
                    Direction.South,
                    Direction.East,
                    Direction.West,
                    Direction.South,
                    Direction.East,
                    Direction.South,
                    Direction.East,
                    Direction.East,
                    Direction.East,
                },
                StartingRow = 0,
                StartingColumn = 0,
                DestinationRow = 4,
                DestinationColumn = 4,
            };

        }
        static public TestData TestMaze2()
        {
            InitialiseSpaceReference();
            Object[,] objects = new Object[,]
                 {
                    {FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                    {ClosedWall,spacs[0,0],ClosedWall,spacs[0,1],ClosedWall,spacs[0,2],ClosedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],ClosedWall,spacs[0,1],OpenedWall,spacs[0,2],OpenedWall,spacs[0,3],ClosedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],OpenedWall,spacs[0,2],ClosedWall,spacs[0,3],ClosedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],ClosedWall,spacs[0,2],ClosedWall,spacs[0,3],ClosedWall,spacs[0,4],ClosedWall},
                    {FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],OpenedWall,spacs[0,2],OpenedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                 };
            return new TestData
            {

                MazeConstructionObjects = objects,
                MazeSolvingDirections = new Direction[] 
                {
                    Direction.South,
                    Direction.South,
                    Direction.East,
                    Direction.East,
                    Direction.West,
                    Direction.East,
                    Direction.West,
                    Direction.West,
                    Direction.South,
                    Direction.East,
                    Direction.South,
                    Direction.East,
                    Direction.East,
                    Direction.East,
                },
                StartingRow = 0,
                StartingColumn = 0,
                DestinationRow = 4,
                DestinationColumn = 4,

            };
        }
        static public TestData TestMaze3()
        {
            InitialiseSpaceReference();
            Object[,] objects = new Object[,]
                {
                    {FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                    {ClosedWall,spacs[0,0],ClosedWall,spacs[0,1],OpenedWall,spacs[0,2],OpenedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],ClosedWall,spacs[0,1],ClosedWall,spacs[0,2],OpenedWall,spacs[0,3],ClosedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],ClosedWall,spacs[0,2],OpenedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],OpenedWall,spacs[0,2],ClosedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],OpenedWall,spacs[0,2],OpenedWall,spacs[0,3],ClosedWall,spacs[0,4],ClosedWall},
                    {FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                };
            return new TestData
            {
                MazeConstructionObjects = objects,
                MazeSolvingDirections = new Direction[] 
                {
                    Direction.South,
                    Direction.South,
                    Direction.East,
                    Direction.North,
                    Direction.North,
                    Direction.East,
                    Direction.East,
                    Direction.East,
                    Direction.South,
                    Direction.South,
                    Direction.West,
                    Direction.West,
                    Direction.South,
                    Direction.West,
                    Direction.West,
                    Direction.South,
                    Direction.East,
                    Direction.East,
                    Direction.East,
                    Direction.North,
                    Direction.East,
                    Direction.South,
                },
                StartingRow = 0,
                StartingColumn = 0,
                DestinationRow = 4,
                DestinationColumn = 4,
            };

        }
        static public TestData TestMaze4()
        {
            InitialiseSpaceReference();
            Object[,] objects = new Object[,]
                {
                    {FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],OpenedWall,spacs[0,2],OpenedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],ClosedWall,spacs[0,2],OpenedWall,spacs[0,3],ClosedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],ClosedWall,spacs[0,1],OpenedWall,spacs[0,2],ClosedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],ClosedWall,spacs[0,2],ClosedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,OpenedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                    {ClosedWall,spacs[0,0],OpenedWall,spacs[0,1],OpenedWall,spacs[0,2],OpenedWall,spacs[0,3],OpenedWall,spacs[0,4],ClosedWall},
                    {FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont,ClosedWall,FillerPont},
                };
            return new TestData
            {

                MazeConstructionObjects = objects,
                MazeSolvingDirections = new Direction[] 
                {
                    Direction.East,
                    Direction.East,
                    Direction.East,
                    Direction.East,
                    Direction.South,
                    Direction.South,
                    Direction.South,
                    Direction.West,
                    Direction.East,
                    Direction.North,
                    Direction.West,
                    Direction.North,
                    Direction.West,
                    Direction.South,
                    Direction.West,
                    Direction.South,
                    Direction.West,
                    Direction.South,
                    Direction.East,
                    Direction.East,
                    Direction.East,
                    Direction.East,
                },
                StartingRow = 0,
                StartingColumn = 0,
                DestinationRow = 4,
                DestinationColumn = 4,
            };
        }

        static private void InitialiseSpaceReference()
        {
            for(int i=0;i<spacs.GetLength(0);i++)
            {
                for(int j=0;j<spacs.GetLength(1);j++)
                {
                    spacs[i, j] = space;
                }
            }
        }
    }

}
