using Core.GameEvents;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace GameOfTransforms
{
    public interface ICartesianPlaneMonoBehaviour
    {
        ICartesianPlaneData Data { get; }
        ICartesianPlaneLogic Logic { get; }
    }

    [Serializable]
    internal class CartesianPlaneMonoBehaviour : MonoBehaviour, ICartesianPlaneMonoBehaviour
    {
        #region Implements ICartesianPlaneMonoBehaviour

        [Inject] public ICartesianPlaneData Data { get; } = default;
        [Inject] public ICartesianPlaneLogic Logic { get; } = default;

        #endregion

        #region Inspector

        [SerializeField] private GameEvent onDrawCartesianPlane = default;

        #endregion

        private IEnumerator Start()
        {
            yield return null;
            onDrawCartesianPlane.Raise();
        }              
    }
}
