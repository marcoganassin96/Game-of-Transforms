using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Polygon
{
    internal class PolygonManager : MonoBehaviour
    {
        [Inject] private IPolygonData polygonData = default;
        [Inject] private IPolygonGraphicsData polygonGraphicsData = default;

        private void Start()
        {
            polygonGraphicsData.OnNewPolygon();
        }
    }
}
