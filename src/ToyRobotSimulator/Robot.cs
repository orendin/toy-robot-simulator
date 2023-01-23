namespace ToyRobotSimulator
{
    public class Robot
    {
        public string Id { get; set; }
        public RobotPosition? CurrentPosition { get; private set; }
        public RobotOrientation? CurrentOrientation { get; private set; }
        public bool IsPlaced => CurrentPosition.HasValue;

        public Robot(string id)
        {
            Id = id;
        }

        public Robot Clone() {
            var clone = new Robot(Id)
            {
                CurrentPosition = CurrentPosition,
                CurrentOrientation = CurrentOrientation
            };

            return clone;
        }

        public void MoveOne()
        {
            if (IsPlaced)
            {
                switch (CurrentOrientation)
                {
                    case RobotOrientation.North: CurrentPosition = CurrentPosition.Value.MoveNorth();
                        break;
                    case RobotOrientation.East:
                        CurrentPosition = CurrentPosition.Value.MoveEast();
                        break;
                    case RobotOrientation.South:
                        CurrentPosition = CurrentPosition.Value.MoveSouth();
                        break;
                    case RobotOrientation.West:
                        CurrentPosition = CurrentPosition.Value.MoveWest();
                        break;
                    default:
                        break;
                }
            }
        }

        public void OrientTo(RobotOrientation orientation)
        {
            if (IsPlaced)
            {
                CurrentOrientation = orientation;
            }
        }

        public void TurnLeft()
        {
            if (IsPlaced)
            {
                switch (CurrentOrientation)
                {
                    case RobotOrientation.North:
                        CurrentOrientation = RobotOrientation.West;
                        break;
                    case RobotOrientation.East:
                        CurrentOrientation = RobotOrientation.North;
                        break;
                    case RobotOrientation.South:
                        CurrentOrientation = RobotOrientation.East;
                        break;
                    case RobotOrientation.West:
                        CurrentOrientation = RobotOrientation.South;
                        break;
                    default:
                        break;
                }
            }
        }

        public void TurnRight()
        {
            if (IsPlaced)
            {
                switch (CurrentOrientation)
                {
                    case RobotOrientation.North:
                        CurrentOrientation = RobotOrientation.East;
                        break;
                    case RobotOrientation.East:
                        CurrentOrientation = RobotOrientation.South;
                        break;
                    case RobotOrientation.South:
                        CurrentOrientation = RobotOrientation.West;
                        break;
                    case RobotOrientation.West:
                        CurrentOrientation = RobotOrientation.North;
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetPosition(RobotPosition position)
        {
            CurrentPosition = position;
        }

        public string Report()
        {
            var orientation = string.Empty;
            if (!IsPlaced)
            {
                return "Robot has not been placed.";
            }

            if (CurrentOrientation.HasValue)
            {
                orientation = Enum.GetName(typeof(RobotOrientation), CurrentOrientation.Value);
            }
            
            return $"{CurrentPosition?.X},{CurrentPosition?.Y},{orientation?.ToUpper()}";
        }
    }
}