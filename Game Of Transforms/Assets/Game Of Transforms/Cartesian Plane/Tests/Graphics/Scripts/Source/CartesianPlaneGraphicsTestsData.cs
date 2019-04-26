using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.CartesianPlane.Tests.Graphics
{
    [CreateAssetMenu(fileName = "Cartesian Plane Graphics Tests Data", menuName = "Game Of Transforms/Cartesian Plane/Tests/Graphics/Cartesian Plane Graphics Tests Data")]
    internal class CartesianPlaneGraphicsTestsData : ScriptableObject, ICartesianPlaneGraphicsTestsData
    {
        [SerializeField] private GameObject coordinateMarkerPrefab = default;
        public GameObject CoordinateMarkerPrefab => coordinateMarkerPrefab;

        [SerializeField] private List<Coordinate> coordinates = default;
        public List<Coordinate> Coordinates => coordinates;
    }
}
