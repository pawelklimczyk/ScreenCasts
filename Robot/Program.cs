using System;

namespace Robot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] f = new int[n, 2];
            int c = 0;
            int x = 0;
            int y = 0;
            int d = 0;
            int[] dx = new int[] { 0, 1, 0, -1 };
            int[] dy = new int[] { 1, 0, -1, 0 };

            for (int i = 0; i < n; i++)
            {
                var l = Console.ReadLine().Split(' ');
                f[i, 0] = int.Parse(l[0]);
                f[i, 1] = int.Parse(l[1]);
            }


            foreach (var chr in Console.ReadLine())
            {
                if (chr == 'L')
                {
                    d = (d + 3) % 4;
                    continue;
                }
                if (chr == 'R')
                {
                    d = (d + 1) % 4;
                    continue;
                }
                if (chr == 'F')
                {
                    x += dx[d];
                    y += dy[d];

                }
                if (chr == 'B')
                {
                    x -= dx[d];
                    y -= dy[d];
                }

                for (int i = 0; i < n; i++)
                {
                    if (f[i, 0] == x && f[i, 1] == y)
                    {
                        c++;
                        f[i, 0] = int.MaxValue;
                        f[i, 1] = int.MaxValue;
                    }
                }
            }
            
            Console.Out.WriteLine(c);
        }
    }
}
