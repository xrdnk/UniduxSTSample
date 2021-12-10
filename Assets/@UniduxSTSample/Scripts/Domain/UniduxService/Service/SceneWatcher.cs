using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Deniverse.UniduxSTSample.Domain.Unidux.Extension;
using UniDi;
using Unidux.SceneTransition;
using UniRx;

namespace Deniverse.UniduxSTSample.Domain.Unidux
{
    /// <summary>
    /// シーンの状態に変更が発生した際に監視するクラス
    /// </summary>
    public sealed class SceneWatcher : IInitializable, IDisposable
    {
        CompositeDisposable _disposable;

        void IInitializable.Initialize()
        {
            _disposable = new CompositeDisposable();

            // 何らかのステートが変更された時，シーンの更新処理を実行する
            UniduxService.OnStateChangedAsObservable()
                .Subscribe(state => _ = ChangeScenes(state.Scene))
                .AddTo(_disposable);
        }

        void IDisposable.Dispose() => _disposable?.Dispose();

        /// <summary>
        /// <para>シーン変更処理</para>
        /// <para>古いシーンをアンロード(減算ロード)して受け取った新しいシーンのステートに合ったシーンファイル群を加算ロードする</para>
        /// </summary>
        /// <param name="sceneState">シーンのステート</param>
        /// <param name="token">CancellationToken</param>
        async UniTaskVoid ChangeScenes(SceneState<SceneName> sceneState, CancellationToken token = default)
        {
            // シーンファイル群の減算処理
            foreach (var scene in sceneState.Removals(SceneUtils.GetActiveScenes<SceneName>()).OrderBy(x => (int)x))
            {
                await SceneUtils.Remove($"{scene}", token);
            }

            // シーンファイル群の加算処理
            foreach (var scene in sceneState.Additionals(SceneUtils.GetActiveScenes<SceneName>()).OrderBy(x => (int)x))
            {
                await SceneUtils.Add($"{scene}", token);
            }
        }
    }
}