using System.Collections.Generic;
using Deniverse.UniduxSTSample.Domain.Unidux;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Deniverse.UniduxSTSample.Application.SceneSettings
{
    /// <summary>
    /// エントリーポイント
    /// </summary>
    public sealed class EntryPoint : MonoBehaviour
    {
        void Awake()
        {
            foreach (var scene in _getPermanentScenesWithoutEntryPoint)
            {
                SceneManager.LoadSceneAsync($"{scene}", LoadSceneMode.Additive);
            }
        }

        // エントリーポイントシーンを除いたパーマネントシーンを読み込みたい順番に設定する
        readonly List<SceneName> _getPermanentScenesWithoutEntryPoint = new()
        {
            // シーン全体に共通に必要なコンポーネントが入っているシーン
            SceneName.CommonSystem,
            // Unidux を用いた画面遷移制御を司るドメインシーン
            SceneName.UniduxService,
        };
    }
}