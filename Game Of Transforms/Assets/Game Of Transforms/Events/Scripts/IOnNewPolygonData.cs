using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.Events
{
    public interface IOnNewPolygonData
    {
        List<Vector2> Points { get; set; }
    }
}
