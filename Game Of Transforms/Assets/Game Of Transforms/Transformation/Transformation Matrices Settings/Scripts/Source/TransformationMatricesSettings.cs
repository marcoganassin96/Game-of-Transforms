using UnityEngine;

namespace GameOfTransform.Transformation.TransformationMatricesSettings
{
    [CreateAssetMenu(fileName = "Transformation Matrices Settings", menuName = "Game Of Transforms/Transformation/Transformation Matrices Settings/Transformation Matrices Settings")]
    internal class TransformationMatricesSettings : ScriptableObject, ITransformationMatricesSettings
    {
        [SerializeField] private Transformation2SettingDict transformation2Settings = default;
        public Transformation2SettingDict Transformation2Settings => transformation2Settings;
    }
}
