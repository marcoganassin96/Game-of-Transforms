namespace GameOfTransforms
{
    public interface ICartesianPlaneGraphics
    {
        ICartesianPlaneData Data { get; }
        ICartesianPlaneGraphicsAttributes Attributes { get; }
        void DrawCartesianPlane ();
    }
}
