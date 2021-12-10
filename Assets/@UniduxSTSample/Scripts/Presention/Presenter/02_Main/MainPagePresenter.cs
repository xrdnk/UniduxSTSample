using System;
using Deniverse.UniduxSTSample.Application.Main;
using Deniverse.UniduxSTSample.View.Main;
using UniDi;
using UniRx;

namespace Deniverse.UniduxSTSample.Presenter.Main
{
    /// <summary>
    /// ゲーム画面のプレゼンタークラス
    /// </summary>
    public sealed class MainPagePresenter : IInitializable, IDisposable
    {
        readonly MainPageService _service;
        readonly MainPageUIView _view;
        readonly CompositeDisposable _disposable;

        public MainPagePresenter(MainPageService service, MainPageUIView view)
        {
            _service = service;
            _view = view;
            _disposable = new CompositeDisposable();
        }

        void IInitializable.Initialize()
        {
            _view.OnAttackedAsObservable()
                .Subscribe(_ => _service.AttackGod())
                .AddTo(_disposable);

            _service.GodHpRp
                .Subscribe(_view.DisplayGodHp)
                .AddTo(_disposable);
        }

        void IDisposable.Dispose() => _disposable?.Dispose();
    }
}