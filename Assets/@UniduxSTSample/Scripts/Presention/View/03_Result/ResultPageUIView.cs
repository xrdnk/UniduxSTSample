using Deniverse.UniduxSTSample.Domain.Unidux;
using TMPro;
using Unidux.SceneTransition;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Deniverse.UniduxSTSample.View.Result
{
    /// <summary>
    /// リザルト画面用の汎用ビュークラス
    /// </summary>
    public class ResultPageUIView : UIViewBase
    {
        [SerializeField] Button _buttonGoToTitle;
        [SerializeField] TMP_Text _textResult;

        protected override void Awake()
        {
            _buttonGoToTitle
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // これまでのスタック履歴をリセット（クリア）する
                    var resetAction = PageDuck<PageName, SceneName>.ActionCreator.Reset();
                    // リセットアクションのディスパッチ
                    UniduxService.Dispatch(resetAction);
                    // タイトル画面へプッシュするアクションを作る
                    var pushTitlePageAction = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Title);
                    // プッシュアクションのディスパッチ
                    UniduxService.Dispatch(pushTitlePageAction);
                })
                .AddTo(this);
        }

        public void DisplayResult(double damageDone)
        {
            _textResult.text = $"Your DamageDone is {damageDone}";
        }
    }
}