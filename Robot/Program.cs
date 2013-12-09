using System;

namespace Robot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int itemsCount = ReadItemsCount();
            Map map = new Map();

            ConfigureItems(itemsCount, map);

            int itemsCollectedCount = CollectItems(itemsCount, map);

            PrintResult(itemsCollectedCount);
        }

        private static int CollectItems(int itemsCount, Map map)
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

                itemsCollectedCount += CheckItemPresence(itemsCount, map, RobotXCoord, RobotYCoord);
            }

            return itemsCollectedCount;
        }

        private static int CheckItemPresence(int itemsCount, Map map, int RobotXCoord, int RobotYCoord)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                if (map.HasItemAtCoords(RobotXCoord, RobotYCoord))
                {
		    map.RemoveItem(RobotXCoord, RobotYCoord);

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

        private static void ConfigureItems(int itemsCount, Map map)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                var coordinates = GetItemCoordinates();
                map.AddItem(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }
        }

        private static string GetRobotCommands()
        {
            return Console.ReadLine();
        }

        private static string[] GetItemCoordinates()
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
