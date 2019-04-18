using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.GraphicsTests
{
    public interface ICartesianPlaneGraphicsTestsData
    {
        [SerializeField] GameObject CoordinateMarkerPrefab { get; }
        [SerializeField] List<Coordinate> Coordinates { get; }
    }
}
