using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransform.Transformation.Polygon
{
    public interface IPolygon
    {
        List<Vector2> Points { get; }
    }
}
