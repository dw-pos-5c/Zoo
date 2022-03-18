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

using ZooLib.baseClasses;

namespace Zoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AnimalFactory factory = AnimalFactory.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            factory.animalList.ForEach(x =>
            {
                var comboboxItem = new ComboBoxItem()
                {
                    Content = x,
                };
                cbAnimals.Items.Add(comboboxItem);
            });
        }

        private Dictionary<string, int> animalDic = new Dictionary<string, int>();

        private void btnClick_Buy(object sender, RoutedEventArgs e)
        {
            var cbItem = cbAnimals.SelectedItem as ComboBoxItem;
            var name = cbItem.Content as string;
            var isParsed = int.TryParse(tbNumber.Text, out int count);
            if (name == null || !isParsed) return;
            var animals = factory.Create(name, count);

            var exists = animalDic.ContainsKey(name);
            if (exists) animalDic[name] += animals.Count;
            else animalDic[name] = animals.Count;

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            lbStock.Items.Clear();

            double carnivorialFood = 0;
            double herbivorialFood = 0;
            double totalPrice = 0;

            foreach (var key in animalDic.Keys)
            {
                var animal = factory.GetInfo(key);
                var count = animalDic[key];
                carnivorialFood += animal.CarnivorialFood * count;
                herbivorialFood += animal.HerbivorialFood * count;
                totalPrice += animal.Price * count;

                lbStock.Items.Add(new ListBoxItem
                {
                    Content = $"{count} x {key}",
                });
            }

            if (carnivorialFood > 0)
            {
                lblFoodCarn.Content = $"Needs { Math.Round(carnivorialFood, 2) }kgs CarnivorialFood/day";
            }
            if (herbivorialFood > 0)
            {
                lblFoodHerb.Content = $"Needs { Math.Round(herbivorialFood, 2) }kgs HerbivorialFood/day";
            }
            
            lblPrice.Content = $"Price: { Math.Round(totalPrice, 2) }€";
        }
    }
}
