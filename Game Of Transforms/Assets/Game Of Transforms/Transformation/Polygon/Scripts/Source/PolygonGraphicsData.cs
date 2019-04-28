using GameOfTransforms.Events;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Polygon Graphics Data", menuName = "Game Of Transforms/Transformation/Polygon/Polygon Graphics Data")]
    internal class PolygonGraphicsData : ScriptableObject, IPolygonGraphicsData
    {
        [SerializeField] private List<Transform> points = default;
        public List<Transform> Points => points;
        
        [SerializeField] private IOnNewPolygonGraphicsData onNewPolygonGraphicsData = default;

        internal void OnNewPolygon ()
        {
            points = onNewPolygonGraphicsData.Points;
        }
    }
}
