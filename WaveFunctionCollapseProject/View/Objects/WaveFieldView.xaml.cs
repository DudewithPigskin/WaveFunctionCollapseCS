using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using WaveFunctionCollapse.View.Objects;

namespace WaveFunctionCollapse.View
{
    /// <summary>
    /// Interaction logic for WaveFieldView.xaml
    /// </summary>
    public partial class WaveFieldView : UserControl
    {
        private int _width;
        private int _heigth;
        private Brush[]? _colourArray;
        private int _numberOfColours;

        public WaveFieldView()
        {
            InitializeComponent();
            _width = 0;
            _heigth = 0;
            _numberOfColours = 0;
        }

        public void LoadSettings(int width, int height, Brush[] colourArray)
        {
            _width = width;
            _heigth = height;
            _colourArray = colourArray;
            _numberOfColours = _colourArray.Length;
        }

        public void GenerateFieldGUI()
        {
            UniverseGuiGrid.Children.Clear();

            for (int row = 0; row < _heigth; row++)
            {
                WaveFieldRowView tempWaveFieldRow = new();
                for (int column = 0; column < _width; column++)
                {
                    tempWaveFieldRow.UniverseGuiRow.Children.Add(new WaveFieldCellView(_colourArray));
                }
                UniverseGuiGrid.Children.Add(tempWaveFieldRow);
            }
        }

        public void GenerateFieldGUI(int[,] WaveField)
        {
            UniverseGuiGrid.Children.Clear();

            for (int row = 0; row < _heigth; row++)
            {
                WaveFieldRowView tempWaveFieldRow = new();
                for (int column = 0; column < _width; column++)
                {
                    WaveFieldCellView tempCell = new WaveFieldCellView(_colourArray);
                    tempCell.SetCurrentState(WaveField[row, column]);
                    tempWaveFieldRow.UniverseGuiRow.Children.Add(tempCell);
                }
                UniverseGuiGrid.Children.Add(tempWaveFieldRow);
            }
        }

        public int[,] GetWaveField()
        {
            int[,] WaveField = new int[_heigth ,_width];

            for (int row = 0; row < _heigth; row++)
            {
                WaveFieldRowView tempRow = (WaveFieldRowView)UniverseGuiGrid.Children[row];
                for (int collumn = 0; collumn < _width; collumn++)
                {
                    WaveFieldCellView tempCell = (WaveFieldCellView)tempRow.UniverseGuiRow.Children[collumn];
                    WaveField[row, collumn] = tempCell.GetCurrentState();
                }
            }

            return WaveField;
        }

    }
}
