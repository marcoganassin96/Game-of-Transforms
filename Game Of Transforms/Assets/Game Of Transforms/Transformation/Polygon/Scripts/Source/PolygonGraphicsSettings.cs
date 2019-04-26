using UnityEngine;

namespace GameOfTransforms.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Polygon Graphics Settings", menuName = "Game Of Transforms/Transformation/Polygon/Polygon Graphics Settings")]
    internal class PolygonGraphicsSettings: ScriptableObject, IPolygonGraphicsSettings
    {
        [SerializeField] private float animationSpeed = default;
        public float AnimationSpeed => animationSpeed;
    }
}
