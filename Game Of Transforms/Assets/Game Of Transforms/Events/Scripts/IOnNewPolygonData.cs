using System.Collections.Generic;
using System.Numerics;

namespace GameOfTransforms.Events
{
    public interface IOnNewPolygonData
    {
        List<Vector2> Points { get; set; }
    }
}
