using Deniverse.UniduxSTSample.Navigator.Title;
using UniDi;

namespace Deniverse.UniduxSTSample.Di
{
    public class TitleLogicInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TitlePageViewNavigator>().AsSingle();
        }
    }
}