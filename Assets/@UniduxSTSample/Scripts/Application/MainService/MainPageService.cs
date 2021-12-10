using System;
using Deniverse.UniduxSTSample.Domain.Unidux;
using UniDi;
using Unidux.SceneTransition;
using UniRx;

namespace Deniverse.UniduxSTSample.Application.Main
{
    public sealed class MainPageService : IInitializable, IDisposable
    {
        MainPageData _mainPageData;

        public IReadOnlyReactiveProperty<double> GodHpRp => _godHpRp;
        DoubleReactiveProperty _godHpRp;

        double _godHp;
        double _damageDone;

        void IInitializable.Initialize()
        {
            // Uniduxから現状のページデータであるMainGameDataを取得する
            var mainPageData = UniduxService.State.Page.GetData<MainPageData>() ?? new MainPageData();
            _godHp = mainPageData.GodHp;
            _damageDone = mainPageData.DamageAmount;
            _mainPageData = mainPageData;
            _godHpRp = new DoubleReactiveProperty(_godHp);
        }

        void IDisposable.Dispose() => _godHpRp?.Dispose();

        /// <summary>
        /// 神に攻撃する処理
        /// </summary>
        public void AttackGod(double damageDeal = 100)
        {
            // 神のヒットポイントがゼロ以下の時，実行しない
            if (_godHp <= 0)
            {
                return;
            }

            // ビジネスロジック
            _godHp -= damageDeal;
            _damageDone += damageDeal;

            // ビュー側に反映
            _godHpRp.Value = _godHp;

            // メインゲームページデータ の更新処理
            _mainPageData.GodHp = _godHp;
            _mainPageData.DamageAmount = _damageDone;

            // ページデータの更新
            var setDataAction = PageDuck<PageName, SceneName>.ActionCreator.SetData(_mainPageData);
            // データ設定アクションでディスパッチ
            UniduxService.Dispatch(setDataAction);
        }
    }
}