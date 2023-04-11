using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFunctionCollapse.Model
{
    internal class WaveFieldModel: IWaveField
    {
        private int _height;
        private int _width;
        private int[,] _waveArray;
        private int[] _waveStates;

        public WaveFieldModel(int[,] WaveField, int[] WaveState) {
            if (!SetWaveArray(WaveField))
            {
                throw new ArgumentException("WaveField should have atleast a 1x1 dimension");
            }
       
            if (!SetWaveStates(WaveState))
            {
                throw new ArgumentException("WaveState should have atleast one accepted state");
            }  

            _height = WaveField.GetLength(0);
            _width = WaveField.GetLength(1);
        }

        public int[,] GetWaveArray()
        {
            return this._waveArray;
        }

        private bool SetWaveArray(int[,] WaveArray)
        {
            if(WaveArray.Length == 0) { return false; }

            this._waveArray = WaveArray;
            return true;
        }

        private bool SetWaveStates(int[] WaveStates)
        {
            if (WaveStates.Length == 0) { return false; }

            this._waveStates = WaveStates;
            return true;
        }

        public bool Collapse() 
        { 
            Random reality = new();
            int stateIndex;

            for (int row = 0 ; row < _height; row++)
            {
                for (int column = 0; column < _width; column++)
                {
                    if (_waveArray[row, column] == 0)
                    {
                        stateIndex = reality.Next(1,_waveStates.Length);
                        _waveArray[row,column] = this._waveStates[stateIndex];
                    }
                }
            }
            return true;
        }


    }
}
