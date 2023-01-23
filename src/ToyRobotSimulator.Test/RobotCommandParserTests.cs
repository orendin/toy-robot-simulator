namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class RobotCommandParserTests
    {
        [TestMethod]
        [DataRow("PLACE 0,0,NORTH", RobotCommandType.Place, 0, 0, RobotOrientation.North)]
        public void Test_Basic_Parsing()
        {

        }
    }
}