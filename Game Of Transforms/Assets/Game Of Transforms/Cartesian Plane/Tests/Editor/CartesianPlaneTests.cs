using Core.Args;
using NSubstitute;
using NUnit.Framework;
using System;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Tests
{
    internal class CartesianPlaneTests
    {
        [TestFixture]
        internal class CartesianPlaneUnitTestsBase : ZenjectUnitTestFixture
        {
            protected static ICartesianPlaneData GetCartesianPlaneDataMock (int size)
            {
                ICartesianPlaneData data = Substitute.For<ICartesianPlaneData>();
                data.Size.Returns(size);
                return data;
            }
        }

        internal class _0_The_Constructor : CartesianPlaneUnitTestsBase
        {
            #region _0_When_SizeInDataIsNotGreaterThan0_Then_ThrowsArgumentException
            
            [TestCaseSource("_0_testCaseSourceArguments")]
            public void _0_When_SizeInDataIsNotGreaterThan0_Then_ThrowsArgumentException (CartesianPlaneLogicArgs args)
            {
                Assert.Throws<ArgumentException>(() => new CartesianPlaneLogic(args.Data));
            }

            private static readonly object[] _0_testCaseSourceArguments =
            {
                new object[] { new CartesianPlaneLogicArgs(0) },
                new object[] { new CartesianPlaneLogicArgs(-1) },
                new object[] { new CartesianPlaneLogicArgs(-23) },
            };

            #endregion

            #region _1_When_SizeInDataIsGreaterThan0_Then_DoesNotThrowExceptions

            [TestCaseSource("_1_testCaseSourceArguments")]
            public void _1_When_SizeInDataIsGreaterThan0_Then_DoesNotThrowExceptions (CartesianPlaneLogicArgs args)
            {
                Assert.DoesNotThrow(() => new CartesianPlaneLogic(args.Data));
            }

            private static readonly object[] _1_testCaseSourceArguments =
            {
                new object[] { new CartesianPlaneLogicArgs(1) },
                new object[] { new CartesianPlaneLogicArgs(2) },
                new object[] { new CartesianPlaneLogicArgs(20) },
            };

            #endregion

            internal class CartesianPlaneLogicArgs : AArgs
            {
                public ICartesianPlaneData Data {get;}

                public CartesianPlaneLogicArgs(int size)
                {
                    Data = GetCartesianPlaneDataMock(size);
                }

                public override string GetArgs ()
                {                    
                    return string.Format("size={0}", Data.Size);
                }
            }
        }

        internal class _1_The_Coordinate_Access : CartesianPlaneUnitTestsBase
        {
            #region _0_When_AccessToCoordinatesOutOfDataSize_Then_ThrowsArgumentOutOfRangeException

            [TestCaseSource("_0_testCaseSourceArguments")]
            public void _0_When_AccessToCoordinatesOutOfDataSize_Then_ThrowsArgumentOutOfRangeException (CartesianPlaneLogicCoordinatesAccessArgs args)
            {
                int x = args.X;
                int y = args.Y;
                Assert.Throws<ArgumentOutOfRangeException>(() => {
                    CartesianPlaneLogic logic = new CartesianPlaneLogic(args.Data);
                    Vector3 result = logic[x, y];
                });
            }

            private static readonly object[] _0_testCaseSourceArguments =
            {
                new object[] { new CartesianPlaneLogicCoordinatesAccessArgs(1,  2,  1) },
                new object[] { new CartesianPlaneLogicCoordinatesAccessArgs(10, 8,  -12) },
                new object[] { new CartesianPlaneLogicCoordinatesAccessArgs(20, 21, -45) },
            };

            #endregion

            internal class CartesianPlaneLogicCoordinatesAccessArgs : AArgs
            {
                public ICartesianPlaneData Data { get; }
                public int X { get; }
                public int Y { get; }

                public CartesianPlaneLogicCoordinatesAccessArgs (int size, int x, int y)
                {
                    Data = GetCartesianPlaneDataMock(size);
                    X = x;
                    Y = y;
                }

                public override string GetArgs ()
                {
                    return string.Format("size={0},x={1},y={2}", Data.Size, X, Y);
                }
            }
        }
    }
}
