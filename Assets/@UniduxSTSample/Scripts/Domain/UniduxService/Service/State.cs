using System;
using Unidux;
using Unidux.SceneTransition;

namespace Deniverse.UniduxSTSample.Domain.Unidux
{
    /// <summary>
    /// ステートエンティティ
    /// <para>状態を持つ項目を設定する</para>
    /// <para>今回はシーンとページを設定している</para>
    /// </summary>
    [Serializable]
    public class State : StateBase
    {
        public PageState<PageName> Page { get; set; } = new();
        public SceneState<SceneName> Scene { get; set; } = new();
    }
}