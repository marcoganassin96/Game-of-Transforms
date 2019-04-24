using UnityEngine;

namespace GameOfTransform.Transformation.Polygon
{
    public class PolygonGraphicsData : MonoBehaviour, IPolygonGraphicsData
    {
        public Transform[] Points { get; }
    }
}
