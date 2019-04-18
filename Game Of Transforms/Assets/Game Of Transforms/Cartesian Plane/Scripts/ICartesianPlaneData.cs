using UnityEngine;

namespace GameOfTransform.CartesianPlane
{
    public interface ICartesianPlaneData
    {
        #region Shared data

        int Size { get; }
        Vector3 Origin { get; }

        #endregion
    }
}
