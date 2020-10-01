using Zenject;

namespace GameOfTransforms.GameFlow
{
    public class GameFlowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameFlowData>().AsSingle();
        }
    }
}
