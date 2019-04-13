using UnityEngine;

namespace GameOfTransforms
{
    [CreateAssetMenu(fileName = "Cartesian Plane Data", menuName = "Game Of Transforms/Cartesian Plane Data")]
    internal class CartesianPlaneData : ScriptableObject, ICartesianPlaneData
    {
        #region Implements ICartesianPlaneData

        [SerializeField] private int size = default;
        public int Size => size;

        #endregion
    }
}
