using System.Windows.Media;

namespace TestForAtomicus.Model
{
    public class Colors : BindableBase
    {
        private Color _colorName;

        public Color ColorName
        {
            get => _colorName;
            set
            {
                if (value == _colorName) return;
                _colorName = value;
                NotifyPropertyChanged();
            }
        }
    }
}
