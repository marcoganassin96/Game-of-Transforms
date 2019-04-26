using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace GameOfTransforms.Transformation.Polygon
{
    internal class Polygon : MonoBehaviour, IPolygon
    {
        public List<Vector2> Points { get; set; } = default;
    }
}
