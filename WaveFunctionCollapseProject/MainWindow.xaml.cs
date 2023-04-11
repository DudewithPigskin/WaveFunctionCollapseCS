using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml.Linq;
using WaveFunctionCollapse.View.Objects;
using WaveFunctionCollapse.View.UserControls;
using WaveFunctionCollapse.ModelView;
using System.Linq;

namespace WaveFunctionCollapse
{
    public partial class MainWindow : Window
    {
        WaveFieldModelView Universe = new();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Universe.LoadBasicCellOptions();
        }

        private void UseNewSettings(object sender, RoutedEventArgs e)
        {
            int x_value, y_value;

            if (IsStringValidDimension(settings_dimension.x_Value.Text, out x_value) &&
                IsStringValidDimension(settings_dimension.y_Value.Text, out y_value))
            {
                dimensionDisplay.Text = "Current Dimensions are " + x_value + " by " + y_value;
            } else {
                dimensionDisplay.Text = "Dimensions must be defined in whole numbers";
                return;
            }

            Universe.CreateUserField(UniverseGui, x_value, y_value);
        }
        private void CollapseButton(object sender, RoutedEventArgs e)
        {
            Universe.CollapseUserField(UniverseGui);
        }

        //--------------------------- util -----------------------------
        private static bool IsStringValidDimension(string? Text, out int Value)
        {
           if (!int.TryParse(Text, out Value)) {
               return false;
           }

           if (Value <= 0) {
                return false; 
           }
            return true;
        }
    }
}
