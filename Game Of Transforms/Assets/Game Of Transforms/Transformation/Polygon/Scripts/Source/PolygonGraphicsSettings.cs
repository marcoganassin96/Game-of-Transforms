using UnityEngine;

namespace GameOfTransform.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Cartesian Plane Data", menuName = "Game Of Transforms/Polygon/Cartesian Plane Data")]
    internal class PolygonGraphicsSettings: ScriptableObject, IPolygonGraphicsSettings
    {
        [SerializeField] private float animationSpeed = default;
        public float AnimationSpeed => animationSpeed;
    }
}
