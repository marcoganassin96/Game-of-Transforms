using GameOfTransforms.CartesianPlane;
using GameOfTransforms.Events;
using GameOfTransforms.Transformation.Polygon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Matrix4x4 = System.Numerics.Matrix4x4;

namespace GameOfTransforms.Transformation.Transformator
{
    internal class GraphicsTransformator : MonoBehaviour
    {
        [Inject] private ITransformator transformator = default;
        [Inject] private IPolygonGraphicsData polygonGraphicsData = default;
        [Inject] private IPolygonGraphicsSettings polygonGraphicsSettings = default;
        [Inject] private IOnTransformationData transformatorEventData = default;
        [Inject] private ICartesianPlaneData cartesianPlaneData = default;

        private float animationSpeed = default;
        private Vector3 origin = default;

        private void Awake ()
        {
            animationSpeed = polygonGraphicsSettings.AnimationSpeed;
            origin = cartesianPlaneData.Origin;
            Points2LogicCoordinates points2LogicCoordinates = polygonGraphicsData.Points2LogicCoordinates;
            foreach (var point2LogicCoordinate in points2LogicCoordinates)
            {
                point2LogicCoordinate.Key.position = Logic2GraphicsCoordinate(point2LogicCoordinate.Value);
            }
        }

        internal void OnTransformation ()
        {
            StartCoroutine(OnTransformationCoroutine());
        }

        private IEnumerator OnTransformationCoroutine ()
        {
            Transformation transformation = transformatorEventData.Transformation;
            Direction direction = transformatorEventData.Direction;
            PartialMatrix partialMatrix = PartialTransformationMatrices.Get(transformation, direction);
            float quantity = transformatorEventData.Quantity;

            Points2LogicCoordinates points2logicCoordinates = polygonGraphicsData.Points2LogicCoordinates;

            float c = 0F;

            if (quantity >= 0F)
            {
                for (c = 0F; c + Time.deltaTime * animationSpeed < quantity; c += Time.deltaTime * animationSpeed)
                {
                    foreach (KeyValuePair<Transform, Vector2> point2logicCoordinate in points2logicCoordinates)
                    {
                        point2logicCoordinate.Key.position = Multiply(partialMatrix(c), point2logicCoordinate.Value);
                    }
                    yield return null;
                }
            }
            else
            {
                for (c = 0F; c - Time.deltaTime * animationSpeed > quantity; c -= Time.deltaTime * animationSpeed)
                {
                    foreach (KeyValuePair<Transform, Vector2> point2logicCoordinate in points2logicCoordinates)
                    {
                        point2logicCoordinate.Key.position = Multiply(partialMatrix(c), point2logicCoordinate.Value);
                    }
                    yield return null;
                }
            }
            foreach (KeyValuePair<Transform, Vector2> point2originalCoordinate in points2logicCoordinates)
            {
                point2originalCoordinate.Key.position = Multiply(partialMatrix(quantity), point2originalCoordinate.Value);
            }
        }

        #region Graphics Transformator Utilities         

        private Vector3 Multiply (Matrix4x4 matrix, Vector2 logicCoordinate)
        {
            return Logic2GraphicsCoordinate(transformator.Multiply(matrix, logicCoordinate));
        }

        private Vector3 Logic2GraphicsCoordinate (Vector2 logicCoordinate)
        {
            return (Vector3)logicCoordinate + origin;
        }

        #endregion
    }
}
