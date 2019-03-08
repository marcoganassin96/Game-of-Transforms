using System;

namespace GameOfTransforms
{
    public class CartesianPlane
    {
        private int size;

        public CartesianPlane(int size)
        {
            if ( size <= 0 )
            {
                throw new ArgumentOutOfRangeException("Size must be greater than 0");
            }
            this.size = size;
        }
    }
}
