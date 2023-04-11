using System.Windows.Media;

namespace WaveFunctionCollapse.ModelView
{
    struct CellStateOption
    {
        public string State;
        public Brush Colour;

        public CellStateOption(string State, Brush Colour)
        {
            this.State = State; 
            this.Colour = Colour; 
        }
    }
}
