using Cysharp.Threading.Tasks;

namespace com.ktgame.manager.ui
{
	public abstract class ModalPresenter<TModalView> : WindowPresenter<TModalView>, IModalPresenter where TModalView : ModalView
	{
		protected ModalPresenter(IUIManager uiManager, IViewContainer viewContainer, IViewConfig viewConfig) : base(uiManager, viewContainer,
			viewConfig) { }

		public void Show(float? backdropAlpha = null, bool? playShowAnimation = null, bool? closeWhenClickOnBackdrop = null, string backdropAssetPath = "")
		{
			var config = new ModalViewConfig((ViewConfig)ViewConfig, backdropAlpha: backdropAlpha, closeWhenClickOnBackdrop: closeWhenClickOnBackdrop,
				modalBackdropAssetPath: backdropAssetPath);
			ViewContainer.As<ModalContainer>().Show<TModalView>(config, playShowAnimation ?? ViewConfig.PlayAnimation);
		}

		public UniTask ShowAsync(float? backdropAlpha = null, bool? playShowAnimation = null, bool? closeWhenClickOnBackdrop = null, string backdropAssetPath = "")
		{
			var config = new ModalViewConfig((ViewConfig)ViewConfig, backdropAlpha: backdropAlpha, closeWhenClickOnBackdrop: closeWhenClickOnBackdrop,
				modalBackdropAssetPath: backdropAssetPath);
			return ViewContainer.As<ModalContainer>().ShowAsync<TModalView>(config, playShowAnimation ?? ViewConfig.PlayAnimation);
		}

		public void Hide(bool? playAnimation = null)
		{
			ViewContainer.As<ModalContainer>().Hide(View, playAnimation ?? ViewConfig.PlayAnimation);
		}

		public void HideLastModal(bool? playAnimation = null)
		{
			ViewContainer.As<ModalContainer>().Hide(playAnimation ?? ViewConfig.PlayAnimation);
		}

		public UniTask HideAsync(bool? playAnimation = null)
		{
			return ViewContainer.As<ModalContainer>().HideAsync(View, playAnimation ?? ViewConfig.PlayAnimation);
		}

		public UniTask HideLastModalAsync(bool? playAnimation = null)
		{
			return ViewContainer.As<ModalContainer>().HideAsync(playAnimation ?? ViewConfig.PlayAnimation);
		}

		protected override void Initialize(TModalView view)
		{
			view.AddLifecycleEvent(this, 1);
		}

		protected override void Dispose(TModalView view)
		{
			view.RemoveLifecycleEvent(this);
		}
	}

	public abstract class ModalPresenter<TModalView, TDataSource> : WindowPresenter<TModalView, TDataSource>, IModalPresenter<TDataSource>
		where TModalView : ModalView where TDataSource : IViewDataSource
	{
		protected ModalPresenter(IUIManager uiManager, IViewContainer viewContainer, IViewConfig viewConfig) : base(uiManager, viewContainer,
			viewConfig) { }

		public void Show(TDataSource dataSource, float? backdropAlpha = null, bool? playShowAnimation = null, bool? closeWhenClickOnBackdrop = null, string backdropAssetPath = "")
		{
			DataSource = dataSource;
			var config = new ModalViewConfig((ViewConfig)ViewConfig, backdropAlpha: backdropAlpha, closeWhenClickOnBackdrop: closeWhenClickOnBackdrop,
				modalBackdropAssetPath: backdropAssetPath);
			ViewContainer.As<ModalContainer>().Show<TModalView>(config, playShowAnimation ?? ViewConfig.PlayAnimation);
		}

		public UniTask ShowAsync(TDataSource dataSource, float? backdropAlpha = null, bool? playShowAnimation = null, bool? closeWhenClickOnBackdrop = null,
			string backdropAssetPath = "")
		{
			DataSource = dataSource;
			var config = new ModalViewConfig((ViewConfig)ViewConfig, backdropAlpha: backdropAlpha, closeWhenClickOnBackdrop: closeWhenClickOnBackdrop,
				modalBackdropAssetPath: backdropAssetPath);
			return ViewContainer.As<ModalContainer>().ShowAsync<TModalView>(config, playShowAnimation ?? ViewConfig.PlayAnimation);
		}

		public void Hide(bool? playAnimation = null)
		{
			ViewContainer.As<ModalContainer>().Hide(View, playAnimation ?? ViewConfig.PlayAnimation);
		}

		public void HideLastModal(bool? playAnimation = null)
		{
			ViewContainer.As<ModalContainer>().Hide(playAnimation ?? ViewConfig.PlayAnimation);
		}

		public UniTask HideAsync(bool? playAnimation = null)
		{
			return ViewContainer.As<ModalContainer>().HideAsync(View, playAnimation ?? ViewConfig.PlayAnimation);
		}

		public UniTask HideLastModalAsync(bool? playAnimation = null)
		{
			return ViewContainer.As<ModalContainer>().HideAsync(playAnimation ?? ViewConfig.PlayAnimation);
		}

		protected override void Initialize(TModalView view)
		{
			view.AddLifecycleEvent(this, 1);
		}

		protected override void Dispose(TModalView view)
		{
			view.RemoveLifecycleEvent(this);
		}
	}
}
