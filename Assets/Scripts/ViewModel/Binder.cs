using System;
using System.ComponentModel;
using System.Reflection;

namespace ViewModel
{
    public class Binder : IDisposable
    {
        private object _source;
        private object _reciver;
        private PropertyInfo _sourceProp;
        private PropertyInfo _reciverProp;
        private PropertyChangedEventHandler _propertyChangedEventHandler;

        public Binder(object source, string sourcePropName, object reciver, string reciverPropName)
        {
            _source = source;
            _sourceProp = _source.GetType().GetProperty(sourcePropName);
            _reciver = reciver;
            _reciverProp = _reciver.GetType().GetProperty(reciverPropName);

            var eventHandler = _source.GetType().GetEvent("PropertyChanged");
            _propertyChangedEventHandler = UpdateProperty;
            eventHandler.AddEventHandler(_source, _propertyChangedEventHandler);
            UpdateProperty(_source, new PropertyChangedEventArgs(sourcePropName));
        }

        private void UpdateProperty(object obj, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == _sourceProp.Name)
                _reciverProp.SetValue(_reciver, _sourceProp.GetValue(_source).ToString());
        }

        public void Dispose()
        {
            _propertyChangedEventHandler = null;
        }
    }
}