using GameOfTransforms.Events;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Polygon Data", menuName = "Game Of Transforms/Transformation/Polygon/Polygon Data")]
    internal class PolygonData : MonoBehaviour, IPolygonData
    {
        [SerializeField] private List<Vector2> points = default;
        public List<Vector2> Points => points;

        [Inject] private IOnNewPolygonData onNewPolygonData = default;
        
        public void OnNewPolygon ()
        {
            points = onNewPolygonData.Points;
        }
    }
}
