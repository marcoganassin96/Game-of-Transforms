﻿namespace GameOfTransforms.CartesianPlane
{
    public interface ICartesianPlaneGraphics
    {
        ICartesianPlaneData Data { get; }
        ICartesianPlaneGraphicsAttributes Attributes { get; }
        void DrawCartesianPlane ();
    }
}
