using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.Transformation.Polygon
{
    public interface IPolygonData
    {
        List<Vector2> Points { get; }
        void OnNewPolygon ();
    }
}
