using System.Collections.Generic;
using Unidux.SceneTransition;

namespace Deniverse.UniduxSTSample.Domain.Unidux
{
    /// <summary>
    /// シーン設定を行うクラス
    /// </summary>
    public class SceneConfig : ISceneConfig<SceneName, PageName>
    {
        /// <summary>
        /// カテゴリーマップの設定
        /// <remarks>ここにシーンファイルとカテゴリーの紐づけを行う</remarks>
        /// </summary>
        public IDictionary<SceneName, int> CategoryMap { get; } =
            new Dictionary<SceneName, int>
        {
            // Permanent Scene 設定
            {SceneName.EntryPoint, SceneCategory.Permanent},
            {SceneName.CommonSystem, SceneCategory.Permanent},
            {SceneName.UniduxService, SceneCategory.Permanent},

            // Title Page Scene 設定
            {SceneName.Title_UI, SceneCategory.Page},
            {SceneName.Title_Logic, SceneCategory.Page},

            // Main Page Scene 設定
            {SceneName.Main_UI, SceneCategory.Page},
            {SceneName.Main_Logic, SceneCategory.Page},
            {SceneName.Main_Level, SceneCategory.Page},

            // Result Page Scene 設定
            {SceneName.Result_UI, SceneCategory.Page},
            {SceneName.Result_Logic, SceneCategory.Page}
        };

        /// <summary>
        /// ページマップの設定
        /// <remarks>ページとシーンファイル群の紐づけを行う</remarks>
        /// </summary>
        public IDictionary<PageName, SceneName[]> PageMap { get; } =
            new Dictionary<PageName, SceneName[]>
        {
            // タイトルページのシーン設定
            {PageName.Title, new[]
            {
                SceneName.Title_UI,
                SceneName.Title_Logic,
            }},

            // メインゲームページのシーン設定
            {PageName.Main, new []
            {
                SceneName.Main_UI,
                SceneName.Main_Logic,
                SceneName.Main_Level,
            }},

            // リザルトページのシーン設定
            {PageName.Result, new []
            {
                SceneName.Result_UI,
                SceneName.Result_Logic
            }}
        };
    }
}