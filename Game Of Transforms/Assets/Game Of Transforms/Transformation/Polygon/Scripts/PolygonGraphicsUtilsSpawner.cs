using Zenject;

namespace GameOfTransforms.Transformation.Polygon
{
    internal class PolygonGraphicsUtilsSpawner : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PolygonGraphicsUtils>().AsSingle();
        }
    }
}
