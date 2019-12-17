using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TombstoneStrong.UI.WPF.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        protected virtual void SetValue<T>(ref T field, T value, [CallerMemberName]string PropertyName = null)
        {
            //if (field != value)
            if (EqualityComparer<T>.Default.Equals(field, value) == false)
            {
                field = value;
                OnPropertyChanged(PropertyName);
            }
        }
    }
}
