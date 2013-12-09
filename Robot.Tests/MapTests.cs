// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="MapTests.cs" project="Robot.Tests" date="2013-12-09 07:32">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace Robot.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class MapTests
    {
        private Map map;

        [SetUp]
        public void Test_setup()
        {
            map = new Map();
        }

        [Test]
        public void Default_ItemsCount_should_be_zero()
        {
            //assert
            Assert.That(map.ItemsCount, Is.EqualTo(0));
        }

        [Test]
        public void ItemsCount_should_increase()
        {
            //act
            map.AddItem(1, 2);

            //assert
            Assert.That(map.ItemsCount, Is.EqualTo(1));
        }

        [Test]
        public void ItemsCount_should_decrease()
        {
            //arrange
            map.AddItem(1, 2);
            map.AddItem(3, 3);

            //act
            map.RemoveItem(1, 2);

            //assert
            Assert.That(map.ItemsCount, Is.EqualTo(1));
        }

        [Test]
        public void Item_with_the_same_coords_shoudl_be_added_once()
        {
            //act
            map.AddItem(1, 2);
            map.AddItem(1, 2);

            //assert
            Assert.That(map.ItemsCount, Is.EqualTo(1));
        }

        [Test]
        public void ItemsCount_should_decrease_once_when_removing_the_same_item_twice()
        {
            //arrange
            map.AddItem(1, 2);
            map.AddItem(3, 3);

            //act
            map.RemoveItem(1, 2);
            map.RemoveItem(1, 2);

            //assert
            Assert.That(map.ItemsCount, Is.EqualTo(1));
        }

        [Test]
        public void Should_have_item_at_specific_coordinate([Values(1, 5, 10, -20, 16)]int x, [Values(2, 5, 7, 10, -10, 0)]int y)
        {
            //act
            map.AddItem(x, y);

            //assert
            Assert.That(map.HasItemAtCoords(x, y), Is.EqualTo(true));
        }
    }
}
