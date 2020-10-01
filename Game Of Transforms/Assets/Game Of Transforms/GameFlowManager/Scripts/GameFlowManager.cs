using Core.GameEvents;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.GameFlow
{
    internal class GameFlowManager : MonoBehaviour
    {
        [Inject] private GameFlowData data = default;

        private bool lastStepReached = false;
        private bool positionReached = false;

        [SerializeField] private GameEvent GameWon = default;
        [SerializeField] private GameEvent GameLost = default;
        [SerializeField] private GameEvent GameTied = default;

        private void Awake()
        {
            OnNewLevel();
        }

        public void OnTransformationFinished()
        {
            if (data.PlayerTurn)
            {
                OnPlayerTransformationFinished();
            }
        }

        private void OnPlayerTransformationFinished()
        {
            Debug.Log("OnPlayerTransformationFinished");
            if (lastStepReached && positionReached)
            {
                GameTied?.Raise();
                Debug.Log("TIE");
            }
            else if (lastStepReached)
            {
                GameLost?.Raise();
                Debug.Log("LOST");
            }
            else if (positionReached)
            {
                GameWon?.Raise();
                Debug.Log("WIN");
            }
            lastStepReached = positionReached = false;
        }

        public void OnLastStepReached()
        {
            lastStepReached = true;
            Debug.Log("OnLastStepReached");
        }

        public void OnPositionReached()
        {
            positionReached = true;
        }
        
        internal void OnNewLevel()
        {
            data.winningPointsPositions = new List<Vector2>() { new Vector2(0, 4), new Vector2(4, -3), new Vector2(8, 8) };
        }
    }
}
