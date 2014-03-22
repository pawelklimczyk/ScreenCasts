namespace RobotProgram
{
    using System;
    using System.Collections.Generic;

    public class Robot
    {
        private readonly ICommandProvider commandProvider;

        public Robot(ICommandProvider commandProvider)
        {
            this.commandProvider = commandProvider;
            dimention = Dimention.Vertical;
        }

        private Dimention dimention;

        private int x, y;

        public int ItemsCollected
        {
            get;
            set;
        }

        public int RobotXCoord
        {
            get
            {
                return x;
            }
            private set
            {
                if (dimention == Dimention.Horizontal)
                {
                    if (Direction == Direction.West)
                    {
                        x = value * (-1);
                    }
                    else if (Direction == Direction.East)
                    {
                        x = value;
                    }
                }
            }
        }

        public int RobotYCoord
        {
            get
            {
                return y;
            }
            private set
            {
                if (dimention == Dimention.Vertical)
                {
                    if (Direction == Direction.South)
                    {
                        y = value * (-1);
                    }
                    else if (Direction == Direction.North)
                    {
                        y = value;
                    }
                }
            }
        }

        public Direction Direction { get; private set; }

        public void CollectItems(Map map)
        {
            foreach (var command in commandProvider.GetCommands())
            {
                HandleRobotCommand(command, map);
            }
        }

        private void CheckItemPresence(Map map)
        {
            if (map.HasItemAtCoords(RobotXCoord, RobotYCoord))
            {
                map.RemoveItem(RobotXCoord, RobotYCoord);
                ItemsCollected++;
            }
        }

        private void HandleRobotCommand(char command, Map map)
        {
            switch (command)
            {
                case Commands.Left:
                case Commands.Right:
                    Direction = directionsMap[new KeyValuePair<char, Direction>(command, Direction)];
                    dimention = dimention == Dimention.Horizontal ? Dimention.Vertical : Dimention.Horizontal;
                    break;
                case Commands.Forward:
                    RobotXCoord += Steps.StepForward;
                    RobotYCoord += Steps.StepForward;
                    CheckItemPresence(map);
                    break;
                case Commands.Back:
                    RobotXCoord += Steps.StepBack;
                    RobotYCoord += Steps.StepBack;
                    CheckItemPresence(map);
                    break;
            }
        }

        private Dictionary<KeyValuePair<char, Direction>, Direction> directionsMap = new Dictionary<KeyValuePair<char, Direction>, Direction>()
                                                                                        {
                                                                                            {new KeyValuePair<char, Direction>(Commands.Left,Direction.North),Direction.West },
                                                                                            {new KeyValuePair<char, Direction>(Commands.Left,Direction.West),Direction.South },
                                                                                            {new KeyValuePair<char, Direction>(Commands.Left,Direction.South),Direction.East },
                                                                                            {new KeyValuePair<char, Direction>(Commands.Left,Direction.East),Direction.North },
                                                                                            {new KeyValuePair<char, Direction>(Commands.Right,Direction.North),Direction.East },
                                                                                            {new KeyValuePair<char, Direction>(Commands.Right,Direction.East),Direction.South },
                                                                                            {new KeyValuePair<char, Direction>(Commands.Right,Direction.South),Direction.West },
                                                                                            {new KeyValuePair<char, Direction>(Commands.Right,Direction.West),Direction.North },
                                                                                        };
        private struct Steps
        {
            public const int StepForward = 1;
            public const int StepBack = -1;
        }

        private struct Commands
        {
            public const char Left = 'L';
            public const char Right = 'R';
            public const char Forward = 'F';
            public const char Back = 'B';
        }
    }
}