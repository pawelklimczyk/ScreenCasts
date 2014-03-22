// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="Map.cs" project="Robot" date="2013-12-09 07:56">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RobotProgram
{
    using System;
    using System.Collections.Generic;

    public class Map
    {
        Dictionary<Tuple<int, int>, bool> items = new Dictionary<Tuple<int, int>, bool>();

        public int ItemsCount
        {
            get
            {
                return items.Count;
            }
        }

        public void AddItem(int x, int y)
        {
            var coords = new Tuple<int, int>(x, y);

            if (!this.HasItemAtCoords(x, y))
            {
                items.Add(coords, true);
            }
        }

        public void RemoveItem(int x, int y)
        {
            var coords = new Tuple<int, int>(x, y);

            if (this.HasItemAtCoords(x, y))
            {
                items.Remove(coords);
            }
        }

        public bool HasItemAtCoords(int x, int y)
        {
            var coords = new Tuple<int, int>(x, y);

            return items.ContainsKey(coords);
        }
    }
}
