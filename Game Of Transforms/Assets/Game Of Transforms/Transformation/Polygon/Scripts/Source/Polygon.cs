using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransform.Transformation.Polygon
{
    public class Polygon : MonoBehaviour, IPolygon
    {
        public List<Vector2> Points { get; }
    }
}
