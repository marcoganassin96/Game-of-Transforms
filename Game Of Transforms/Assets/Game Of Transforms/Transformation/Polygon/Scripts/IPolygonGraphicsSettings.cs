using UnityEngine;

namespace GameOfTransforms.Transformation.Polygon
{
    public interface IPolygonGraphicsSettings
    {
        GameObject GraphicalPointPrefab { get; }

        float AnimationSpeed(Transformation transformation);
    }
}
