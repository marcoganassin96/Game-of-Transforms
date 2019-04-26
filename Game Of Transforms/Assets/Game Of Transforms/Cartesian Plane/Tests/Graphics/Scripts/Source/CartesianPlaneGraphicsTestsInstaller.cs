using UnityEngine;
using Zenject;

namespace GameOfTransforms.CartesianPlane.Tests.Graphics
{
    [CreateAssetMenu(fileName = "Cartesian Plane Graphics Tests Installer", menuName = "Game Of Transforms/Graphics Tests/Cartesian Plane Graphics Tests Installer")]
    internal class CartesianPlaneGraphicsTestsInstaller : ScriptableObjectInstaller<CartesianPlaneGraphicsTestsInstaller>
    {
        [SerializeField] private CartesianPlaneGraphicsTestsData data = default;

        public override void InstallBindings ()
        {
            Container.Bind<ICartesianPlaneGraphicsTestsData>().FromInstance(data).AsCached();
        }
    }


}
