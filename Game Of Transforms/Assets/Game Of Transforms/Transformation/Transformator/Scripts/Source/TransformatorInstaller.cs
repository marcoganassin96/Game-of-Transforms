using GameOfTransforms.Events;
using GameOfTransforms.Transformation.Polygon;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Transformator
{
    [CreateAssetMenu(fileName = "Transformator Installer", menuName = "Game Of Transforms/Transformation/Transformator/Transformator Installer")]
    internal class TransformatorInstaller : MonoInstaller
    {
        [SerializeField] private OnTransformationData onTransformationData = default;
        [SerializeField] private OnNewPolygonData onNewPolygonData = default;
        [SerializeField] private PolygonData polygonData = default;
        [SerializeField] private PolygonGraphicsData polygonGraphicsData = default;
        [SerializeField] private PolygonGraphicsSettings polygonGraphicsSettings = default;
        [SerializeField] private TransformationSettings transformationSettings = default;

        public override void InstallBindings ()
        {
            Container.Bind<ITransformator>().To<Transformator>().AsCached();
            Container.Bind<IOnTransformationData>().FromInstance(onTransformationData).AsSingle();
            Container.Bind<IOnNewPolygonData>().FromInstance(onNewPolygonData).AsCached();
            Container.QueueForInject(onNewPolygonData);
            Container.Bind<IPolygonData>().FromInstance(polygonData).AsCached();
            Container.QueueForInject(polygonData);
            Container.Bind<IPolygonGraphicsData>().FromInstance(polygonGraphicsData).AsCached();
            Container.QueueForInject(polygonGraphicsData);
            Container.Bind<IPolygonGraphicsSettings>().FromInstance(polygonGraphicsSettings).AsCached();
            Container.QueueForInject(polygonGraphicsSettings);
            Container.Bind<ITransformationSettings>().FromInstance(transformationSettings).AsCached();
        }
    }
}
