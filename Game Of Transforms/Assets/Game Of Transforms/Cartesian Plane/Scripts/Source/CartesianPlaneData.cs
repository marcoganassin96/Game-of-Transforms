using UnityEngine;

namespace GameOfTransforms.CartesianPlane
{
    [CreateAssetMenu(fileName = "Cartesian Plane Data", menuName = "Game Of Transforms/Cartesian Plane Data")]
    internal class CartesianPlaneData : ScriptableObject, ICartesianPlaneData
    {
        #region Implements ICartesianPlaneData

        [SerializeField] private int size = default;
        public int Size => size;

        [SerializeField] private Vector3 origin = default;
        public Vector3 Origin => origin;

        #endregion
    }
}
