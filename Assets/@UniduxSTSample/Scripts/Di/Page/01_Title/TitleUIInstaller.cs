using Deniverse.UniduxSTSample.View.Title;
using UniDi;

namespace Deniverse.UniduxSTSample.Di
{
    public class TitleUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TitleUIView>().FromComponentInHierarchy().AsCached();
            Container.Bind<LicenceView>().FromComponentInHierarchy().AsCached();
        }
    }
}