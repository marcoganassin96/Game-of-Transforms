using UnityEngine;
using Zenject;

namespace GameOfTransforms
{
    [CreateAssetMenu(fileName = "Cartesian Plane Installer", menuName = "Installers/CartesianPlaneInstaller")]

    internal class CartesianPlaneInstaller : ScriptableObjectInstaller<CartesianPlaneInstaller>
    {
        [SerializeField] private CartesianPlaneGraphicsAttributes graphicsAttributes = default;
        [SerializeField] private CartesianPlaneData data = default;

        public override void InstallBindings ()
        {
            Container.Bind<ICartesianPlaneLogic>().To<CartesianPlaneLogic>().AsCached();
            Container.Bind<ICartesianPlaneGraphicsAttributes>().FromInstance(graphicsAttributes).AsCached();
            Container.Bind<ICartesianPlaneData>().FromInstance(data).AsCached();
        }
    }
}
