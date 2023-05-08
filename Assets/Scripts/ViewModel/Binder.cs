using System.ComponentModel;
using System.Reflection;

namespace ViewModel
{
    public class Binder
    {
        private object _source;
        private object _reciver;
        private PropertyInfo _sourceProp;
        private PropertyInfo _reciverProp;

        public Binder(object source, string sourcePropName, object reciver, string reciverPropName)
        {
            _source = source;
            _sourceProp = _source.GetType().GetProperty(sourcePropName);
            _reciver = reciver;
            _reciverProp = _reciver.GetType().GetProperty(reciverPropName);

            var eventHandler = _source.GetType().GetEvent("PropertyChanged");
            eventHandler.AddEventHandler(_source, new PropertyChangedEventHandler(UpdateProperty));
            UpdateProperty(_source, new PropertyChangedEventArgs(sourcePropName));
        }

        private void UpdateProperty(object obj, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == _sourceProp.Name)
                _reciverProp.SetValue(_reciver, _sourceProp.GetValue(_source).ToString());
        }
    }
}