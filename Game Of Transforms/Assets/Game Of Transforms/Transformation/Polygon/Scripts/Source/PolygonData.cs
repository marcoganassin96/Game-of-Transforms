using GameOfTransforms.Events;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Vector2 = System.Numerics.Vector2;

namespace GameOfTransforms.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Polygon Data", menuName = "Game Of Transforms/Transformation/Polygon/Polygon Data")]
    internal class PolygonData : ScriptableObject, IPolygonData
    {
        [SerializeField] private List<Vector2> points = default;
        public List<Vector2> Points => points;

        [Inject] private IOnNewPolygonData onNewPolygonData = default;

        internal void OnNewPolygon ()
        {
            points = onNewPolygonData.Points;
        }
    }
}
