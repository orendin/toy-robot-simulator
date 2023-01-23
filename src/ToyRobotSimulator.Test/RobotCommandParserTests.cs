using Shouldly;
using ToyRobotSimulator.Commands;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class RobotCommandParserTests
    {
        [TestMethod]
        [DataRow("Left", RobotCommandType.Left, null, null, null)]
        [DataRow("MOVE", RobotCommandType.Move, null, null, null)]
        [DataRow("right", RobotCommandType.Right, null, null, null)]
        [DataRow("Report", RobotCommandType.Report, null, null, null)]
        [DataRow("SomethingElse", RobotCommandType.Invalid, null, null, null)]
        [DataRow("PLACE 0,0,NORTH", RobotCommandType.Place, 0, 0, RobotOrientation.North)]
        [DataRow("PLACE 5,3,east", RobotCommandType.Place, 5, 3, RobotOrientation.East)]
        [DataRow("PLACE 3,1,SoUTh", RobotCommandType.Place, 3, 1, RobotOrientation.South)]
        [DataRow("PLACE 8,9,west", RobotCommandType.Place, 8, 9, RobotOrientation.West)]
        [DataRow("PLACE 4,2", RobotCommandType.Place, 4, 2, null)]
        public void Test_Basic_Parsing(
            string input,
            RobotCommandType expectedCommand,
            int expectedXPosition,
            int expectedYPosition,
            RobotOrientation? expectedOrientation)
        {
            var result = RobotCommandParser.Parse(input);

            result.CommandType.ShouldBe(expectedCommand);

            if (result.CommandType == RobotCommandType.Place)
            {
                var placeCommand = result as PlaceCommand;

                placeCommand.ShouldNotBeNull();
                placeCommand.XPosition.ShouldBe(expectedXPosition);
                placeCommand.YPosition.ShouldBe(expectedYPosition);

                if (expectedOrientation != null)
                {
                    placeCommand.RobotOrientation.ShouldBe(expectedOrientation.Value);
                }
            }
        }
    }
}