using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace GameOfTransforms.Events
{
    [CreateAssetMenu(fileName = "On New Polygon Data", menuName = "Game Of Transforms/Events/On New Polygon Data")]
    public class OnNewPolygonData : ScriptableObject, IOnNewPolygonData
    {
        public List<Vector2> Points { get; set; }
    }
}
