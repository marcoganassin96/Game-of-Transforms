using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.Events
{
    [CreateAssetMenu(fileName = "On New Polygon Graphics Data", menuName = "Game Of Transforms/Events/On New Polygon Graphics Data")]
    public class OnNewPolygonGraphicsData : ScriptableObject, IOnNewPolygonGraphicsData
    {
        public List<Transform> Points { get; set; }
    }
}
