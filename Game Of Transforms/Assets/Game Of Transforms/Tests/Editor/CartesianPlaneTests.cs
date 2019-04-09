using NSubstitute;
using NUnit.Framework;
using System;

namespace GameOfTransforms.Tests
{
    internal class CartesianPlaneTests
    {
        [TestFixture]
        internal class The_Constructor : CartesianPlaneTests
        {
            #region _0_Throws_Exception_On_Cartesian_Plane_With_Size_Not_Greater_Than_0

            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(-23)]
            public void _0_Throws_Exception_On_Cartesian_Plane_With_Size_Not_Greater_Than_0(int size)
            {
                Assert.Throws<ArgumentException>(() => new CartesianPlaneLogic(GetCartesianPlaneAttributesMock(size)));
            }

            #endregion

            #region _1_Does_Not_Throw_Exception_On_Cartesian_Plane_With_Size_Greater_Than_0

            [TestCase(1)]
            [TestCase(2)]
            [TestCase(20)]
            public void _1_Does_Not_Throw_Exception_On_Cartesian_Plane_With_Size_Greater_Than_0 (int size)
            {
                Assert.DoesNotThrow(() => new CartesianPlaneLogic(GetCartesianPlaneAttributesMock(size)));
            }

            #endregion
        }

        private ICartesianPlaneData GetCartesianPlaneAttributesMock(int size)
        {
            ICartesianPlaneData data = Substitute.For<ICartesianPlaneData>();
            data.Size.Returns(size);
            return data;
        }
    }
}
