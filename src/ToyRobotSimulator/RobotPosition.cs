namespace ToyRobotSimulator
{
    public readonly struct RobotPosition
    {
        public int X { get; }
        public int Y { get; }

        public RobotPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public RobotPosition MoveNorth()
        {
            return new RobotPosition(X, Y + 1);
        }

        public RobotPosition MoveEast()
        {
            return new RobotPosition(X + 1, Y);
        }

        public RobotPosition MoveSouth()
        {
            return new RobotPosition(X, Y - 1);
        }

        public RobotPosition MoveWest()
        {
            return new RobotPosition(X - 1, Y);
        }
    }
}