﻿using System;

using MultipleScreens.Models;
using MultipleScreens.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultipleScreens.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InventoryPage : ContentPage
	{
		ListViewModel viewModel;

		public InventoryPage ()
		{
			InitializeComponent ();
		}

		public InventoryPage(ListViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
