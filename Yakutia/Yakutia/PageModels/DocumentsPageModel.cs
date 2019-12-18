using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FreshMvvm;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Yakutia.Models;

namespace Yakutia.PageModels
{
	public class DocumentsPageModel : FreshBasePageModel
	{
		private Document _selectedDocument;

		public override void Init(object initData)
		{
			base.Init(initData);

			//CheckPermissionStorage();

			if (initData is IEnumerable<Document> docs)
			{
				Documents = new ObservableCollection<Document>(docs);
			}

			CrossDownloadManager.Current.CollectionChanged += (sender, e) =>
				System.Diagnostics.Debug.WriteLine(
					"[DownloadManager] " + e.Action +
					" -> New items: " + (e.NewItems?.Count ?? 0) +
					" at " + e.NewStartingIndex +
					" || Old items: " + (e.OldItems?.Count ?? 0) +
					" at " + e.OldStartingIndex
				);
		}

		private async void CheckPermissionStorage()
		{
			await CheckPermission(Permission.Storage, "Для скачивания документов необходимо разрешение на использование хранилища.");
		}

		private async Task<bool> CheckPermission(Permission permission, string message)
		{
			var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
			if (status != PermissionStatus.Granted)
			{
				bool wasModalShowed = false;
				if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(permission))
				{
					wasModalShowed = true;
					await Application.Current.MainPage.DisplayAlert("Внимание", message, "OK");
				}

				try
				{
					await CrossPermissions.Current.RequestPermissionsAsync(permission);
				}
				catch (TaskCanceledException e)
				{
					Console.WriteLine(e);
					if (!wasModalShowed)
					{
						await Application.Current.MainPage.DisplayAlert("Внимание", message, "OK");
					}
				}

				status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
			}

			return await Task.FromResult(status == PermissionStatus.Granted);
		}

		public bool NoHasDocuments => !(Documents?.Count > 0);

		public ObservableCollection<Document> Documents
		{
			get;
			set;
		}

		public Document SelectedDocument
		{
			get => _selectedDocument;
			set
			{
				_selectedDocument = value;
				if (value != null)
				{
					EventSelected.Execute(value);
				}
			}
		}

		public Command<Document> EventSelected =>
			new Command<Document>(obj =>
			{
				DownloadDocument(obj.FileSource);
			});


		private async void DownloadDocument(string fileUri)
		{
			if (Uri.IsWellFormedUriString(fileUri, UriKind.Absolute))
			{
				await Browser.OpenAsync(fileUri);
				return;
			}
		}
	}
}
