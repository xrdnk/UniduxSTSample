using System;
using Deniverse.UniduxSTSample.Application.Result;
using Deniverse.UniduxSTSample.View.Result;
using UniDi;
using UniRx;

namespace Deniverse.UniduxSTSample.Presenter.Result
{
    /// <summary>
    /// リザルト画面のプレゼンタークラス
    /// </summary>
    public sealed class ResultPagePresenter : IInitializable, IDisposable
    {
        readonly ResultPageService _service;
        readonly ResultPageUIView _view;
        readonly CompositeDisposable _disposable;

        public ResultPagePresenter(ResultPageService service, ResultPageUIView view)
        {
            _service = service;
            _view = view;
            _disposable = new CompositeDisposable();
        }

        void IInitializable.Initialize()
        {
            _service.DamageDoneRp
                .Subscribe(_view.DisplayResult)
                .AddTo(_disposable);
        }

        void IDisposable.Dispose()
        {
            _disposable?.Dispose();
        }
    }
}