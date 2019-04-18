using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransform.CartesianPlane.GraphicsTests
{
    public interface ICartesianPlaneGraphicsTestsData
    {
        [SerializeField] GameObject CoordinateMarkerPrefab { get; }
        [SerializeField] List<Coordinate> Coordinates { get; }
    }
}
