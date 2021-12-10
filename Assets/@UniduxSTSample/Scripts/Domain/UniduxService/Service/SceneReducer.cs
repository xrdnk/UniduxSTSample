using Unidux.SceneTransition;

namespace Deniverse.UniduxSTSample.Domain.Unidux
{
    /// <summary>
    /// シーンのステートを変更するクラス
    /// </summary>
    public sealed class SceneReducer : SceneDuck<SceneName>.Reducer
    {
        /// <summary>
        /// シーンのステートを変更
        /// </summary>
        /// <param name="state">シーンのステート</param>
        /// <param name="action">シーンのステートを変更するアクション</param>
        /// <returns></returns>
        public override object ReduceAny(object state, object action)
        {
            var s = (State) state;
            var a = (SceneDuck<SceneName>.Action) action;
            s.Scene = base.Reduce(s.Scene, a);
            return state;
        }
    }
}