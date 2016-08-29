namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private const char Mine = '*';

        private static void Main()
        {
            const int FieldsWithoutMines = 35;
            string command = string.Empty;
            char[,] field = CreateBoard();
            char[,] bombite = CreateMines();
            int pointsCounter = 0;
            int row = 0;
            int col = 0;
            bool isMine = false;
            bool isStartOfGame = true;
            bool isEndOfGame = false;
            List<Score> scoreChart = new List<Score>(6);

            do
            {
                if (isStartOfGame)
                {
                    Console.WriteLine("Let's play Minesweeper. Try to find all fields without mines. " +
                        "Top shows the current Score-chart, Restart starts a new game, Exit quits the game.");
                    PrintBoard(field);
                    isStartOfGame = false;
                }

                Console.Write("Please enter row and col: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        (row <= field.GetLength(0) && col <= field.GetLength(1)))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ScoreChart(scoreChart);
                        break;

                    case "restart":
                        field = CreateBoard();
                        bombite = CreateMines();
                        PrintBoard(field);
                        isMine = false;
                        isStartOfGame = false;
                        break;

                    case "exit":
                        Console.WriteLine("Exiting the game");
                        break;

                    case "turn":
                        if (bombite[row, col] != Mine)
                        {
                            if (bombite[row, col] == '-')
                            {
                                CalculateFieldValue(field, bombite, row, col);
                                pointsCounter++;
                            }

                            if (FieldsWithoutMines == pointsCounter)
                            {
                                isEndOfGame = true;
                            }
                            else
                            {
                                PrintBoard(field);
                            }
                        }
                        else
                        {
                            isMine = true;
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

                if (isMine)
                {
                    PrintBoard(bombite);

                    Console.Write($"Your score is {pointsCounter}. Please type your name: ");

                    string name = Console.ReadLine();

                    Score playersScore = new Score(name, pointsCounter);

                    if (scoreChart.Count < 5)
                    {
                        scoreChart.Add(playersScore);
                    }
                    else
                    {
                        for (int i = 0; i < scoreChart.Count; i++)
                        {
                            if (scoreChart[i].Points < playersScore.Points)
                            {
                                scoreChart.Insert(i, playersScore);
                                scoreChart.RemoveAt(scoreChart.Count - 1);
                                break;
                            }
                        }
                    }

                    scoreChart.Sort((Score firstResult, Score secondResult) => secondResult.Name.CompareTo(firstResult.Name));
                    scoreChart.Sort((Score firstResult, Score secondResult) => secondResult.Points.CompareTo(firstResult.Points));
                    ScoreChart(scoreChart);

                    field = CreateBoard();
                    bombite = CreateMines();
                    pointsCounter = 0;
                    isMine = false;
                    isStartOfGame = true;
                }

                if (isEndOfGame)
                {
                    Console.WriteLine("You are the winner!");
                    PrintBoard(bombite);
                    Console.WriteLine("Please enter your name: ");
                    string playerName = Console.ReadLine();
                    Score playerScore = new Score(playerName, pointsCounter);
                    scoreChart.Add(playerScore);
                    ScoreChart(scoreChart);
                    field = CreateBoard();
                    bombite = CreateMines();
                    pointsCounter = 0;
                    isEndOfGame = false;
                    isStartOfGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        private static void ScoreChart(List<Score> score)
        {
            Console.WriteLine("Score:");

            if (score.Count > 0)
            {
                for (int i = 0; i < score.Count; i++)
                {
                    int pointsCount = i + 1;
                    string pointsName = score[i].Name;
                    int scorePoints = score[i].Points;

                    Console.WriteLine($"{pointsCount}. {pointsName} --> {scorePoints} fields.");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The score is empty.");
            }
        }

        private static void CalculateFieldValue(char[,] board, char[,] mines, int row, int col)
        {
            char calculateMines = CalculateMines(mines, row, col);

            mines[row, col] = calculateMines;
            board[row, col] = calculateMines;
        }

        private static void PrintBoard(char[,] board)
        {
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);

                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format($"{board[row, col]} "));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateBoard()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] CreateMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    board[row, col] = '-';
                }
            }

            List<int> mines = new List<int>();

            while (mines.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);

                if (!mines.Contains(randomNumber))
                {
                    mines.Add(randomNumber);
                }
            }

            foreach (int mine in mines)
            {
                int col = mine / cols;
                int row = mine % cols;

                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = Mine;
            }

            return board;
        }

        private static void CalculateFieldValues(char[,] board)
        {
            int cols = board.GetLength(0);
            int rows = board.GetLength(1);

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (board[i, j] != Mine)
                    {
                        char result = CalculateMines(board, i, j);
                        board[i, j] = result;
                    }
                }
            }
        }

        private static char CalculateMines(char[,] board, int row, int col)
        {
            int count = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            int upperRow = row - 1;
            int lowerRow = row + 1;
            int leftCol = col - 1;
            int rightCol = col + 1;

            if (upperRow >= 0)
            {
                if (board[upperRow, col] == Mine)
                {
                    count++;
                }
            }

            if (lowerRow < rows)
            {
                if (board[lowerRow, col] == Mine)
                {
                    count++;
                }
            }

            if (leftCol >= 0)
            {
                if (board[row, leftCol] == Mine)
                {
                    count++;
                }
            }

            if (rightCol < cols)
            {
                if (board[row, rightCol] == Mine)
                {
                    count++;
                }
            }

            if ((upperRow >= 0) && (leftCol >= 0))
            {
                if (board[upperRow, leftCol] == Mine)
                {
                    count++;
                }
            }

            if ((upperRow >= 0) && (rightCol < cols))
            {
                if (board[upperRow, rightCol] == Mine)
                {
                    count++;
                }
            }

            if ((lowerRow < rows) && (leftCol >= 0))
            {
                if (board[lowerRow, leftCol] == Mine)
                {
                    count++;
                }
            }

            if ((lowerRow < rows) && (rightCol < cols))
            {
                if (board[lowerRow, rightCol] == Mine)
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}