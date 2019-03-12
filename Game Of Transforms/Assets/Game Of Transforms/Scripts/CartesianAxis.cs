using UnityEngine;

namespace GameOfTransforms
{
    internal class CartesianAxis
    {
        internal string name = default;
        internal Vector3 offsetDirection = default;

        public CartesianAxis(string name, Vector3 offsetDirection)
        {
            this.name = name;
            this.offsetDirection = offsetDirection;
        }
    }
}
