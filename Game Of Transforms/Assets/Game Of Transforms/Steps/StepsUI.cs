using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameOfTransforms.Steps
{
    internal class StepsUI : MonoBehaviour
    {
        [Inject] private StepsData stepsData = default;

        [SerializeField] private Text stepsText = default;
        
        private void Awake()
        {
            UpdateStepText();
        }

        internal void UpdateStepText()
        {
            stepsText.text = "Step " + stepsData.currentStep + "/" + stepsData.stepsNumber;
        }
    }
}