using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Polygon Graphics Data", menuName = "Game Of Transforms/Transformation/Polygon/Polygon Graphics Data")]
    internal class PolygonGraphicsData : ScriptableObject, IPolygonGraphicsData
    {
        [SerializeField] private Points2LogicCoordinates points2LogicCoordinates = default;
        public Points2LogicCoordinates Points2LogicCoordinates => points2LogicCoordinates;

        [Inject] private IPolygonData polygonData = default;
        [Inject] private IPolygonGraphicsSettings polygonGraphicsSettings = default;

        public void OnNewPolygon ()
        {
            points2LogicCoordinates = new Points2LogicCoordinates();
            char label = 'A';
            foreach (Vector2 coordinate in polygonData.Points)
            {
                GameObject point = Instantiate(polygonGraphicsSettings.GraphicalPointPrefab);
                point.name = "Point " + label;
                points2LogicCoordinates.Add(point.transform, coordinate);
                label++;
            }
        }
    }
}
