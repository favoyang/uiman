using System;

namespace UnuGames.MVVM
{
    public interface IObservable
    {
        void OnPropertyChanged();

        void OnPropertyChanged(string propertyName, object value);

        void NotifyPropertyChanged(string propertyName, object value);

        void SubscribeAction(string propertyName, Action<object> updateAction);

        void UnsubscribeAction(string propertyName, Action<object> updateAction);

        void SetValue(string propertyName, object value);
    }
}