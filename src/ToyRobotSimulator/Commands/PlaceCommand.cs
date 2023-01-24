namespace ToyRobotSimulator.Commands
{
    public class PlaceCommand : RobotCommand
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        public RobotOrientation? RobotOrientation { get; set; }

        public PlaceCommand(int xPosition, int yPosition, RobotOrientation? orientation) : base(RobotCommandType.Place, null)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            RobotOrientation = orientation;
        }
    }
}