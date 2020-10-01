using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Polygon
{
    internal class PolygonGraphicsData : MonoBehaviour, IPolygonGraphicsData
    {
        [SerializeField] private Points2LogicCoordinates points2LogicCoordinates = default;
        public Points2LogicCoordinates Points2LogicCoordinates => points2LogicCoordinates;

        [Inject] private IPolygonData polygonData = default;
        [Inject] private IPolygonGraphicsSettings polygonGraphicsSettings = default;
        [Inject] private PolygonGraphicsUtils polygonGraphicsUtils = default;

        public void OnNewPolygon ()
        {
            points2LogicCoordinates = new Points2LogicCoordinates();
            char label = 'A';
            foreach (Vector2 coordinate in polygonData.Points)
            {
                Transform point = Instantiate(polygonGraphicsSettings.GraphicalPointPrefab).transform;
                point.name = "Point " + label;
                point.position = polygonGraphicsUtils.Logic2GraphicsCoordinate(coordinate);
                points2LogicCoordinates.Add(point.transform, coordinate);
                label++;
            }
        }
    }
}
