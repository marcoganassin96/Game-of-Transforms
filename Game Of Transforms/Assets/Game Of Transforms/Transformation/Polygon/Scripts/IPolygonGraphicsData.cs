namespace GameOfTransforms.Transformation.Polygon
{
    public interface IPolygonGraphicsData
    {
        Points2LogicCoordinates Points2LogicCoordinates { get; }
        void OnNewPolygon();
    }
}
