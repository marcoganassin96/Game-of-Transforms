using UnityEngine;

namespace GameOfTransforms.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Polygon Graphics Settings", menuName = "Game Of Transforms/Transformation/Polygon/Polygon Graphics Settings")]
    internal class PolygonGraphicsSettings: ScriptableObject, IPolygonGraphicsSettings
    {
        [SerializeField] private GameObject graphicalPointPrefab = default;
        public GameObject GraphicalPointPrefab => graphicalPointPrefab;

        [SerializeField] Transformation2AnimationSpeed transformationToAnimationSpeed = default;
        public float AnimationSpeed(Transformation transformation) => transformationToAnimationSpeed[transformation];
    }
}
