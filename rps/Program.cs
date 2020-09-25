using System;

namespace RPS
{
    class Program
    {
        static void Main(string[] args)
        {
            RpsGame();
        }
        enum Choice
        {
            rock,
            paper,
            scissor
        }
        enum GameResult
        {
            won,
            lost,
            draw
        }
        public static void RpsGame()
        {
            Console.WriteLine($"Please choose between {Choice.rock}, {Choice.paper} or {Choice.scissor}");
            string playerInput = Console.ReadLine();
            playerInput = playerInput.ToLower();
            if (playerInput == Choice.rock.ToString() || playerInput == Choice.paper.ToString() || playerInput == Choice.scissor.ToString())
            {
                Array values = Enum.GetValues(typeof(Choice));
                Random random = new Random();
                Choice randomChoice = (Choice)values.GetValue(random.Next(values.Length));
                const string r = nameof(Choice.rock), p = nameof(Choice.paper), s = nameof(Choice.scissor);

                switch (playerInput)
                {
                    case r:
                        switch (randomChoice)
                        {
                            case Choice.rock:
                                Restart(1, GameResult.draw, randomChoice);
                                break;
                            case Choice.paper:
                                Restart(0, GameResult.lost, randomChoice);
                                break;
                            case Choice.scissor:
                                Restart(0, GameResult.won, randomChoice);
                                break;
                        }
                        break;
                    case p:
                        switch (randomChoice)
                        {
                            case Choice.rock:
                                Restart(0, GameResult.won, randomChoice);
                                break;
                            case Choice.paper:
                                Restart(1, GameResult.draw, randomChoice);
                                break;
                            case Choice.scissor:
                                Restart(0, GameResult.lost, randomChoice);
                                break;
                        }
                        break;
                    case s:
                        switch (randomChoice)
                        {
                            case Choice.rock:
                                Restart(0, GameResult.lost, randomChoice);
                                break;
                            case Choice.paper:
                                Restart(0, GameResult.won, randomChoice);
                                break;
                            case Choice.scissor:
                                Restart(1, GameResult.draw, randomChoice);
                                break;
                        }
                        break;
                }
            }
            else { Restart(2); }
        }
        private static void Restart(int type, GameResult? gameResult = null, Choice? randomChoice = null)
        {
            string restartText = "";
            switch (type)
            {
                case 2:
                    restartText = "The choice you entered isn't a correct one. Press any key to reset";
                    break;
                case 1:
                    restartText = $"Computer Choose: {randomChoice}\nIt's a {gameResult}. Please press any key to reset";
                    break;
                case 0:
                    restartText = $"Computer Choose: {randomChoice}\nYou {gameResult}. Please press any key to reset";
                    break;
            }
            Console.WriteLine(restartText);
            Console.ReadKey();
            Console.Clear();
            RpsGame();
        }
    }
}