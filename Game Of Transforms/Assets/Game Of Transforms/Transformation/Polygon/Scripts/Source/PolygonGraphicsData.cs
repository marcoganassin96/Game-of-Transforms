using GameOfTransforms.Events;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Polygon Graphics Data", menuName = "Game Of Transforms/Transformation/Polygon/Polygon Graphics Data")]
    internal class PolygonGraphicsData : ScriptableObject, IPolygonGraphicsData
    {
        [SerializeField] private List<Transform> points = default;
        public List<Transform> Points => points;

        [Inject] private IOnNewPolygonGraphicsData onNewPolygonGraphicsData = default;

        public void OnNewPolygon ()
        {
            points = onNewPolygonGraphicsData.Points;
        }
    }
}
