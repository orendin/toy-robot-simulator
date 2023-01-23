namespace ToyRobotSimulator
{
    public struct RobotCommand
    {
        public RobotCommandType CommandType { get; set; }
        public string? ErrorMessage { get; set; }

        private RobotCommand(RobotCommandType commandType, string? errorMessage = null)
        {
            CommandType = commandType;
            ErrorMessage = errorMessage;
        }

        public static RobotCommand Invalid(string errorMessage)
        {
            return new RobotCommand(RobotCommandType.Invalid, errorMessage);
        }

        public static RobotCommand Valid(RobotCommandType robotCommandType)
        {
            return new RobotCommand(robotCommandType);
        }
    }
}