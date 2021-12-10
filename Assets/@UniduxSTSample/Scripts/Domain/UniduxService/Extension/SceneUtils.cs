using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Deniverse.UniduxSTSample.Domain.Unidux.Extension
{
    public static class SceneUtils
    {
        /// <summary>
        /// アクティブなシーンの取得
        /// </summary>
        /// <typeparam name="TScene"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TScene> GetActiveScenes<TScene>() where TScene : struct
        {
            var sceneCount = SceneManager.sceneCount;

            for (var i = 0; i < sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                var enumScene = (TScene)Enum.Parse(typeof(TScene), scene.name);
                yield return enumScene;
            }
        }

        /// <summary>
        /// シーンファイルのロード
        /// </summary>
        /// <param name="name">シーン名</param>
        /// <param name="token">CancellationToken</param>
        public static async UniTask Add(string name, CancellationToken token)
        {
            if (!SceneManager.GetSceneByName(name).isLoaded && !IsAlreadyLoadedScene(name))
            {
                await SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive).WithCancellation(token);
            }
        }

        /// <summary>
        /// シーンファイルのアンロード
        /// </summary>
        /// <param name="name">シーン名</param>
        /// <param name="token">CancellationToken</param>
        public static async UniTask Remove(string name, CancellationToken token)
        {
            if (SceneManager.GetSceneByName(name).isLoaded)
            {
                await SceneManager.UnloadSceneAsync(name).WithCancellation(token);
            }
        }

        /// <summary>
        /// 既に読込済のシーンであるか否か
        /// </summary>
        /// <param name="name">シーン名</param>
        /// <returns>読込済か否か</returns>
        static bool IsAlreadyLoadedScene(string name)
        {
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}