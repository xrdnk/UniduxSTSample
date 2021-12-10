using Unidux.SceneTransition;

namespace Deniverse.UniduxSTSample.Domain.Unidux
{
    /// <summary>
    /// ページのステートを変更するクラス
    /// </summary>
    public sealed class PageReducer : PageDuck<PageName, SceneName>.Reducer
    {
        public PageReducer() : base(new SceneConfig()) { }

        /// <summary>
        /// ページのステートを変更する
        /// </summary>
        /// <param name="state">ページのステート</param>
        /// <param name="action">ページのステートを変更するアクション</param>
        /// <returns></returns>
        public override object ReduceAny(object state, object action)
        {
            var s = (State) state;
            var a = (PageDuck<PageName, SceneName>.IPageAction) action;
            s.Page = base.Reduce(s.Page, s.Scene, a);
            return state;
        }
    }
}