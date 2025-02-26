using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace pr3_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateWeight(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(HeightInput.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double height) || height < 130 || height > 220)
            {
                MessageBox.Show("Введите корректный рост (130-220 см).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(WeightInput.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double weight) || weight < 40 || weight > 170)
            {
                MessageBox.Show("Введите корректный вес (40-170 кг).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!(MaleRadio.IsChecked == true || FemaleRadio.IsChecked == true))
            {
                MessageBox.Show("Выберите пол.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double normalWeight = MaleRadio.IsChecked == true ? (height - 100) * 1.13 : (height - 100) * 0.9;
            double lowerBound = normalWeight - 3;
            double upperBound = normalWeight + 3;

            string result;
            if (weight < lowerBound)
                result = "Вес ниже нормы";
            else if (weight > upperBound)
                result = "Вес выше нормы";
            else
                result = "Вес в норме";

            ResultLabel.Content = $"Оптимальный вес: {normalWeight:F1} кг\n{result}";
        }
    }
}