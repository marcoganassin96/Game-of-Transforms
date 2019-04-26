using System;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.CartesianPlane
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

        public Vector3 this[int x, int y]
        {
            get
            {
                if (x < -Data.Size || x > Data.Size)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Only x coordinates between {0} and {1} are admitted, but {2} found", -Data.Size, Data.Size, x));
                }
                if (y < -Data.Size || y > Data.Size)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Only y coordinates between {0} and {1} are admitted, but {2} found", -Data.Size, Data.Size, y));
                }
                return Data.Origin + Vector3.right * x + Vector3.up * y;
            }
        }
    }
}
