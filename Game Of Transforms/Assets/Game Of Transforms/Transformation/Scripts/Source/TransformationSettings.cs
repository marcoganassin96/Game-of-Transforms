using UnityEngine;

namespace GameOfTransforms.Transformation
{ 
    [CreateAssetMenu(fileName = "Transformation Settings", menuName = "Game Of Transforms/Transformation/Transformation Settings")]
    internal class TransformationSettings: ScriptableObject, ITransformationSettings
    {
        [SerializeField] private Trasformation2IdentityElementDict trasformation2IdentityElement = default;
        public Trasformation2IdentityElementDict Trasformation2IdentityElement => trasformation2IdentityElement;
    }
}
