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

            if (input.Length >= 5 && string.Equals(input.Substring(0, 4), "place", StringComparison.InvariantCultureIgnoreCase))
            {
                //todo implement Place parsing
                return RobotCommand.Valid(RobotCommandType.Place);
            }

            return RobotCommand.Invalid("Unsupported command. Try again");
        }
    }
}