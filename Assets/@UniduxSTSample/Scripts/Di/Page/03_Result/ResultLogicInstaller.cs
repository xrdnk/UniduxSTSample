using Deniverse.UniduxSTSample.Application.Result;
using Deniverse.UniduxSTSample.Presenter.Result;
using UniDi;

namespace Deniverse.UniduxSTSample.Di
{
    public class ResultLogicInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResultPageService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResultPagePresenter>().AsSingle();
        }
    }
}