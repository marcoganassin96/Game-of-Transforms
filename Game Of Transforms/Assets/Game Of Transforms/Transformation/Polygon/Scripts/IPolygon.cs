using System.Collections.Generic;
using System.Numerics;

namespace GameOfTransforms.Transformation.Polygon
{
    public interface IPolygon
    {
        List<Vector2> Points { get; set; }
    }
}
