﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PersonalApp.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(PersonalApp.Services.MockDataStore))]
namespace PersonalApp.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		bool isInitialized;
		List<Item> items;

		public async Task<bool> AddItemAsync(Item item)
		{
			await InitializeAsync();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(items);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}

		public async Task InitializeAsync()
		{
			if (isInitialized)
				return;

			items = new List<Item>();
			var _items = new List<Item>
			{
				new Item { Id = Guid.NewGuid().ToString(), ItemName = "Dull Sword", Strength ="5", Health ="0", Defense = "1", Speed = "2" },
				new Item { Id = Guid.NewGuid().ToString(), ItemName = "A Spear that you like", Strength ="7", Health ="0", Defense = "2", Speed = "0" },
				new Item { Id = Guid.NewGuid().ToString(), ItemName = "Light Ammor", Strength ="0", Health ="5", Defense = "8", Speed = "-2" },
				new Item { Id = Guid.NewGuid().ToString(), ItemName = "Too Heavy shoes", Strength ="3", Health ="7", Defense = "4", Speed = "-6" },
				new Item { Id = Guid.NewGuid().ToString(), ItemName = "Just a ring", Strength ="1", Health ="0", Defense = "2", Speed = "6" },
				new Item { Id = Guid.NewGuid().ToString(), ItemName = "Adidas pants", Strength ="0", Health ="0", Defense = "0", Speed = "0" },

			};

			foreach (Item item in _items)
			{
				items.Add(item);
			}

			isInitialized = true;
		}
	}
}
