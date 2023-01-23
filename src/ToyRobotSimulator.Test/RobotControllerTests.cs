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
        public void Test_Basic_Commands()
        {

        }
    }
}