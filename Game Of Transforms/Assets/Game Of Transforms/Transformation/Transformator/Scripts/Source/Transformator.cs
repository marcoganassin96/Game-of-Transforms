﻿using Core.GameEvents;
using GameOfTransforms.GameFlow;
using GameOfTransforms.Transformation.Polygon;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Matrix4x4 = System.Numerics.Matrix4x4;

namespace GameOfTransforms.Transformation.Transformator
{
    public class Transformator : ITransformator
    {
        [Inject] private IPolygonData polygonData = default;

        [Inject] private GameFlowData gameFlowData = default;

        [Inject(Id = "PositionReached")] private GameEvent PositionReached = default;

        private bool positionReached = default;

        public void OnTransformation (Transformation transformation, Direction direction, float quantity)
        {
            Matrix4x4 matrix = PartialTransformationMatrices.Get(transformation, direction)(quantity);

            positionReached = true;
            List<Vector2> winningPointsPositions  = gameFlowData.WinningPointsPositions;

            for (int i = 0; i < polygonData.Points.Count; ++i)
            {
                polygonData.Points[i] = Multiply(matrix, polygonData.Points[i]);
                if (polygonData.Points[i] != winningPointsPositions[i])
                {
                    positionReached = false;
                }
                if (positionReached) PositionReached?.Raise();
            }
        }

        public Vector2 Multiply (Matrix4x4 matrix, Vector2 point)
        {
            return Matrix2Vector(Matrix4x4.Multiply(matrix, Vector2Matrix(point)));
        }

        #region Transformator Utilities

        private Matrix4x4 Vector2Matrix (Vector2 point)
        {
            float x = Mathf.Round(point.x * 100) / 100F;
            float y = Mathf.Round(point.y * 100) / 100F;
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
