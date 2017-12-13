using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ICT13580098A2.Models;

namespace ICT13580098A2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            newButton.Clicked += NewButton_Clicked;
        }

        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductMainPage());
        }

        protected override void OnAppearing()
        {
            LoadData();
        }
        void LoadData()
        {
            productListView.ItemsSource = App.DbHelper.GetProducts();
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new ProductMainPage(product));
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                var button = sender as MenuItem;
                var product = button.CommandParameter as Product;
                App.DbHelper.DeleteProduct(product);

                await DisplayAlert("ลบสำเร็จ", "ลบสิ้นค้าแล้ว", "ตกลง");
                LoadData();
            }
        }
    }
}
