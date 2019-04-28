using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.Events
{
    public interface IOnNewPolygonGraphicsData
    {
        List<Transform> Points { get; set; }
    }
}
