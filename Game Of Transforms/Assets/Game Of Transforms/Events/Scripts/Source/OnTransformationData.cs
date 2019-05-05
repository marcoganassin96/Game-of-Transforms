using GameOfTransforms.Transformation;
using UnityEngine;

namespace GameOfTransforms.Events
{
    [CreateAssetMenu(fileName = "On Transformation Data", menuName = "Game Of Transforms/Events/On Transformation Data")]
    public class OnTransformationData : ScriptableObject, IOnTransformationData
    {
        public Transformation.Transformation Transformation { get; private set; } = default;
        public Direction Direction { get; private set; } = default;
        public float Quantity { get; private set; } = default;

        public void SetTransformationData (Transformation.Transformation transformation, Direction direction, float quantity)
        {
            Transformation = transformation;
            Direction = direction;
            Quantity = quantity;
        }
    }
}
