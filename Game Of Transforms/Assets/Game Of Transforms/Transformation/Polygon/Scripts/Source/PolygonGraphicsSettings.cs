using UnityEngine;

namespace GameOfTransform.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Cartesian Plane Data", menuName = "Game Of Transforms/Cartesian Plane Data")]
    public class PolygonGraphicsSettings: ScriptableObject, IPolygonGraphicsSettings
    {
        [SerializeField] private float animationSpeed = default;
        public float AnimationSpeed => animationSpeed;
    }
}
