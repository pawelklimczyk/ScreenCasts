using System;

namespace RobotProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int itemsCount = ReadItemsCount();

            Map map = new Map();
            Robot robot = new Robot(new ConsoleCommandProvider());

            ConfigureItems(itemsCount, map);

            robot.CollectItems(map);

            PrintResult(robot.ItemsCollected);
        }

        private static void ConfigureItems(int itemsCount, Map map)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                var coordinates = GetItemCoordinates();
                map.AddItem(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            }
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
