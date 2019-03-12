using NUnit.Framework;
using System;

namespace GameOfTransforms.Tests
{
    internal class CartesianPlaneTests
    {
        [Test]
        public void Throws_Exception_On_Cartesian_Plane_With_Size_Not_Greater_Than_0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CartesianPlaneController(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new CartesianPlaneController(-1));
        }
    }
}
