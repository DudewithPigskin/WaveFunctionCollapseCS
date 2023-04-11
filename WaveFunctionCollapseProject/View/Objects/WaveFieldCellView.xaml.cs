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
using WaveFunctionCollapse;

namespace WaveFunctionCollapse.View.Objects
{
    /// <summary>
    /// Interaction logic for WaveFieldCellView.xaml
    /// </summary>
    public partial class WaveFieldCellView : UserControl
    {
        private Brush[] _colourArray;
        private int _currentColourIndex;
        private int _numberOfColours;

        //public WaveFieldCellView()
        //{
        //    InitializeComponent();
        //}

        public WaveFieldCellView(Brush[] colourArray)
        {
            InitializeComponent();
            _colourArray = colourArray;
            _currentColourIndex = 0;
            _numberOfColours = _colourArray.Length;
            WaveFieldCellButton.Background = _colourArray[_currentColourIndex];
        }

        private void WaveFieldCell_Click(object sender, RoutedEventArgs e)
        {
            _currentColourIndex++;
            UpdateCellColour();
        }  

        private void UpdateCellColour()
        {
            if (_currentColourIndex >= _numberOfColours)
            {
                _currentColourIndex = 0;
            }
            WaveFieldCellButton.Background = _colourArray[_currentColourIndex];
        }

        public int GetCurrentState()
        {
            return _currentColourIndex;
        }

        public void SetCurrentState(int state)
        {
            if (state >= _numberOfColours)
            {
                state = _numberOfColours - 1;
            } 
            _currentColourIndex = state;
            UpdateCellColour();
            }
    }
}
