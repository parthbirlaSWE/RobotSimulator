using System;

namespace RobotSimulator
{
    public class Robot
    {


    // Robot's current position and facing direction
    public int XPosition { get; private set; }
    public int YPosition { get; private set; }
    public Direction FacingDirection { get; private set; }
    public bool IsPlaced { get; private set; }


        // Check if the given position is within the 5x5 table
        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < 5 && y >= 0 && y < 5;
        }


        // Place the robot on the table if the position is valid
        public void Place(int x, int y, Direction facing)
        {
            if (IsValidPosition(x, y))
            {
                XPosition = x;
                YPosition = y;
                FacingDirection = facing;
                IsPlaced = true;
            }
        }


        // Move the robot one unit forward if possible
        public void Move()
        {
            if (!IsPlaced) return;

            int nextX = XPosition, nextY = YPosition;

            switch (FacingDirection)
            {
                case Direction.NORTH:
                    nextY++;
                    break;
                case Direction.SOUTH:
                    nextY--;
                    break;
                case Direction.EAST:
                    nextX++;
                    break;
                case Direction.WEST:
                    nextX--;
                    break;
            }

            if (IsValidPosition(nextX, nextY))
            {
                XPosition = nextX;
                YPosition = nextY;
            }
            else
            {
                Console.WriteLine("Move ignored: would fall off the table.");
            }
        }


        // Rotate the robot 90 degrees to the left
        public void Left()
        {
            if (!IsPlaced) return;
            FacingDirection = (Direction)(((int)FacingDirection + 3) % 4);
        }


        // Rotate the robot 90 degrees to the right
        public void Right()
        {
            if (!IsPlaced) return;
            FacingDirection = (Direction)(((int)FacingDirection + 1) % 4);
        }


        // Print the robot's current position and direction
        public void Report()
        {
            if (!IsPlaced) return;
            Console.WriteLine($"{XPosition},{YPosition},{FacingDirection}");
        }
    }
}
