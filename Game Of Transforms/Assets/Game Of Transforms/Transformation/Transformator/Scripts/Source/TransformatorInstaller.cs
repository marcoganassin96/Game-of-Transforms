using GameOfTransforms.Events;
using GameOfTransforms.Transformation.Polygon;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Transformator
{
    [CreateAssetMenu(fileName = "Transformator Installer", menuName = "Game Of Transforms/Transformation/Transformator/Transformator Installer")]
    public class TransformatorInstaller : ScriptableObjectInstaller<TransformatorInstaller>
    {
        [SerializeField] private OnTransformationData onTransformationData = default;
        [SerializeField] private PolygonData polygonData = default;
        [SerializeField] private PolygonGraphicsData polygonGraphicsData = default;
        [SerializeField] private PolygonGraphicsSettings polygonGraphicsSettings = default;

        public override void InstallBindings ()
        {
            Container.Bind<IOnTransformationData>().FromInstance(onTransformationData).AsCached();
            Container.Bind<IPolygonData>().FromInstance(polygonData).AsCached();
            Container.Bind<IPolygonGraphicsData>().FromInstance(polygonGraphicsData).AsCached();
            Container.Bind<IPolygonGraphicsSettings>().FromInstance(polygonGraphicsSettings).AsCached();
        }
    }
}
