﻿using System;
using Prism.Commands;
using Prism.Mvvm;

namespace UsingDelegateCommands.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private bool _isEnabled;
        public bool IsEnabled
        {
            get {
                //Console.WriteLine("JJH: MainWindowViewModel IsEnabled get");
                return _isEnabled; }
            set
            {
                //Console.WriteLine("JJH: MainWindowViewModel IsEnabled set");
                SetProperty(ref _isEnabled, value);
                ExecuteDelegateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _updateText;
        public string UpdateText
        {
            get {
                //Console.WriteLine("JJH: MainWindowViewModel UpdateText get");
                return _updateText; }
            set {
                //Console.WriteLine("JJH: MainWindowViewModel UpdateText set");
                SetProperty(ref _updateText, value); }
        }


        public DelegateCommand ExecuteDelegateCommand { get; private set; }

        public DelegateCommand<string> ExecuteGenericDelegateCommand { get; private set; }        

        public DelegateCommand DelegateCommandObservesProperty { get; private set; }

        public DelegateCommand DelegateCommandObservesCanExecute { get; private set; }


        public MainWindowViewModel()
        {
            Console.WriteLine("JJH: MainWindowViewModel MainWindowViewModel");
            ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);

            DelegateCommandObservesProperty = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => IsEnabled);

            DelegateCommandObservesCanExecute = new DelegateCommand(Execute).ObservesCanExecute(() => IsEnabled);

            ExecuteGenericDelegateCommand = new DelegateCommand<string>(ExecuteGeneric).ObservesCanExecute(() => IsEnabled);
            Console.WriteLine("JJH: MainWindowViewModel MainWindowViewModel end");
        }

        private void Execute()
        {
            Console.WriteLine("JJH: MainWindowViewModel Execute");
            UpdateText = $"Updated: {DateTime.Now}";
        }

        private void ExecuteGeneric(string parameter)
        {
            parameter = "what?";
            Console.WriteLine("JJH: MainWindowViewModel ExecuteGeneric");
            UpdateText = parameter;
        }

        private bool CanExecute()
        {
            Console.WriteLine("JJH: MainWindowViewModel CanExecute");
            Console.WriteLine("JJH: MainWindowViewModel CanExecute isEnabled ="+IsEnabled);
           
            return IsEnabled;
        }
    }
}
