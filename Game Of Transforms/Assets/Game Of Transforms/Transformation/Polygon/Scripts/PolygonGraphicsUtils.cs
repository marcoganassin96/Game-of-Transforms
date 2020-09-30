using UnityEngine;
using Zenject;
using GameOfTransforms.CartesianPlane;

namespace GameOfTransforms.Transformation.Polygon
{
    public class PolygonGraphicsUtils
    {
        private Vector3 origin;

        [Inject]
        private void Construct(ICartesianPlaneData cartesianPlaneData)
        {
            origin = cartesianPlaneData.Origin;
        }

        public Vector3 Logic2GraphicsCoordinate(Vector2 logicCoordinate)
        {
            return (Vector3)logicCoordinate + origin;
        }
    }
}
