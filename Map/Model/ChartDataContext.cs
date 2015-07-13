using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    class ChartDataContext : INotifyPropertyChanged
    {
        Double _yValue;
        String _label;
        public ChartDataContext(string label, double value)
        {
            YValue = value;
            Label = label;
        }

        public ChartDataContext()
        {
        }

        public String Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Label"));
            }
        }

        public Double YValue
        {
            get
            {
                return _yValue;
            }
            set
            {
                _yValue = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("YValue"));
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


    }
}
