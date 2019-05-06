using GameOfTransforms.Events;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.Transformation.Polygon
{
    [CreateAssetMenu(fileName = "Polygon Installer", menuName = "Game Of Transforms/Transformation/Polygon/Polygon Installer")]
    internal class PolygonInstaller : ScriptableObjectInstaller<PolygonInstaller>
    {
        [SerializeField] private OnNewPolygonData onNewPolygonData = default;
        [SerializeField] private OnNewPolygonGraphicsData onNewPolygonGraphicsData = default;

        public override void InstallBindings ()
        {
            Container.Bind<IOnNewPolygonData>().FromInstance(onNewPolygonData).AsCached();
            Container.Bind<IOnNewPolygonGraphicsData>().FromInstance(onNewPolygonGraphicsData).AsCached();
        }
    }
}
