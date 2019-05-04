using GameOfTransforms.Events;
using GameOfTransforms.Transformation.Polygon;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Matrix4x4 = System.Numerics.Matrix4x4;

namespace GameOfTransforms.Transformation.Transformator
{
    internal class GraphicsTransformator : MonoBehaviour
    {
        [Inject] private IPolygonGraphicsData polygonGraphicsData = default;
        [Inject] private IPolygonGraphicsSettings polygonGraphicsSettings = default;
        [Inject] private IOnTransformationData transformatorEventData = default;

        public void OnTransformation ()
        {
            PartialMatrix partialMatrix = transformatorEventData.TransformationMatrix.PartialMatrix;
            float quantity = transformatorEventData.TransformationMatrix.Quantity;
            
            Points2LogicCoordinates points2logicCoordinates = polygonGraphicsData.Points2LogicCoordinates;

            float c = 0F;
            for (c = 0F; c + polygonGraphicsSettings.AnimationSpeed < quantity; c += polygonGraphicsSettings.AnimationSpeed)
            {
                foreach (KeyValuePair<Transform, Vector2> point2logicCoordinate in points2logicCoordinates)
                {
                    point2logicCoordinate.Key.position = Multiply(partialMatrix(c), point2logicCoordinate.Value);
                }
            }
            foreach (KeyValuePair<Transform, Vector2> point2logicCoordinate in points2logicCoordinates)
            {
                point2logicCoordinate.Key.position = Multiply(partialMatrix(quantity - c), point2logicCoordinate.Value);
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
