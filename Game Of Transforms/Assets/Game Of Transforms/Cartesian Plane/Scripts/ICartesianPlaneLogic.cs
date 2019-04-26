using UnityEngine;

namespace GameOfTransforms.CartesianPlane
{
    public interface ICartesianPlaneLogic
    {
        ICartesianPlaneData Data { get; }

        Vector3 this[int x, int y] { get; }
    }
}
