using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.CartesianPlane.Tests.Graphics
{
    public interface ICartesianPlaneGraphicsTestsData
    {
        [SerializeField] GameObject CoordinateMarkerPrefab { get; }
        [SerializeField] List<Coordinate> Coordinates { get; }
    }
}
