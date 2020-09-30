using GameOfTransforms.Events;
using GameOfTransforms.Transformation.Polygon;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Transformator.Tests.Graphics
{
    internal class GraphicsTransformatorTests : MonoBehaviour
    {
        [SerializeField] private GraphicsTransformator graphicsTransformator = default;
        [SerializeField] private Transformation transformation = default;
        [SerializeField] private Direction direction = default;
        [SerializeField] private float quantity = default;
        
        [Inject] private IPolygonGraphicsData polygonGraphicsData = default;
        [Inject] private IOnTransformationData onTransformatorEventData = default;

        private void Awake ()
        {
            polygonGraphicsData.OnNewPolygon();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                onTransformatorEventData.SetTransformationData(transformation, direction, quantity);
                graphicsTransformator.OnTransformation(transformation, direction, quantity);
            }
        }
    }
}
