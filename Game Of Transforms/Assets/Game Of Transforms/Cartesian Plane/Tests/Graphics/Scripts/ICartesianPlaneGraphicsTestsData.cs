using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransform.CartesianPlane.Tests.Graphics
{
    public interface ICartesianPlaneGraphicsTestsData
    {
        [SerializeField] GameObject CoordinateMarkerPrefab { get; }
        [SerializeField] List<Coordinate> Coordinates { get; }
    }
}
