using GameOfTransforms.Events;
using GameOfTransforms.Transformation.Polygon;
using UnityEngine;
using Zenject;
using Matrix4x4 = System.Numerics.Matrix4x4;

namespace GameOfTransforms.Transformation.Transformator
{
    public class GraphicsTransformator : MonoBehaviour
    {
        [Inject] private IPolygonGraphicsData polygonGraphicsData = default;
        [Inject] private IPolygonGraphicsSettings polygonGraphicsSettings = default;
        [Inject] private IOnTransformationData transformatorEventData = default;

        public void OnTransformation ()
        {
            PartialMatrix partialMatrix = transformatorEventData.TransformationMatrix.PartialMatrix;
            int quantity = transformatorEventData.TransformationMatrix.Quantity;

            float c = 0F;
            for (c = 0F; c + polygonGraphicsSettings.AnimationSpeed < quantity; c += polygonGraphicsSettings.AnimationSpeed)
            {
                foreach (Transform point in polygonGraphicsData.Points)
                {
                    point.position = Multiply(partialMatrix(c), point.position);
                }
            }
            foreach (Transform point in polygonGraphicsData.Points)
            {
                point.position = Multiply(partialMatrix(quantity - c), point.position);
            }
        }
        
        #region Graphics Transformator Utilities         

        private Vector3 Multiply (Matrix4x4 matrix, Vector3 point)
        {
            return Matrix2Vector(Matrix4x4.Multiply(matrix, Vector2Matrix(point)));
        }

        private Matrix4x4 Vector2Matrix (Vector3 point)
        {
            float x = point.x;
            float y = point.y;
            return new Matrix4x4
            (
                x, 0, 0, 0,
                y, 0, 0, 0,
                0, 0, 0, 0,
                1, 0, 0, 0
            );
        }

        private Vector3 Matrix2Vector (Matrix4x4 matrix)
        {
            float x = matrix.M11;
            float y = matrix.M21;
            return new Vector3(x, y);
        }

        #endregion


    }
}
