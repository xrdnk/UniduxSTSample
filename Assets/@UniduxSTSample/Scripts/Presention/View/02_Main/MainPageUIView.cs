using System;
using Deniverse.UniduxSTSample.Application.Main;
using Deniverse.UniduxSTSample.Application.Result;
using Deniverse.UniduxSTSample.Domain.Unidux;
using TMPro;
using Unidux.SceneTransition;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Deniverse.UniduxSTSample.View.Main
{
    /// <summary>
    /// ゲーム画面の汎用ビュークラス
    /// </summary>
    public class MainPageUIView : UIViewBase
    {
        [SerializeField] Button _buttonAttackGod;
        [SerializeField] Button _buttonEnterResultPage;
        [SerializeField] Button _buttonReturnTitlePage;
        [SerializeField] TMP_Text _textGodHp;

        readonly Subject<Unit> _attackedSubject = new();
        public IObservable<Unit> OnAttackedAsObservable() => _attackedSubject;

        protected override void Awake()
        {
            _buttonAttackGod
                .OnClickAsObservable()
                .Subscribe(_ => _attackedSubject.OnNext(Unit.Default))
                .AddTo(this);

            _buttonEnterResultPage
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // 現状のメインページデータの状態を取得する
                    var mainPageData = UniduxService.State.Page.GetData<MainPageData>();
                    // 取得したデータからダメージ量のデータをリザルトページデータに渡す
                    var resultPageData = new ResultPageData(mainPageData.DamageAmount);
                    // 初期リザルトページデータを持ちつつ，リザルト画面へ遷移するプッシュアクションを生成
                    var pushResultPageAction = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Result, resultPageData);
                    // プッシュアクションのディスパッチ
                    UniduxService.Dispatch(pushResultPageAction);
                })
                .AddTo(this);

            _buttonReturnTitlePage
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // 前の画面(タイトル画面)に遷移するためにポップアクションの生成
                    var popTitlePageAction = PageDuck<PageName, SceneName>.ActionCreator.Pop();
                    // ポップアクションのディスパッチ
                    UniduxService.Dispatch(popTitlePageAction);
                })
                .AddTo(this);
        }

        public void DisplayGodHp(double godHp)
        {
            _textGodHp.text = $"GOD HP: {godHp}";
        }
    }
}