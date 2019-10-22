using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace Albion.Model
{
    public abstract class NotifyEntity : ReactiveObject , INotifyPropertyChanged
    {
//        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.RaisePropertyChanged(propertyName);
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}