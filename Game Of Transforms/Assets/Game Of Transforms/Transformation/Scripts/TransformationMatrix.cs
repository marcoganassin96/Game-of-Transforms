using System;

namespace GameOfTransform.Transformation
{
    [Serializable]
    public struct TransformationMatrix
    {
        public PartialMatrix PartialMatrix { get; }
        public int Quantity { get; }

        public TransformationMatrix(int quantity, PartialMatrix partialMatrix)
        {
            PartialMatrix = partialMatrix;
            Quantity = quantity;
        }
    }
}
