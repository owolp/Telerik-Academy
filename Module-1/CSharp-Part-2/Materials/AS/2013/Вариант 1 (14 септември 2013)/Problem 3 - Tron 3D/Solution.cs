using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // read input
        int[] xyz = Console.ReadLine().Split(' ')
            .Select(int.Parse).ToArray();

        int x = xyz[0], y = xyz[1], z = xyz[2];

        string[] commands = { Console.ReadLine(), Console.ReadLine() };

        // prepare variables 

        // H, V
        int[] dims = { 2 * y + 2 * z, x + 1 };
        bool[,] visited = new bool[dims[0], dims[1]];

        // red player / blue player
        int[] direction = { 0, 2 };
        int[] directionH = { 1, 0, -1, 0 };
        int[] directionV = { 0, 1, 0, -1 };
        int[,] position = { { y / 2, x / 2 }, { y + z + y / 2, x / 2 } };
        // did player go on forbidden walls?
        bool[] outside = { false, false };

        // index into the 'commands' strings we read from the console
        int[] commandIndex = { 0, 0 };

        // algorithm
        
        // for every game cycle
        while (true)
        {
            // for both players
            for (int player = 0; player <= 1; player += 1)
            {
                visited[position[player, 0], position[player, 1]] = true;
                
                // read next command from player's string
                char cmd = commands[player][commandIndex[player]];
                commandIndex[player] += 1;

                // turn?
                if (cmd == 'L' || cmd == 'R')
                {
                    // adjust direction index
                    direction[player] += (cmd == 'L') ? 1 : 3;
                    direction[player] %= 4;
                    // read more commands for same player
                    player -= 1;
                    continue;
                }
                else
                {
                    int newH = position[player, 0] + directionH[direction[player]];
                    int newV = position[player, 1] + directionV[direction[player]];

                    // went on forbidden wall
                    if (newV < 0 || newV >= dims[1])
                    {
                        outside[player] = true;
                        continue;
                    }

                    // went above top or below bottom?
                    if (newH < 0 || newH >= dims[0])
                    {
                        // loop over to other side
                        newH += dims[0]; newH %= dims[0];
                    }

                    position[player, 0] = newH;
                    position[player, 1] = newV;
                }
            }

            // after each game cycle
            // check if anyone died

            // crashed head to head?
            bool headOnCollision = position[0, 0] == position[1, 0] &&
                                   position[0, 1] == position[1, 1];

            bool redDied = visited[position[0, 0], position[0, 1]] || headOnCollision || outside[0];
            bool blueDied = visited[position[1, 0], position[1, 1]] || headOnCollision || outside[1];

            if (redDied || blueDied)
            {
                if (redDied && blueDied) Console.WriteLine("DRAW");
                else if (redDied) Console.WriteLine("BLUE");
                else if (blueDied) Console.WriteLine("RED");
                // we can ask them for 3D distance or just 2D manhattan distance along the surface of the cube
                Console.WriteLine(GetDistanceFromStart(position[0, 0], position[0, 1], x, y, z));
                return;
            }
        }
    }

    static double GetDistanceFromStart(int h, int v, int x, int y, int z)
    {
        // use symmetry
        if (h > z + y + y / 2)
            h = 2 * z + y - h;

        return Math.Abs(h - y / 2) + Math.Abs(v - x / 2);
    }
}