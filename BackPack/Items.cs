using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace BackPack
{
    internal class Items
    {
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public double Volume { get; private set; }
        public Image Image { get; private set; }

        private Bag ownerBag;

        public event EventHandler<EventArgs> ItemClicked;

        public Items(string name, double weight, double volume, Image image, Bag bag)
        {
            Name = name;
            Weight = weight;
            Volume = volume;
            Image = image;
            Image.MouseLeftButtonDown += Image_Click;
            ownerBag = bag;
        }

        private void Image_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Image clickedImage = (Image)sender;

            if (clickedImage.Opacity == 0.5)
            {
                ownerBag.RemoveItem(this);
                ownerBag.DecreaseBagSize();
            }

            else if(ownerBag.Volume - Volume < 0)
            {
                clickedImage.Opacity = 1;
                MessageBox.Show($"{Name} не удается поместить в рюкзаке!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else
            {
                clickedImage.Opacity = 0.5;
                ownerBag.IncreaseBagSize();
                Initialize();
                OnItemClicked();
            }
        }


        private void Initialize()
        {
            ownerBag.AddItem(this);
        }

        protected virtual void OnItemClicked()
        {
            ItemClicked?.Invoke(this, EventArgs.Empty);
        }

    }
}
