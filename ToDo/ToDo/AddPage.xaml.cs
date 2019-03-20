using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        private readonly MainPageViewModel vm;

        public AddPage()
        {
            InitializeComponent();
        }

        public AddPage(MainPageViewModel vm) : this()
        {
            this.vm = vm;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var toDo = new ToDoItem(ItemName.Text);
            vm.ToDoItems.Add(toDo);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}