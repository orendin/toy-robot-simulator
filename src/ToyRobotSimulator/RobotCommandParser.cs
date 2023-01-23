using ToyRobotSimulator.Commands;

namespace ToyRobotSimulator
{
    public static class RobotCommandParser
    {
        public static RobotCommand Parse(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return RobotCommand.Invalid("Input string cannot be empty.");
            }

            if (string.Equals(input, "move", StringComparison.InvariantCultureIgnoreCase))
            {
                return RobotCommand.Valid(RobotCommandType.Move);
            }

            if (string.Equals(input, "left", StringComparison.InvariantCultureIgnoreCase))
            {
                return RobotCommand.Valid(RobotCommandType.Left);
            }

            if (string.Equals(input, "right", StringComparison.InvariantCultureIgnoreCase))
            {
                return RobotCommand.Valid(RobotCommandType.Right);
            }

            if (string.Equals(input, "report", StringComparison.InvariantCultureIgnoreCase))
            {
                return RobotCommand.Valid(RobotCommandType.Report);
            }

            if (input.Length >= 9 && string.Equals(input.Substring(0, 5), "place", StringComparison.InvariantCultureIgnoreCase))
            {
                return ParsePlaceCommand(input);
            }

            return RobotCommand.Invalid("Unsupported command. Try again.");
        }

        private static RobotCommand ParsePlaceCommand(string input)
        {
            RobotOrientation? orientation = null;
            int x, y = 0;

            var success =
                int.TryParse(input.Substring(6, 1), out x) &&
                int.TryParse(input.Substring(8, 1), out y);

            if (!success)
            {
                return RobotCommand.Invalid("Invalid place command. Try again.");
            }

            if (input.Length > 9)
            {
                orientation = TryParseOrientation(input);

                if (orientation == null)
                {
                    return RobotCommand.Invalid("Invalid place command. Try again.");
                }
            }

            return new PlaceCommand(x, y, orientation);
        }

        private static RobotOrientation? TryParseOrientation(string input)
        {
            var orientationInput = input.Substring(10);
            if (string.Equals(orientationInput, "north", StringComparison.InvariantCultureIgnoreCase))
            {
                return RobotOrientation.North;
            }

            if (string.Equals(orientationInput, "east", StringComparison.InvariantCultureIgnoreCase))
            {
                return RobotOrientation.East;
            }

            if (string.Equals(orientationInput, "south", StringComparison.InvariantCultureIgnoreCase))
            {
                return RobotOrientation.South;
            }

            if (string.Equals(orientationInput, "west", StringComparison.InvariantCultureIgnoreCase))
            {
                return RobotOrientation.West;
            }

            return null;
        }
    }
}