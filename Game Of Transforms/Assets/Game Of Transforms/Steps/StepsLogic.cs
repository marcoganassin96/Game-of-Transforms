using Core.GameEvents;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Steps
{
    internal class StepsLogic : MonoBehaviour
    {
        [Inject] private StepsData stepsData = default;

        [SerializeField] private GameEvent LastStepReached = default;

        internal void OnNewLevel()
        {
            ++stepsData.stepsNumber;
            stepsData.currentStep = 0;
        }

        internal void OnPlayerTransformation()
        {
            ++stepsData.currentStep;
            if (stepsData.currentStep == stepsData.stepsNumber)
            {
                LastStepReached?.Raise();
                Debug.Log("Last step");
            }
        }
    }
}
