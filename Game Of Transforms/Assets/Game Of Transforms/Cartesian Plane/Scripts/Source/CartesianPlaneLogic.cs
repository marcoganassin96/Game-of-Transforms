using System;
using Zenject;

namespace GameOfTransforms
{
    internal class CartesianPlaneLogic : ICartesianPlaneLogic
    {
        #region Implements ICartesianPlaneLogic

        public ICartesianPlaneData Data { get; } = default;

        #endregion

        [Inject]
        public CartesianPlaneLogic (ICartesianPlaneData data)
        {
            Data = data;
            if (Data.Size <= 0)
            {
                throw new ArgumentException("Cartesian Plane's size is " + Data.Size + "; Size greater than 0 expected");
            }
        }
    }
}
