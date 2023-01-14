namespace GameOfLife
{
    public class Game : IProcess
    {
        public static int axisXLimit = 50;
        public static int axisYLimit = 50;
        private static GameLogicProcess gameLogicProcess;

        public static void Main(string[] args) 
        {
            gameLogicProcess = new GameLogicProcess(axisYLimit, axisXLimit);
            var game = new Game();
            game.Start();
            game.Draw();

            while (true)
            {
                game.Update();
            }
        }

        public void Draw()
        {
            System.Console.Clear();
            gameLogicProcess.Draw();
            System.Console.WriteLine("(Enter) Next Cycle"); //TODO: | (R) Restart | (L) Load | (S) Save | (I) Import
        }

        public void Start()
        {
            gameLogicProcess.Start();
        }

        public void Update()
        {
            var input = System.Console.ReadKey();

            if (input.Key == ConsoleKey.Enter)
            {
                gameLogicProcess.Update();
                Draw();
            }
        }
    }
}