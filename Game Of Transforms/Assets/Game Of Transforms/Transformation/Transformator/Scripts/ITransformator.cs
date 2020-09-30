using UnityEngine;
using Matrix4x4 = System.Numerics.Matrix4x4;

namespace GameOfTransforms.Transformation.Transformator
{
    public interface ITransformator
    {
        void OnTransformation(Transformation transformation, Direction direction, float quantity);
        Vector2 Multiply (Matrix4x4 matrix, Vector2 point);
    }
}
