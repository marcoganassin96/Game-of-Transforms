using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransform.CartesianPlane.GraphicsTests
{
    [CreateAssetMenu(fileName = "Cartesian Plane Graphics Tests Data", menuName = "Game Of Transforms/Graphics Tests/Cartesian Plane Graphics Tests Data")]
    internal class CartesianPlaneGraphicsTestsData : ScriptableObject, ICartesianPlaneGraphicsTestsData
    {
        [SerializeField] private GameObject coordinateMarkerPrefab = default;
        public GameObject CoordinateMarkerPrefab => coordinateMarkerPrefab;

        [SerializeField] private List<Coordinate> coordinates = default;
        public List<Coordinate> Coordinates => coordinates;
    }
}
