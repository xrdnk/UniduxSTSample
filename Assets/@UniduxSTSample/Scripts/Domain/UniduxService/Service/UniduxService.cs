using System;
using Unidux;
using UniRx;

namespace Deniverse.UniduxSTSample.Domain.Unidux
{
    /// <summary>
    /// <para>Uniduxのコアサービスクラス</para>
    /// 簡易のため元サンプルに従い今回はSingletonMonoBehaviourを利用することにしている
    /// </summary>
    public sealed class UniduxService : SingletonMonoBehaviour<UniduxService>, IStoreAccessor
    {
        Store<State> _store;
        /// <summary>
        /// ストアインスタンスの取得
        /// </summary>
        static Store<State> Store => Instance._store ??= new Store<State>(InitialState, Reducers);

        /// <summary>
        /// <para>リデューサーの取得</para>
        /// <para>ここで作成した SceneReducer と PageReducer を設定する</para>
        /// </summary>
        static IReducer[] Reducers => new IReducer[] { new SceneReducer(), new PageReducer() };

        /// <summary>
        /// 初期ステートの取得（今回は初期設定なし)
        /// </summary>
        static State InitialState => new();

        /// <summary>
        /// ストアオブジェクトの取得
        /// </summary>
        public IStoreObject StoreObject => Store;

        /// <summary>
        /// ストアで管理しているステートの取得
        /// </summary>
        public static State State => Store.State;

        /// <summary>
        /// ステートのIObservable
        /// </summary>
        public static IObservable<State> OnStateChangedAsObservable()
            => Store.Subject.Where(state => state.Page.IsStateChanged);

        /// <summary>
        /// 受け取ったアクションのディスパッチ処理
        /// </summary>
        public static object Dispatch<TAction>(TAction action) => Store.Dispatch(action);

        /// <summary>
        /// マイフレーム，ストアの更新処理を実行
        /// </summary>
        void Update() => Store.Update();
    }
}