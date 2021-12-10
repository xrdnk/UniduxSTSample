using System;
using Unidux.SceneTransition;

namespace Deniverse.UniduxSTSample.Application.Main
{
    /// <summary>
    /// ゲーム画面用のページデータ
    /// </summary>
    [Serializable]
    public class MainPageData : IPageData
    {
        /// <summary>
        /// 神のヒットポイント
        /// </summary>
        public double GodHp { get; set; }
        /// <summary>
        /// 主人公が与えたダメージ量
        /// </summary>
        public double DamageAmount { get; set; }

        MainPageData() { }

        public MainPageData(double defaultGodHp = 9000, double defaultDamageDone = 0)
        {
            GodHp = defaultGodHp;
            DamageAmount = defaultDamageDone > 0 ? defaultDamageDone : 0;
        }
    }
}