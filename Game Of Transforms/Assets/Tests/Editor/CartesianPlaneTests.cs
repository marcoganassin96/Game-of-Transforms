using NUnit.Framework;
using System;

internal class CartesianPlaneTests
{
    [Test]
    public void Throws_Exception_On_Cartesian_Plane_With_Size_Not_Greater_Than_0()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CartesianPlane(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new CartesianPlane(-1));
    }
}

internal class CartesianPlane
{
    private int size;

    public CartesianPlane(int size)
    {
        if (size <= 0 )
        {
            throw new ArgumentOutOfRangeException("Size must be greater than 0");
        }
        this.size = size;
    }
}
