using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Albion.Model
{
    public abstract class NotifyEntity : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}