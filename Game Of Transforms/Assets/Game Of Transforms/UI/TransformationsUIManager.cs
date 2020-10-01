using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameOfTransforms.Transformation.UI
{
    internal class TransformationsUIManager : MonoBehaviour
    {
        private Color normalColor = default;
        private Color pressedColor = default;

        [SerializeField] private List<Button> transformationsButtons = new List<Button>();
        Button currentTransformationButton = null;

        [SerializeField] private List<Button> directionsButtons = new List<Button>();
        Button currentDirectionButton = null;

        [SerializeField] Button reflectionButton = default;
        [SerializeField] InputField value = default;

        private void Start()
        {
            normalColor = Color.white - (
                (Color.white - transformationsButtons[0].image.color) +
                (Color.white - transformationsButtons[0].colors.normalColor)
            );
            pressedColor = Color.white - (
                (Color.white - transformationsButtons[0].image.color) +
                (Color.white - transformationsButtons[0].colors.pressedColor)
            );

            foreach (Button transformationButton in transformationsButtons)
            {
                transformationButton.onClick.AddListener(delegate { OnTransformationButtonClicked(transformationButton); });
            }

            foreach (Button directionButton in directionsButtons)
            {
                directionButton.onClick.AddListener(delegate { OnDirectionButtonClicked(directionButton); });
            }

            reflectionButton.onClick.AddListener(delegate { value.text = "-1"; });
        }

        private void OnTransformationButtonClicked(Button transformationButton)
        {
            if (currentTransformationButton != null)
                currentTransformationButton.image.color = normalColor;
            currentTransformationButton = transformationButton;
            currentTransformationButton.image.color = pressedColor;
        }

        private void OnDirectionButtonClicked(Button directionButton)
        {
            if (currentDirectionButton != null)
                currentDirectionButton.image.color = normalColor;
            currentDirectionButton = directionButton;
            currentDirectionButton.image.color = pressedColor;
        }
    }
}
