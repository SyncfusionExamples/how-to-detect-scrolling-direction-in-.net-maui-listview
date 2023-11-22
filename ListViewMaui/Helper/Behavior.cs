using Syncfusion.Maui.ListView;
using Syncfusion.Maui.ListView.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
	public class ListViewBehavior : Behavior<SfListView>
	{
		#region Fields
		ContactsViewModel viewModel;
		ListViewScrollView scrollview;
		double previousOffset;
		public SfListView listview { get; private set; }
		#endregion

		#region Overrides
		protected override void OnAttachedTo(SfListView bindable)
		{
			base.OnAttachedTo(bindable);
			listview = bindable as SfListView;
			viewModel = new ContactsViewModel();
			listview.BindingContext = viewModel;
			scrollview = listview.GetScrollView();
			scrollview.Scrolled += Scrollview_Scrolled;
		}

		protected override void OnDetachingFrom(SfListView bindable)
		{
			base.OnDetachingFrom(bindable);
			scrollview.Scrolled -= Scrollview_Scrolled;
			scrollview = null;
			listview = null;
			viewModel = null;
		}
		#endregion

		#region Call back

		private void Scrollview_Scrolled(object sender, ScrolledEventArgs e)
		{
			if (e.ScrollY == 0)
				return;

			if (previousOffset >= e.ScrollY)
			{
				// Up direction  
				viewModel.ScrollDirection = "Up Direction";
			}
			else
			{
				//Down direction 
				viewModel.ScrollDirection = "Down Direction";
			}

			previousOffset = e.ScrollY;
		}
		#endregion
	}
}
