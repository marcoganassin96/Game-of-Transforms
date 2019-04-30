using NUnit.Framework;
using System.Numerics;
using Core.Args;
using GameOfTransforms.Transformation.Polygon;
using NSubstitute;
using System.Collections.Generic;
using GameOfTransforms.Events;
using Zenject;

namespace GameOfTransforms.Transformation.Transformator.Tests
{
    internal class TransformatorTests : ZenjectUnitTestFixture
    {
        [TestFixture]
        internal class TransformatorUnitTestsBase : ZenjectUnitTestFixture
        {
            protected static IPolygonData GetPolygonDataMock (List<Vector2> points)
            {
                IPolygonData polygonData = Substitute.For<IPolygonData>();
                polygonData.Points.Returns(points);
                return polygonData;
            }
            protected static PartialTransformationMatrices ptm = new PartialTransformationMatrices();
        }

        internal class _0_The_Transformator : TransformatorUnitTestsBase
        {
            #region _0_WhenTransformationIsAppliedToPolygon_Then_ObtainsExpectedPolygon

            [TestCaseSource("_0_testCaseSourceArguments")]
            public void _0_WhenTransformationIsAppliedToPolygon_Then_ObtainsExpectedPolygon (OnPolygonTransformationArgs args)
            {
                Container.Bind<IOnNewPolygonData>().To<OnNewPolygonData>().AsCached();
                IOnNewPolygonData onNewPolygonData = Container.Resolve<IOnNewPolygonData>();
                onNewPolygonData.Points = args.Coordinates;

                Container.Bind<IOnTransformationData>().To<OnTransformationData>().AsCached();
                IOnTransformationData onTransformationData = Container.Resolve<IOnTransformationData>();
                onTransformationData.TransformationMatrix = new TransformationMatrix(ptm[args.Transformation, args.Direction], args.Quantity);

                Container.Bind<IPolygonData>().To<PolygonData>().AsCached();
                IPolygonData polygonData = Container.Resolve<IPolygonData>();

                polygonData.OnNewPolygon();

                Container.Bind<ITransformator>().To<Transformator>().AsCached();
                ITransformator transformator = Container.Resolve<ITransformator>();
                transformator.OnTransformation();

                Assert.AreEqual(args.ExpectedResult.Points, polygonData.Points);
            }

            #region Test Case Source Arguments 

            private static List<Vector2> ArbitraryCoordinates =>
                new List<Vector2>
                {
                    new Vector2 (4, 0),
                    new Vector2 (2, -4),
                    new Vector2 (-6, 8)
                };

            #region Polygon Transformations

            #region Polygon Translation

            private static OnPolygonTransformationArgs OnPolygonHorizontalTranslationArgs =>
                new OnPolygonTransformationArgs
                (
                    ArbitraryCoordinates,
                    Transformation.Translation, Direction.X, 4,
                    GetPolygonDataMock(new List<Vector2>
                    {
                        new Vector2 (8, 0),
                        new Vector2 (6, -4),
                        new Vector2 (-2, 8)
                    })
                );

            private static OnPolygonTransformationArgs OnPolygonVerticalTranslationArgs =>
                new OnPolygonTransformationArgs
                (
                    ArbitraryCoordinates,
                    Transformation.Translation, Direction.Y, -3,
                    GetPolygonDataMock(new List<Vector2>
                    {
                        new Vector2 (4, -3),
                        new Vector2 (2, -7),
                        new Vector2 (-6, 5)
                    })
                );

            #endregion

            #region Polygon Rotation

            private static OnPolygonTransformationArgs OnPolygonOriginRotationArgs =>
                new OnPolygonTransformationArgs
                (
                    ArbitraryCoordinates,
                    Transformation.Rotation, Direction.O, -90,
                    GetPolygonDataMock(new List<Vector2>
                    {
                        new Vector2 (0, -4),
                        new Vector2 (-4, -2),
                        new Vector2 (8, 6)
                    })
                );

            #endregion

            #region Polygon Scaling

            private static OnPolygonTransformationArgs OnPolygonHorizontalScalingArgs =>
                new OnPolygonTransformationArgs
                (
                    ArbitraryCoordinates,
                    Transformation.Scaling, Direction.X, 2,
                    GetPolygonDataMock(new List<Vector2>
                    {
                        new Vector2 (8, 0),
                        new Vector2 (4, -4),
                        new Vector2 (-12, 8)
                    })
                );

            private static OnPolygonTransformationArgs OnPolygonVerticalScalingArgs =>
                new OnPolygonTransformationArgs
                (
                    ArbitraryCoordinates,
                    Transformation.Scaling, Direction.Y, 0.5F,
                    GetPolygonDataMock(new List<Vector2>
                    {
                        new Vector2 (4, 0),
                        new Vector2 (2, -2),
                        new Vector2 (-6, 4)
                    })
                );

            private static OnPolygonTransformationArgs OnPolygonOriginScalingArgs =>
                new OnPolygonTransformationArgs
                (
                    ArbitraryCoordinates,
                    Transformation.Scaling, Direction.O, .5F,
                    GetPolygonDataMock(new List<Vector2>
                    {
                        new Vector2 (2, 0),
                        new Vector2 (1, -2),
                        new Vector2 (-3, 4)
                    })
                );

            #endregion

            #region Polygon Reflection

            private static OnPolygonTransformationArgs OnPolygonHorizontalReflection =>
                new OnPolygonTransformationArgs
                (
                    ArbitraryCoordinates,
                    Transformation.Reflection, Direction.X,
                    GetPolygonDataMock(new List<Vector2>
                    {
                        new Vector2 (-4, 0),
                        new Vector2 (-2, -4),
                        new Vector2 (6, 8)
                    })
                );

            private static OnPolygonTransformationArgs OnPolygonVerticalReflectionArgs =>
                new OnPolygonTransformationArgs
                (
                    ArbitraryCoordinates,
                    Transformation.Reflection, Direction.Y,
                    GetPolygonDataMock(new List<Vector2>
                    {
                        new Vector2 (4, 0),
                        new Vector2 (2, 4),
                        new Vector2 (-6, -8)
                    })
                );

            private static OnPolygonTransformationArgs OnPolygonOriginReflectionArgs =>
                new OnPolygonTransformationArgs
                (
                    ArbitraryCoordinates,
                    Transformation.Reflection, Direction.O,
                    GetPolygonDataMock(new List<Vector2>
                    {
                        new Vector2 (-4, 0),
                        new Vector2 (-2, 4),
                        new Vector2 (6, -8)
                    })
                );

            #endregion

            #endregion

            private static object[] _0_testCaseSourceArguments =>
            new object[]
            {
                OnPolygonHorizontalTranslationArgs,
                OnPolygonVerticalTranslationArgs,
                OnPolygonOriginRotationArgs,
                OnPolygonHorizontalScalingArgs,
                OnPolygonVerticalScalingArgs,
                OnPolygonOriginScalingArgs,
                OnPolygonHorizontalReflection,
                OnPolygonVerticalReflectionArgs,
                OnPolygonOriginReflectionArgs
            };

            #endregion

            #endregion

            internal class OnPolygonTransformationArgs : AArgs
            {
                public List<Vector2> Coordinates { get; }
                public Transformation Transformation { get; }
                public Direction Direction { get; }
                public float Quantity { get; }
                public IPolygonData ExpectedResult { get; }

                internal OnPolygonTransformationArgs (List<Vector2> coordinates, Transformation transformation, Direction direction, float quantity, IPolygonData expectedResult)
                {
                    Coordinates = coordinates;
                    Transformation = transformation;
                    Direction = direction;
                    Quantity = quantity;
                    ExpectedResult = expectedResult;
                }

                internal OnPolygonTransformationArgs (List<Vector2> coordinates, Transformation transformation, Direction direction, IPolygonData expectedResult)
                {
                    Coordinates = coordinates;
                    Transformation = transformation;
                    Direction = direction;
                    Quantity = 0;
                    ExpectedResult = expectedResult;
                }

                public override string GetArgs ()
                {
                    return string.Format("transformation={0}({1})", Transformation, Direction);
                }
            }
        }
    }
}
