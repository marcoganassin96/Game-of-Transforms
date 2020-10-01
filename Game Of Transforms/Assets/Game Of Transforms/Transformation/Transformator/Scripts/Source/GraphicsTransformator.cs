using Core.GameEvents;
using GameOfTransforms.Transformation.Polygon;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Matrix4x4 = System.Numerics.Matrix4x4;

namespace GameOfTransforms.Transformation.Transformator
{
    internal class GraphicsTransformator : MonoBehaviour
    {
        [SerializeField] private GameEvent OnTransformationFinished = default;

        [Inject] private ITransformator transformator = default;
        [Inject] private IPolygonData polygonData = default;
        [Inject] private IPolygonGraphicsData polygonGraphicsData = default;
        [Inject] private IPolygonGraphicsSettings polygonGraphicsSettings = default;
        [Inject] private ITransformationSettings transformationSettings = default;
        [Inject] private PolygonGraphicsUtils polygonGraphicsUtils = default;

        private Vector3 origin = default;

        private void Awake ()
        {
            Points2LogicCoordinates points2LogicCoordinates = polygonGraphicsData.Points2LogicCoordinates;
            foreach (var point2LogicCoordinate in points2LogicCoordinates)
            {
                point2LogicCoordinate.Key.position = polygonGraphicsUtils.Logic2GraphicsCoordinate(point2LogicCoordinate.Value);
            }
        }

        internal void OnTransformation(Transformation transformation, Direction direction, float quantity)
        {
            StartCoroutine(OnTransformationCoroutine(transformation, direction, quantity));
        }

        private IEnumerator OnTransformationCoroutine(Transformation transformation, Direction direction, float quantity)
        {
            PartialMatrix partialMatrix = PartialTransformationMatrices.Get(transformation, direction);

            Points2LogicCoordinates points2logicCoordinates = polygonGraphicsData.Points2LogicCoordinates;

            float identityElement = transformationSettings.Trasformation2IdentityElement[transformation];

            float animationSpeed = polygonGraphicsSettings.AnimationSpeed(transformation);

            if(quantity >= identityElement)
            {
                for (float c = identityElement; c + Time.deltaTime * animationSpeed < quantity; c += Time.deltaTime * animationSpeed)
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
                for (float c = identityElement; c - Time.deltaTime * animationSpeed > quantity; c -= Time.deltaTime * animationSpeed)
                {
                    foreach (KeyValuePair<Transform, Vector2> point2logicCoordinate in points2logicCoordinates)
                    {
                        point2logicCoordinate.Key.position = Multiply(partialMatrix(c), point2logicCoordinate.Value);
                    }
                    yield return null;
                }
            }

            //update points2logicCoordinates
            Transform[] points = points2logicCoordinates.Keys.ToArray();
            int pointsNum = points.Length; ;
            for (int i = 0; i < pointsNum; ++i)
            {
                Transform point = points[i];
                Vector2 updatedLogicCoordinate = polygonData.Points[i];
                points2logicCoordinates[point] = updatedLogicCoordinate;
                point.position = polygonGraphicsUtils.Logic2GraphicsCoordinate(updatedLogicCoordinate);
            }
            OnTransformationFinished?.Raise();
        }

        #region Graphics Transformator Utilities         

        private Vector3 Multiply (Matrix4x4 matrix, Vector2 logicCoordinate)
        {
            return polygonGraphicsUtils.Logic2GraphicsCoordinate(transformator.Multiply(matrix, logicCoordinate));
        }

        #endregion
    }
}
