using System;
using Deniverse.UniduxSTSample.View.Title;
using UniDi;
using UniRx;

namespace Deniverse.UniduxSTSample.Navigator.Title
{
    /// <summary>
    /// タイトル画面のナビゲータークラス
    /// </summary>
    public sealed class TitlePageViewNavigator : IInitializable, IDisposable
    {
        readonly TitleUIView _titleUIView;
        readonly LicenceView _licenceView;
        readonly CompositeDisposable _disposable;

        public TitlePageViewNavigator(TitleUIView titleUIView, LicenceView licenceView)
        {
            _titleUIView = titleUIView;
            _licenceView = licenceView;
            _disposable = new CompositeDisposable();
        }

        void IInitializable.Initialize()
        {
            _licenceView.Hide();

            _titleUIView.OnShowLicenceAsObservable()
                .Subscribe(_ => _licenceView.Show())
                .AddTo(_disposable);

            _licenceView.OnHideLicenceAsObservable()
                .Subscribe(_ => _licenceView.Hide())
                .AddTo(_disposable);
        }

        void IDisposable.Dispose() => _disposable?.Dispose();
    }
}