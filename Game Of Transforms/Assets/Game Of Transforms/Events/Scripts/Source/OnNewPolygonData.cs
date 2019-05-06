using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.Events
{
    [CreateAssetMenu(fileName = "On New Polygon Data", menuName = "Game Of Transforms/Events/On New Polygon Data")]
    public class OnNewPolygonData : ScriptableObject, IOnNewPolygonData
    {
        public List<Vector2> Points { get; set; }
    }
}
