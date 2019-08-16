﻿using System.ComponentModel;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace ArticlesAppMobile.Helpers
{
    public class Bindable : INotifyPropertyChanged, INotifyPropertyChanging
    {
        readonly ConcurrentDictionary<string, object> _properties = new ConcurrentDictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected bool CallPropertyChangeEvent { get; set; } = true;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        protected T Get<T>(T defaultValue = default(T), [CallerMemberName] string name=null)
        {
            if (string.IsNullOrEmpty(name))
                return defaultValue;
            if (_properties.TryGetValue(name, out var value))
                return (T) value;
            _properties.AddOrUpdate(name, defaultValue, (s, o) => defaultValue);
            return defaultValue;
        }

        protected bool Set(object value,[CallerMemberName] string name=null)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            var isExists = _properties.TryGetValue(name, out var getValue);
            if (isExists && Equals((value, getValue)))
                return false;

            if(CallPropertyChangeEvent)
                OnPropertyChanging(name);

            _properties.AddOrUpdate(name, value, (s, o) => value);

            if (CallPropertyChangeEvent)
                OnPropertyChanged(name);

            return true;
        }
    }
}
