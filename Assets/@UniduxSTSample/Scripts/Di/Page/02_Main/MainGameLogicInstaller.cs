using Deniverse.UniduxSTSample.Application.Main;
using Deniverse.UniduxSTSample.Presenter.Main;
using UniDi;

namespace Deniverse.UniduxSTSample.Di
{
    public class MainGameLogicInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainPageService>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainPagePresenter>().AsSingle();
        }
    }
}