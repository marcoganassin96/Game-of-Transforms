using UnityEngine;

namespace GameOfTransforms.Transformation.Polygon
{
    public interface IPolygonGraphicsSettings
    {
        float AnimationSpeed { get; }
        GameObject GraphicalPointPrefab { get; }
    }
}
