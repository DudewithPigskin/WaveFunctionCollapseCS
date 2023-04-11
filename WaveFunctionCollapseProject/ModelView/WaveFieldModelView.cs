using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Diagnostics;
using WaveFunctionCollapse.Model;
using WaveFunctionCollapse.View;
using WaveFunctionCollapse.View.Objects;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;

namespace WaveFunctionCollapse.ModelView
{
    internal class WaveFieldModelView
    {
        private LinkedList<CellStateOption> _CellStateList = new();

        CellStateOption CellStateInvalid = new("Invalid", Brushes.Black);
        CellStateOption CellStateUnchosen = new("Unchosen", Brushes.White);

        public WaveFieldModelView() {
            _CellStateList.Clear();
            _CellStateList.AddLast(CellStateUnchosen);
            _CellStateList.AddLast(CellStateInvalid);
        }

        public void LoadBasicCellOptions()
        {
            CellStateOption CellStateOcean = new("Ocean", Brushes.DarkBlue);
            CellStateOption CellStateWater = new("Water", Brushes.Blue);
            CellStateOption CellStateField = new("Field", Brushes.Green);
            CellStateOption CellStateForest = new("Forest", Brushes.DarkGreen);

            _CellStateList.Clear();
            _CellStateList.AddLast(CellStateUnchosen);
            _CellStateList.AddLast(CellStateOcean);
            _CellStateList.AddLast(CellStateWater);
            _CellStateList.AddLast(CellStateField);
            _CellStateList.AddLast(CellStateForest);
            _CellStateList.AddLast(CellStateInvalid);
        }

        public void CreateUserField( WaveFieldView UserField ,int Width, int Height)
        {
            UserField.LoadSettings(Width, Height, GetColourArray());
            UserField.GenerateFieldGUI();
        }

        private Brush[] GetColourArray()
        {
            int amountOfStates = _CellStateList.Count;
            Brush[] ColourArray = new Brush[amountOfStates];
            LinkedListNode<CellStateOption> currentState = _CellStateList.First;

            for (int i = 0; i < amountOfStates; i++)
            {
                ColourArray[i] = currentState.Value.Colour;
                currentState = currentState.Next;
            }
            return ColourArray;
        }

        public void CollapseUserField(WaveFieldView UserField)
        {
            int[,] wavefield = UserField.GetWaveField();

            PrintIntArray(wavefield);

            WaveFieldModel UniverseModel = new(wavefield, GetStateArray());
            UniverseModel.Collapse();
            wavefield = UniverseModel.GetWaveArray();
            PrintIntArray(wavefield);

            UserField.GenerateFieldGUI(wavefield);

        }


        private void PrintIntArray(int[,] ints)
        {
            for (int row = 0; row < ints.GetLength(0); row++)
            {
                for (int collumn = 0; collumn < ints.GetLength(1); collumn++)
                {
                    Trace.Write(ints[row, collumn] + " ");
                }
                Trace.Write("\n");
            }
            Trace.Write("\n");

        }


        private int[] GetStateArray()
        {
            int amountOfStates = _CellStateList.Count;
            int [] StateArray = new int[amountOfStates];

            for (int i = 0; i < amountOfStates; i++)
            {
                StateArray[i] = i;
            }
            return StateArray;
        }
    }
}
