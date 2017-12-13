using ICT13580098A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580098A2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductMainPage : ContentPage
    {
        Product product;
        public ProductMainPage(Product product=null)
        {
            InitializeComponent();

            this.product = product;
            titleLabel.Text = product == null ? "เพิ่มสินค้าใหม่" : "แก้ไขข้อมูลสินค้า";

            categoryPicker.Items.Add("เสื้อผ้า");
            categoryPicker.Items.Add("รองเท้า");
            categoryPicker.Items.Add("กางเกง");

            if(product != null){
                productNameEntry.Text = product.Name;
                productDetailEditor.Text = product.Description;
                categoryPicker.SelectedItem = product.Category;
                priceEntry.Text = product.salePrice.ToString();
            }

            okButton.Clicked += OkButton_Clicked;
            cancleButton.Clicked += CancleButton_Clicked;
        }

        private void CancleButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        async void OkButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                if (product == null)
                { 
                    product = new Product();        
                    product.Name = productNameEntry.Text;
                    product.Description = productDetailEditor.Text;
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.Sellprice = priceEntry.Text;
                    var id = App.DbHelper.AddProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
                    
                }else{
                  
                    product.Name = productNameEntry.Text;
                    product.Description = productDetailEditor.Text;
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.Sellprice = priceEntry.Text;
                    var id = App.DbHelper.UpdateProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้าเรียบร้อย #" + id, "ตกลง");             
                }
                await Navigation.PopModalAsync();
            }
        }
    }
}