using Deniverse.UniduxSTSample.View.Result;
using UniDi;

namespace Deniverse.UniduxSTSample.Di
{
    public class ResultUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ResultPageUIView>().FromComponentsInHierarchy().AsSingle();
        }
    }
}