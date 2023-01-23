using Shouldly;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class RobotControllerTests
    {
        [TestMethod]
        [DataRow("PLACE 0,0,NORTH|MOVE|REPORT", "0,1,NORTH")]
        [DataRow("PLACE 0,0,NORTH|LEFT|REPORT", "0,0,WEST")]
        [DataRow("PLACE 1,2,EAST|MOVE|MOVE|LEFT|MOVE|REPORT", "3,3,NORTH")]
        [DataRow("PLACE 1,2,EAST|MOVE|LEFT|MOVE|PLACE 3,1|MOVE|REPORT", "3,2,NORTH")]
        [DataRow("PLACE 1,2,WEST|MOVE|MOVE|REPORT", "0,2,WEST")]
        [DataRow("PLACE 5,5,NORTH|MOVE|RIGHT|REPORT", "5,5,EAST")]
        [DataRow("PLACE 4,3|MOVE|LEFT|PLACE 1,0,SOUTH|MOVE|LEFT|LEFT|Move|REPORT", "1,1,NORTH")]
        public void Test_Basic_Commands(string input, string expectedOutput)
        {
            var controllerToTest = new RobotController();
            var stringCommandSequence = input.Split("|");
            var commandSequence = stringCommandSequence.Select(s => RobotCommandParser.Parse(s)).ToList();
            string? output = string.Empty;

            foreach (var command in commandSequence)
            {
                output = controllerToTest.TryExecuteCommand(command);
            }

            output.ShouldBe(expectedOutput);
        }
    }
}