using Core.GameEvents;
using System;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.CartesianPlane
{
    [Serializable]
    internal class CartesianPlane : MonoBehaviour, ICartesianPlaneMonoBehaviour
    {
        #region Implements ICartesianPlaneMonoBehaviour

        [Inject] public ICartesianPlaneData Data { get; } = default;
        [Inject] public ICartesianPlaneLogic Logic { get; } = default;

        #endregion

        #region Inspector

        [SerializeField] private GameEvent onDrawCartesianPlane = default;

        #endregion

        private void Start()
        {
            onDrawCartesianPlane.Raise();
        }              
    }
}
