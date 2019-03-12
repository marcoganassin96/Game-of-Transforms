using UnityEngine;

namespace GameOfTransforms
{
    internal class CartesianLines
    {
        internal Vector3 offsetDirection = default;
        internal Vector3 ortogonalDirection = default;

        public CartesianLines(Vector3 offsetDirection, Vector3 ortogonalDirection)
        {
            this.offsetDirection = offsetDirection;
            this.ortogonalDirection = ortogonalDirection;
        }
    }
}
