using GameOfTransforms.Transformation;

namespace GameOfTransforms.Events
{
    public interface IOnTransformationData
    {
        Transformation.Transformation Transformation { get; }
        Direction Direction { get; }
        float Quantity { get; }

        void SetTransformationData (Transformation.Transformation transformation, Direction direction, float quantity);
    }
}
