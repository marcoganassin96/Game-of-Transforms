using NUnit.Framework;
using System.Numerics;
using GameOfTransforms.Transformation.Polygon;
using NSubstitute;
using System.Collections.Generic;
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
    }
}
