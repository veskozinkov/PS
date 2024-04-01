using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MinimalMVVM.Model;

namespace MinimalMVVM.ViewModel
{
    public class Presenter : ObservableObject
    {
        private readonly TextConverter _textConverterToUppercase = new TextConverter(s => s.ToUpper());
        private readonly TextConverter _textConverterToLowercase = new TextConverter(s => s.ToLower());
        private string _someText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        public ICommand ConvertTextToUppercaseCommand
        {
            get { return new DelegateCommand(ConvertTextToUppercase); }
        }

        public ICommand ConvertTextToLowercaseCommand
        {
            get { return new DelegateCommand(ConvertTextToLowercase); }
        }

        private void ConvertTextToUppercase()
        {
            AddToHistory(_textConverterToUppercase.ConvertText(SomeText));
            SomeText = String.Empty;
        }

        private void ConvertTextToLowercase()
        {
            AddToHistory(_textConverterToLowercase.ConvertText(SomeText));
            SomeText = String.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}
