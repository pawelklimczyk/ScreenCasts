using System;

namespace Robot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int itemsCount = ReadItemsCount();
            int[,] itemsMap = new int[itemsCount, 2];

            ConfigureItems(itemsCount, itemsMap);

            int itemsCollectedCount = CollectItems(itemsCount, itemsMap);

            PrintResult(itemsCollectedCount);
        }

        private static int CollectItems(int itemsCount, int[,] itemsMap)
        {
            int itemsCollectedCount = 0;
            int RobotXCoord = 0;
            int RobotYCoord = 0;
            int direction = 0;
            int[] directionMapX = new int[] { 0, 1, 0, -1 };
            int[] directionMapY = new int[] { 1, 0, -1, 0 };

            foreach (var command in GetRobotCommands())
            {
                if (HandleRobotCommand(command, directionMapX, directionMapY, ref direction, ref RobotXCoord, ref RobotYCoord))
                {
                    continue;
                }

                itemsCollectedCount += CheckItemPresence(itemsCount, itemsMap, RobotXCoord, RobotYCoord);
            }

            return itemsCollectedCount;
        }

        private static int CheckItemPresence(int itemsCount, int[,] itemsMap, int RobotXCoord, int RobotYCoord)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                if (itemsMap[i, 0] == RobotXCoord && itemsMap[i, 1] == RobotYCoord)
                {
                    itemsMap[i, 0] = int.MaxValue;
                    itemsMap[i, 1] = int.MaxValue;

                    return 1;
                }
            }

            return 0;
        }

        private static bool HandleRobotCommand(char command, int[] directionMapX, int[] directionMapY, ref int direction, ref int RobotXCoord, ref int RobotYCoord)
        {
            switch (command)
            {
                case 'L':
                    direction = (direction + 3) % 4;
                    return true;
                case 'R':
                    direction = (direction + 1) % 4;
                    return true;
                case 'F':
                    RobotXCoord += directionMapX[direction];
                    RobotYCoord += directionMapY[direction];
                    break;
                case 'B':
                    RobotXCoord -= directionMapX[direction];
                    RobotYCoord -= directionMapY[direction];
                    break;
            }

            return false;
        }

        private static void ConfigureItems(int itemsCount, int[,] itemsMap)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                var l = GetitemCoordinates();
                itemsMap[i, 0] = int.Parse(l[0]);
                itemsMap[i, 1] = int.Parse(l[1]);
            }
        }

        private static string GetRobotCommands()
        {
            return Console.ReadLine();
        }

        private static string[] GetitemCoordinates()
        {
            return Console.ReadLine().Split(' ');
        }

        private static void PrintResult(int itemsCollectedCount)
        {
            Console.Out.WriteLine(itemsCollectedCount);
        }

        private static int ReadItemsCount()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
