using Cysharp.Threading.Tasks;

namespace com.ktgame.manager.ui
{
	public interface IPanelPresenter : IViewPresenter, IPanelLifecycleEvent
	{
		void Show(SortingLayerId? sortingLayer, int? orderInLayer, bool? playHideAnimation = null);

		UniTask ShowAsync(SortingLayerId? sortingLayer, int? orderInLayer, bool? playHideAnimation = null);

		void Hide(bool? playHideAnimation = null);

		UniTask HideAsync(bool? playHideAnimation = null);
	}

	public interface IPanelPresenter<in TDataSource> : IViewPresenter, IPanelLifecycleEvent where TDataSource : IViewDataSource
	{
		void Show(TDataSource dataSourcex, SortingLayerId? sortingLayer, int? orderInLayer, bool? playHideAnimation = null);

		UniTask ShowAsync(TDataSource dataSource, SortingLayerId? sortingLayer, int? orderInLayer, bool? playHideAnimation = null);

		void Hide(bool? playHideAnimation = null);

		UniTask HideAsync(bool? playHideAnimation = null);
	}
}
