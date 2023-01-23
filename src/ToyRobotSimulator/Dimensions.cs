namespace ToyRobotSimulator
{
    public readonly struct Dimensions
    {
        public int Width { get; }
        public int Height { get; }

        public Dimensions(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}