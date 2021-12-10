using Deniverse.UniduxSTSample.View.Main;
using UniDi;

namespace Deniverse.UniduxSTSample.Di
{
    public class MainGameUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MainPageUIView>().FromComponentInHierarchy().AsCached();
        }
    }
}