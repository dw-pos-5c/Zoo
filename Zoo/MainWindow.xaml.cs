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

        private void btnClick_Buy(object sender, RoutedEventArgs e)
        {
            var cbItem = cbAnimals.SelectedItem as ComboBoxItem;
            var name = cbItem.Content as string;
            var isParsed = int.TryParse(tbNumber.Text, out int count);
            if (name == null || !isParsed) return;
            var animal = factory.Create(name, count);

            lbStock.Items.Add(animal);
        }

        private void CbAnimals_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateInfo();
        private void TbNumber_OnKeyUp(object sender, KeyEventArgs e) => UpdateInfo();

        private void UpdateInfo()
        {
            var cbItem = cbAnimals.SelectedItem as ComboBoxItem;
            var name = cbItem.Content as string;
            var isParsed = int.TryParse(tbNumber.Text, out int count);
            if (name == null || !isParsed) return;
            var animal = factory.GetInfo(name);
            if (animal.CarnivorialFood > 0)
            {
                lblFood.Content = $"Needs {animal.CarnivorialFood}kgs CarnivorialFood/day";
            }
            else if (animal.HerbivorialFood > 0)
            {
                lblFood.Content = $"Needs {animal.HerbivorialFood}kgs HerbivorialFood/day";
            }
            else
            {
                lblFood.Content = $"Needs {animal.CarnivorialFood}kgs CarnivorialFood/day\nand {animal.HerbivorialFood}kgs HerbivorialFood/day";
            }
            
            lblPrice.Content = $"Price: { Math.Round(animal.Price * count, 2) }€";
        }
    }
}
