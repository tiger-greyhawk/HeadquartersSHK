using System;
using System.ComponentModel;

namespace Headquarters
{
    [Magic]
    public abstract class BaseMagic : INotifyPropertyChanged
    {
        protected virtual void RaisePropertyChanged(string propName)
        {
            var e = PropertyChanged;
            if (e != null)
                e(this, new PropertyChangedEventArgs(propName)); // некоторые из нас здесь используют Dispatcher, для безопасного взаимодействия с UI thread
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    class MagicAttribute : Attribute { }
}