using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ToDo
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            ToDoItems = new ObservableCollection<ToDoItem>();

            var t = new Task(async () =>
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var httpClient = new HttpClient();
                    var result = await httpClient.GetStringAsync("https://todofunctions20190318024111.azurewebsites.net/api/ToDo");

                    var items = JsonConvert.DeserializeObject<List<ToDoItem>>(result);

                    foreach (var item in items)
                        ToDoItems.Add(item);
                }
            });
            t.Start();
            
            AddItemCommand = new Command(async () => await ShowAdd());
        }

        async Task ShowAdd()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddPage(this));
        }

        public ObservableCollection<ToDoItem> ToDoItems { get; }

        public ICommand AddItemCommand { get; }
    }
}
