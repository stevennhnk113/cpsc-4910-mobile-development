﻿namespace MultipleScreens.Models
{
    public class Item : BaseDataObject
	{
		string text = string.Empty;
		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		public string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}
	}
}
