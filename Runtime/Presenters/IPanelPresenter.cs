using Cysharp.Threading.Tasks;

namespace com.ktgame.manager.ui
{
	public interface IPanelPresenter : IViewPresenter, IPanelLifecycleEvent
	{
		void Show(SortingLayerId? sortingLayer, int? orderInLayer, bool playHideAnimation = true);

		UniTask ShowAsync(SortingLayerId? sortingLayer, int? orderInLayer, bool playHideAnimation = true);

		void Hide(bool playHideAnimation = true);

		UniTask HideAsync(bool playHideAnimation = true);
	}

	public interface IPanelPresenter<in TDataSource> : IViewPresenter, IPanelLifecycleEvent where TDataSource : IViewDataSource
	{
		void Show(TDataSource dataSourcex, SortingLayerId? sortingLayer, int? orderInLayer, bool playHideAnimation = true);

		UniTask ShowAsync(TDataSource dataSource, SortingLayerId? sortingLayer, int? orderInLayer, bool playHideAnimation = true);

		void Hide(bool playHideAnimation = true);

		UniTask HideAsync(bool playHideAnimation = true);
	}
}
