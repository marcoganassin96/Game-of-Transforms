using GameOfTransforms.Events;
using GameOfTransforms.Transformation.Polygon;
using UnityEngine;
using Zenject;
using Matrix4x4 = System.Numerics.Matrix4x4;
using Vector2 = System.Numerics.Vector2;

namespace GameOfTransforms.Transformation.Transformator
{
    public class Transformator : ITransformator
    {
        [Inject] private IPolygonData polygonData = default;
        [Inject] private IOnTransformationData transformatorEventData = default;

        public void OnTransformation ()
        {
            Matrix4x4 matrix = transformatorEventData.TransformationMatrix.PartialMatrix(transformatorEventData.TransformationMatrix.Quantity);
            for (int i = 0; i < polygonData.Points.Count; ++i)
            {
                polygonData.Points[i] = Multiply(matrix, polygonData.Points[i]);
            }
        }
        
        #region Transformator Utilities

        private Vector2 Multiply (Matrix4x4 matrix, Vector2 point)
        {
            return Matrix2Vector(Matrix4x4.Multiply(matrix, Vector2Matrix(point)));
        }

        private Matrix4x4 Vector2Matrix (Vector2 point)
        {
            float x = Mathf.Round(point.X * 100) / 100F;
            float y = Mathf.Round(point.Y * 100) / 100F;
            return new Matrix4x4
            (
                x, 0, 0, 0,
                y, 0, 0, 0,
                0, 0, 0, 0,
                1, 0, 0, 0
            );
        }

        private Vector2 Matrix2Vector (Matrix4x4 matrix)
        {
            float x = Mathf.Round(matrix.M11 * 100) / 100F;
            float y = Mathf.Round(matrix.M21 * 100) / 100F;
            return new Vector2(x, y);
        }

        #endregion
    }
}
