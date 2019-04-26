using UnityEngine;

namespace GameOfTransform.Transformation.Polygon
{
    internal class PolygonGraphicsData : MonoBehaviour, IPolygonGraphicsData
    {
        public Transform[] Points { get; }

        public PolygonGraphicsData(Transform[] points)
        {
            Points = points;
        }
    }
}
