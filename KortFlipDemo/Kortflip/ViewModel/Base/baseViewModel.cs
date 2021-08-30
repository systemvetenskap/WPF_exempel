using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kortflip.ViewModel.Base
{
    public class baseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

         protected void OnPropertyChanged(string imgSource)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(imgSource));
        }
    }
}
