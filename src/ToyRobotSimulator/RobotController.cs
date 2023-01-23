using ToyRobotSimulator.Commands;

namespace ToyRobotSimulator
{
    public class RobotController
    {
        private Dimensions TableDimensions { get; set; } = new Dimensions(6, 6);
        private Robot RobotA { get; set; }

        public RobotController()
        {
            RobotA = new Robot(Guid.NewGuid().ToString());
        }

        public string? TryExecuteCommand(RobotCommand maybeCommand)
        {
            if (maybeCommand == null)
            {
                return "Empty command not supported.";
            }

            if (maybeCommand.CommandType == RobotCommandType.Invalid)
            {
                return $"{maybeCommand.ErrorMessage}";
            }

            ValidationResult validationResult;
            string? stringResult = null;

            switch (maybeCommand.CommandType)
            {
                case RobotCommandType.Move:
                    if (RobotA.IsPlaced)
                    {
                        validationResult = TryExecute(r => r.MoveOne());
                        stringResult = validationResult.ToString();
                    }
                    break;
                case RobotCommandType.Left:
                    if (RobotA.IsPlaced)
                    {
                        validationResult = TryExecute(r => r.TurnLeft());
                        stringResult = validationResult.ToString();
                    }
                    break;
                case RobotCommandType.Right:
                    if (RobotA.IsPlaced)
                    {
                        validationResult = TryExecute(r => r.TurnRight());
                        stringResult = validationResult.ToString();
                    }
                    break;
                case RobotCommandType.Place:
                    var placeCommand = maybeCommand as PlaceCommand;
                    if (!RobotA.IsPlaced && !placeCommand.RobotOrientation.HasValue)
                    {
                        break; //ignore first place command if orientation is missing
                    }

                    validationResult = TryExecute(r => r.SetPosition(new RobotPosition(placeCommand.XPosition, placeCommand.YPosition)));
                    if (validationResult.IsValid && placeCommand.RobotOrientation.HasValue)
                    {
                        RobotA.OrientTo(placeCommand.RobotOrientation.Value);
                    }
                    stringResult = validationResult.ToString();
                    break;
                case RobotCommandType.Report:
                    stringResult = RobotA.Report();
                    break;
                default:
                    break;
            }

            return stringResult;
        }

        private ValidationResult TryExecute(Action<Robot> action)
        {
            var simulatedRobot = RobotA.Clone();
            action.Invoke(simulatedRobot);

            var simulationResult = ValidateConstraints(simulatedRobot);

            if (simulationResult.IsValid)
            {
                action.Invoke(RobotA);
            }

            return simulationResult;
        }

        private ValidationResult ValidateConstraints(Robot robot)
        {
            if (robot != null && robot.CurrentPosition.HasValue &&
                robot.CurrentPosition.Value.X < TableDimensions.Width &&
                robot.CurrentPosition.Value.Y < TableDimensions.Height &&
                robot.CurrentPosition.Value.X >= 0 &&
                robot.CurrentPosition.Value.Y >= 0
                )
            {
                return ValidationResult.Success();
            }
            else
            {
                return ValidationResult.Failure("Command would result in an invalid state, so command was skipped.");
            }
        }
    }
}