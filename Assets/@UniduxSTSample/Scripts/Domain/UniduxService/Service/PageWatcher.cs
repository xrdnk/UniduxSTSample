using System;
using UniDi;
using Unidux.SceneTransition;
using UniRx;

namespace Deniverse.UniduxSTSample.Domain.Unidux
{
    /// <summary>
    /// ページのステートを監視するクラス
    /// </summary>
    public sealed class PageWatcher : IInitializable, IDisposable
    {
        readonly ISceneConfig<SceneName, PageName> _config = new SceneConfig();
        CompositeDisposable _disposable;

        void IInitializable.Initialize()
        {
            _disposable = new CompositeDisposable();

            // 何らかのステートが変更された時，ページの更新処理を走らせる
            UniduxService.OnStateChangedAsObservable()
                .Where(state => state.Page.IsReady)
                .Subscribe(UpdatePage)
                .AddTo(_disposable);
        }

        void IDisposable.Dispose() => _disposable?.Dispose();

        /// <summary>
        /// 更新されたステートの情報を基にページ情報を更新する
        /// </summary>
        /// <param name="state">更新されたステート</param>
        void UpdatePage(State state)
        {
            // 現状のページステートが古い場合，調整アクションを実行する
            if (state.Scene.NeedsAdjust(_config.GetPageScenes(), _config.PageMap[state.Page.Current.Page]))
            {
                UniduxService.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Adjust());
            }
        }
    }
}