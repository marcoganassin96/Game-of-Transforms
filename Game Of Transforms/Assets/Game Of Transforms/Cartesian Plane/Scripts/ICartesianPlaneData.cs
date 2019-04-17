using UnityEngine;

namespace GameOfTransforms
{
    public interface ICartesianPlaneData
    {
        #region Shared data

        int Size { get; }
        Vector3 Origin { get; }

        #endregion
    }
}
