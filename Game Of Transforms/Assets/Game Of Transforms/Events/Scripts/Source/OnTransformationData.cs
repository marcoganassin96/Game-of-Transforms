using GameOfTransforms.Transformation;
using UnityEngine;

namespace GameOfTransforms.Events
{
    public class OnTransformationData : ScriptableObject, IOnTransformationData
    {
        public TransformationMatrix TransformationMatrix { get; set; } = default;
    }
}
