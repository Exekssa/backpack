using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BackPack
{
    internal class Bag
    {
        public string Color { get; private set; }
        public string Brand { get; private set; }
        public string Fabric { get; private set; }
        public double Weight { get; private set; }
        public double Volume { get; private set; }
    

        public List<Items> Items { get; private set; }

        private TextBox MyText;

        private Image BagImage;


        public event EventHandler<EventArgs> BagClicked;

        public Bag(string color, string brand, string fabric, double weight, double volume, TextBox MyText, Image bagImage)
        {
            Color = color;
            Brand = brand;
            Fabric = fabric;
            Weight = weight;
            Volume = volume;
            Items = new List<Items>();
            this.MyText = MyText;
            BagImage = bagImage;
        }


        public void AddItem(Items item)
        {
            if (Volume - item.Volume >= 0)
            {
                Items.Add(item);
                Volume -= item.Volume;
                Weight += item.Weight;

                OnBagClicked();
                MyText.Text += $"Вы положили в рюкзак {item.Name}!\nТеперь вес рюкзака составляет {Weight} кг.\nДоступный объем: {Volume} см³";

            }
            
        }

        public void RemoveItem(Items item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                Volume += item.Volume;
                Weight -= item.Weight;
                OnBagClicked();

                MyText.Text += $"Вы убрали из рюкзака {item.Name}.\nТеперь вес рюкзака составляет {Weight} кг.\nДоступный объем: {Volume} см³";

                item.Image.Opacity = 1.0;

            }
          
        }

        protected virtual void OnBagClicked()
        {
            BagClicked?.Invoke(this, EventArgs.Empty);
        }

        public void IncreaseBagSize()
        {
            BagImage.Width += 5;
            BagImage.Height += 5;
           
        }

        public void DecreaseBagSize()
        {
            BagImage.Width -= 5;
            BagImage.Height -= 5;
          
        }
    }

 }

