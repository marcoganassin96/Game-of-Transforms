using System;

namespace GameOfTransforms.Transformation
{
    [Serializable]
    public struct TransformationMatrix
    {
        public PartialMatrix PartialMatrix { get; }
        public float Quantity { get; }

        public TransformationMatrix(PartialMatrix partialMatrix, float quantity)
        {
            PartialMatrix = partialMatrix;
            Quantity = quantity;
        }
    }
}
