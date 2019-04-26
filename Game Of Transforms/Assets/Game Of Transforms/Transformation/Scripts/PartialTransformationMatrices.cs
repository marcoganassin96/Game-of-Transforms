using System;
using System.Collections.Generic;
using System.Numerics;

namespace GameOfTransform.Transformation
{
    public class PartialTransformationMatrices
    {
        #region Partial Matrices

        #region Translations

        public static PartialMatrix HorizontalTranslation { get; } = delegate (int c)
        {
            return new Matrix4x4(
                1, 0, 0, c,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        };

        public static PartialMatrix VerticalTranslation { get; } = delegate (int c)
        {
            return new Matrix4x4(
                1, 0, 0, 0,
                0, 1, 0, c,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        };

        #endregion

        #region Rotations

        public static PartialMatrix OriginRotation { get; } = delegate (int c)
        {
            float m11 = Convert.ToSingle(Math.Cos(c));
            float m12 = Convert.ToSingle(-Math.Sin(c));
            float m21 = Convert.ToSingle(Math.Sin(c));
            float m22 = Convert.ToSingle(Math.Cos(c));

            return new Matrix4x4(
                m11, m12, 0, 0,
                m21, m22, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        };

        #endregion

        #region Scalings

        public static PartialMatrix HorizontalScaling { get; } = delegate (int c)
        {
            return new Matrix4x4(
                c, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        };

        public static PartialMatrix VerticalScaling { get; } = delegate (int c)
        {
            return new Matrix4x4(
                1, 0, 0, 0,
                0, c, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        };

        public static PartialMatrix OriginScaling { get; } = delegate (int c)
        {
            return new Matrix4x4(
                c, 0, 0, 0,
                0, c, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        };

        #endregion

        #region Reflections

        public static PartialMatrix HorizontalReflection { get; } = delegate (int c)
        {
            return new Matrix4x4(
                -1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        };

        public static PartialMatrix VerticalReflection { get; } = delegate (int c)
        {
            return new Matrix4x4(
                1, 0, 0, 0,
                0, -1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        };

        public static PartialMatrix OriginReflection { get; } = delegate (int c)
        {
            return new Matrix4x4(
                -1, 0, 0, 0,
                0, -1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );
        };

        #endregion

        #endregion

        private Dictionary<Transformation, Dictionary<Direction, PartialMatrix>> Matrices { get; } =
            new Dictionary<Transformation, Dictionary<Direction, PartialMatrix>>
            {
                {
                    Transformation.Translation,
                    new Dictionary<Direction, PartialMatrix>
                    {
                        { Direction.X, HorizontalTranslation },
                        { Direction.Y, VerticalTranslation },
                    }
                },
                {
                    Transformation.Rotation,
                    new Dictionary<Direction, PartialMatrix>
                    {
                        { Direction.O, OriginRotation }
                    }
                },
                {
                    Transformation.Scaling,
                    new Dictionary<Direction, PartialMatrix>
                    {
                        { Direction.X, HorizontalScaling },
                        { Direction.Y, VerticalScaling },
                        { Direction.O, OriginScaling }
                    }
                },
                {
                    Transformation.Reflection,
                    new Dictionary<Direction, PartialMatrix>
                    {
                        { Direction.X, HorizontalReflection },
                        { Direction.Y, VerticalReflection },
                        { Direction.O, OriginReflection }
                    }
                }
            };

        public PartialMatrix this[Transformation transformation, Direction direction]
        {
            get
            {
                return Matrices[transformation][direction];
            }
        }
    }
}
