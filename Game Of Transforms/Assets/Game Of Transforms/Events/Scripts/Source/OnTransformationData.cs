using GameOfTransforms.Transformation;
using UnityEngine;

namespace GameOfTransforms.Events
{
    [CreateAssetMenu(fileName = "On Transformation Data", menuName = "Game Of Transforms/Events/On Transformation Data")]
    public class OnTransformationData : ScriptableObject, IOnTransformationData
    {
        public TransformationMatrix TransformationMatrix { get; set; } = default;
    }
}
