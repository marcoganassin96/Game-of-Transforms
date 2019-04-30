using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.Transformation.Polygon
{
    public interface IPolygonGraphicsData
    {
        List<Transform> Points { get; }
        void OnNewPolygon();
    }
}
