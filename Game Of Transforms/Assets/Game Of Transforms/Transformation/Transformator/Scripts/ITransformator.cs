using System.Numerics;

namespace GameOfTransforms.Transformation.Transformator
{
    public interface ITransformator
    {
        void OnTransformation ();
        Vector2 Multiply (Matrix4x4 matrix, Vector2 point);
    }
}
