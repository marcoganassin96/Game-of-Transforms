using NSubstitute;
using NUnit.Framework;
using System;
using Zenject;

namespace GameOfTransforms.Tests
{
    internal class CartesianPlaneTests
    {
        [TestFixture]
        internal class CartesianPlaneUnitTestsBase : ZenjectUnitTestFixture
        {
            protected static ICartesianPlaneData GetCartesianPlaneAttributesMock (int size)
            {
                ICartesianPlaneData data = Substitute.For<ICartesianPlaneData>();
                data.Size.Returns(size);
                return data;
            }
        }

        internal class The_Constructor : CartesianPlaneUnitTestsBase
        {
            #region _0_When_SizeInDataIsNotGreaterThan0_Then_ThrowsArgumentException

            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(-23)]
            public void _0_When_SizeInDataIsNotGreaterThan0_Then_ThrowsArgumentException (int size)
            {
                Assert.Throws<ArgumentException>(() => new CartesianPlaneLogic(GetCartesianPlaneAttributesMock(size)));
            }

            #endregion

            #region _1_When_SizeInDataIsGreaterThan0_Then_DoesNotThrowArgumentException

            [TestCase(1)]
            [TestCase(2)]
            [TestCase(20)]
            public void _1_When_SizeInDataIsGreaterThan0_Then_DoesNotThrowArgumentException (int size)
            {
                Assert.DoesNotThrow(() => new CartesianPlaneLogic(GetCartesianPlaneAttributesMock(size)));
            }

            #endregion
        }
    }
}
