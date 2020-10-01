using Core.GameEvents;
using GameOfTransforms.Events;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Transformator
{
    internal class TransformatorsManager : MonoBehaviour
    {
        [SerializeField] GraphicsTransformator graphicsTransformator = default;

        [Inject] private ITransformator transformator = default;
        [Inject] private IOnTransformationData transformatorEventData = default;

        public void OnTransformationStarted()
        {
            Transformation transformation = transformatorEventData.Transformation;
            Direction direction = transformatorEventData.Direction;
            float quantity = transformatorEventData.Quantity;
            transformator.OnTransformation(transformation, direction, quantity);
            graphicsTransformator.OnTransformation(transformation, direction, quantity);
        }
    }
}
