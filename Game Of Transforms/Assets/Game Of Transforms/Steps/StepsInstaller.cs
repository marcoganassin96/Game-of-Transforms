using UnityEngine;
using Zenject;

namespace GameOfTransforms.Steps
{
    internal class StepsInstaller : MonoInstaller
    {
        [SerializeField] private StepsLogic logic = default;
        [SerializeField] private StepsUI UI       = default;

        public override void InstallBindings()
        {
            Container.Bind<StepsData>().AsSingle();
            Container.Bind<StepsLogic>().FromInstance(logic);
            Container.Bind<StepsUI>().FromInstance(UI);
        }
    }
}
