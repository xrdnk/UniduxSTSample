using System;
using Deniverse.UniduxSTSample.Domain.Unidux;
using Unidux.SceneTransition;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Deniverse.UniduxSTSample.View.Title
{
    /// <summary>
    /// タイトル画面の汎用ビュークラス
    /// </summary>
    public class TitleUIView : UIViewBase
    {
        [SerializeField] Button _buttonEnterMainPage;
        [SerializeField] Button _buttonShowLicence;

        readonly Subject<Unit> _showLicence = new();
        public IObservable<Unit> OnShowLicenceAsObservable() => _showLicence;

        protected override void Awake()
        {
            _buttonShowLicence
                .OnClickAsObservable()
                .Subscribe(_ => _showLicence.OnNext(Unit.Default))
                .AddTo(this);

            _buttonEnterMainPage
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // メインゲーム画面へ遷移するプッシュアクションを生成
                    var pushMainPageAction = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Main);
                    // プッシュアクションのディスパッチ
                    UniduxService.Dispatch(pushMainPageAction);
                })
                .AddTo(this);
        }
    }
}