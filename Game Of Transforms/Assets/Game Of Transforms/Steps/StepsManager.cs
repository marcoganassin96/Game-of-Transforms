using UnityEngine;
using Zenject;

namespace GameOfTransforms.Steps
{
    internal class StepsManager : MonoBehaviour
    {
        [Inject] private StepsLogic logic = default;
        [Inject] private StepsUI UI = default;

        private void OnNewLevel()
        {
            logic.OnNewLevel();
            UI.UpdateStepText();
        }

        public void OnPlayerTransformationStarted()
        {
            logic.OnPlayerTransformation();
            UI.UpdateStepText();
        }
    }
}
