using Deniverse.UniduxSTSample.Domain.Unidux;
using UniDi;
using Unidux.SceneTransition;

namespace Deniverse.UniduxSTSample.Di
{
    public sealed class UniduxServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneWatcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<PageWatcher>().AsSingle();
        }

        void Awake()
        {
            // 起動時，最初にタイトル画面を表示する
            // タイトル画面へ遷移するプッシュアクションを生成
            var pushTitlePageAction = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Title);
            // プッシュアクションのディスパッチ
            UniduxService.Dispatch(pushTitlePageAction);
        }
    }
}