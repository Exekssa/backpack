using BackPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackPack
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
 

            Bag myBag = new Bag("розовый", "Puma", "эко-материал", 1.25, 4000, MyText, BagImage);

            myBag.BagClicked += HandleBagClicked;

            Items shoe = new Items("Ботинок", 0.9, 3750, Shoe, myBag);
            Items camera = new Items("Canon G-0259", 0.5, 2000, Camera, myBag);
            Items catFood = new Items("Корм для Маркса", 2, 3000, Food, myBag);
            Items tomatoes = new Items("Помидоры", 0.4, 400, Tomatoes, myBag);
            Items cactus = new Items("Кактус", 0.8, 1570, Cactus, myBag);
            Items MarksTheCat = new Items("Настоящего кота Маркса", 6, 6000, Marks, myBag);

            //Чтобы вытащить предмет из рюкзака, нужно кликнуть по его прозрачному изображению на полке
            MyText.Text = "Соберите ваш рюкзак в путешествие!\nКликайте по предметам, выбирайте, что хотите взять с собой!";
        }

        private void HandleBagClicked(object sender, EventArgs e)
        {
            MyText.Text = string.Empty;
        }

        private void MyText_TextChanged(object sender, TextChangedEventArgs e) { }

    }
}
