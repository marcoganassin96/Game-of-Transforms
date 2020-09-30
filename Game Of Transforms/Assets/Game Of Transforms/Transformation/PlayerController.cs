using Core.GameEvents;
using GameOfTransforms.Events;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameEvent OnTransformationGameEvent = default;
        [Inject] private IOnTransformationData transformatorEventData = default;

        private Transformation transformation = Transformation.Translation;
        private bool           transformationSet = false;

        private Direction direction = Direction.O;
        private bool      directionSet = false;

        private float quantity = default;

        private float previousQuantity = default;

        public void OnSetTransformation(int transformation)
        {
            this.transformation = (Transformation)transformation;
            transformationSet = true;
        }

        public void OnSetDirection(int direction)
        {
            this.direction = (Direction)direction;
            directionSet = true;
        }

        public void OnSetQuantity(string quantity)
        {
            if (!float.TryParse(quantity, out this.quantity))
            {
                Debug.LogWarning("Quantity should be an integer");
            }
        }

        public void OnConfirm()
        {
            if (transformationSet && directionSet)
            {
                transformatorEventData.SetTransformationData(transformation, direction, quantity);
                Debug.Log("Set: transformation=" + transformation + ", direction=" + direction + ", quantity=" + quantity);

                switch (transformation)
                {
                    case Transformation.Translation:
                        if (direction == Direction.O)
                        {
                            Debug.LogWarning("Translation can be horizontal or vertical only");
                            return;
                        }
                        quantity = (int)quantity;
                        break;
                    case Transformation.Rotation:
                        if (direction != Direction.O)
                        {
                            Debug.LogWarning("Rotation can be with respect to the origin only");
                            return;
                        }
                        if (quantity % 90 != 0)
                        {
                            Debug.LogWarning("Rotation quantity can be only a multiple of 90°");
                            return;
                        }
                        break;
                    case Transformation.Scaling:
                        if (quantity != 2F && quantity != 0.5F)
                        {
                            Debug.LogWarning("Scaling quantity can be only a 2 or 1/2");
                            return;
                        }
                        break;
                    case Transformation.Reflection:
                        quantity = -1F;
                        break;
                    default:
                        break;
                }

                OnTransformationGameEvent?.Raise();
            }
            else
            {
                Debug.LogWarning("Compile all before check");
            }
        }
    }
}