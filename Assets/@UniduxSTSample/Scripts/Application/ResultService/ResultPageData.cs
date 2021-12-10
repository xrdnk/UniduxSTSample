using System;
using Unidux.SceneTransition;

namespace Deniverse.UniduxSTSample.Application.Result
{
    /// <summary>
    /// リザルト画面用のページデータ
    /// </summary>
    [Serializable]
    public class ResultPageData : IPageData
    {
        /// <summary>
        /// ダメージ量
        /// </summary>
        public double DamageAmount { get; set; }

        ResultPageData() { }

        public ResultPageData(double damageAmount) => DamageAmount = damageAmount > 0 ? damageAmount : 0;
    }
}