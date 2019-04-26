using GameOfTransforms.Transformation;

namespace GameOfTransforms.Events
{
    public interface IOnTransformationData
    {
        TransformationMatrix TransformationMatrix { get; set; }
    }
}
