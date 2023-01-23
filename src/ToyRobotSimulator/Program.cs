namespace ToyRobotSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hi, welcome to the Toy Robot Simulator. Enter one of the following commands:");
                Console.WriteLine("'PLACE [X,Y,DIRECTION]', 'MOVE', 'LEFT', 'RIGHT', 'REPORT'");
                Console.WriteLine("Supported directions: 'NORTH', 'EAST', 'SOUTH', 'WEST'");
                Console.WriteLine("Supported X/Y coordinates: 0-5/0-5");
                Console.WriteLine("Write 'exit' or 'q' to quit.");

                var robotController = new RobotController();

                while (true)
                {
                    var input = Console.ReadLine();

                    var maybeCommand = RobotCommandParser.Parse(input);

                    var output = robotController.TryExecuteCommand(maybeCommand);

                    if (!string.IsNullOrEmpty(output)) {
                        Console.WriteLine(output);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.WriteLine("The program will exit.");
            }
        }
    }
}