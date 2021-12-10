using System;
using Deniverse.UniduxSTSample.Domain.Unidux;
using UniDi;
using UniRx;

namespace Deniverse.UniduxSTSample.Application.Result
{
    public sealed class ResultPageService : IInitializable, IDisposable
    {
        ResultPageData _initialPageData;

        public IReadOnlyReactiveProperty<double> DamageDoneRp => _damageDoneRp;
        DoubleReactiveProperty _damageDoneRp;

        void IInitializable.Initialize()
        {
            // 初期リザルトページデータの取得
            _initialPageData = UniduxService.State.Page.GetData<ResultPageData>();
            // ダメージ量の設定
            _damageDoneRp = new DoubleReactiveProperty(_initialPageData.DamageAmount);
        }

        void IDisposable.Dispose() => _damageDoneRp?.Dispose();
    }
}