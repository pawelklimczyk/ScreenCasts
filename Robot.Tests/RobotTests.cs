namespace RobotProgram.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class RobotTests
    {
        [Test]
        public void Default_robot_coordiates_and_direction_should_be_set()
        {
            //arrange
            Robot robot = new Robot(new TestCommandProvider(""));

            //assert
            Assert.AreEqual(Direction.North, robot.Direction);
            Assert.AreEqual(0, robot.RobotXCoord);
            Assert.AreEqual(0, robot.RobotYCoord);
        }

        [Test]
        [Sequential]
        public void RobotDirection_should_be_equal_to_direction([Values("R", "RR", "RRR", "RRRR", "L", "LL", "LLL", "LLLL", "RL", "RLR")]string commands, [Values(Direction.East, Direction.South, Direction.West, Direction.North, Direction.West, Direction.South, Direction.East, Direction.North, Direction.North, Direction.East)] Direction direction)
        {
            //arrange
            Robot robot = new Robot(new TestCommandProvider(commands));

            //act
            robot.CollectItems(new Map());

            //assert
            Assert.AreEqual(direction, robot.Direction);
        }

        [Test]
        [Sequential]
        public void RobotPosition_should__equal_to_x_y([Values("F", "B", "FF", "FBFB", "RF", "LF", "RB", "LB", "FRF", "FLF", "LLB")]string commands, [Values(0, 0, 0, 0, 1, -1, -1, 1, 1, -1, 0)]int x, [Values(1, -1, 2, 0, 0, 0, 0, 0, 1, 1, 1)] int y)
        {
            //arrange
            Robot robot = new Robot(new TestCommandProvider(commands));

            //act
            robot.CollectItems(new Map());

            //assert
            Assert.AreEqual(x, robot.RobotXCoord);
            Assert.AreEqual(y, robot.RobotYCoord);
        }

        class TestCommandProvider:ICommandProvider
        {
            private readonly string commands;

            public TestCommandProvider(string commands)
            {
                this.commands = commands;
            }

            public string GetCommands()
            {
                return commands;
            }
        }
    }
}
