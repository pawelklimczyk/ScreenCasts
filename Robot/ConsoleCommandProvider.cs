namespace RobotProgram
{
    using System;

    public class ConsoleCommandProvider : ICommandProvider
    {
        public string GetCommands()
        {
            return Console.ReadLine();
        }
    }

    public interface ICommandProvider
    {
        string GetCommands();
    }
}