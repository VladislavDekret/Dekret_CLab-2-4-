﻿using Dekret_CSharpLab2.Exceptions;
using Dekret_CSharpLab2.Models;
using Dekret_CSharpLab2.Tools.Managers;
using Dekret_CSharpLab2.Tools.MVVM;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Dekret_CSharpLab2.ViewModel
{
    internal class UserFormViewModel : BaseViewModel
    {
        private Person _person;

        private string _nameField;   
        private string _surnameField;
        private string _emailField;
        private DateTime _birthDateField = System.DateTime.UtcNow;

        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _closeCommand;

        #region Properties

        #region FieldsDataFromView
        public string NameField
        {
            set { _nameField = value; }
            get { return _nameField; }
        }
        public string SurnameField
        {
            set { _surnameField = value; }
            get { return _surnameField; }
        }
        public string EmailField
        {
            set { _emailField = value; }
            get { return _emailField; }
        }
        public DateTime BirthDateField
        {
            set { _birthDateField = value; }
            get { return _birthDateField; }
        }
        #endregion

        #region ModelDataGetters
        //all data converts to string
        public string Name
        {
            get { return _person?.Name; }
        }
        public string Surname
        {
            get { return _person?.Surname; }
        }
        public string Email
        {
            get { return _person?.Email; }
        }
        public string BirthDate
        {
            get { return _person?.BirthDate.ToString(); }
        }
        public string IsAdult
        {
            get { if (_person == null) { return ""; } return _person.IsAdult ? "adult" : "child"; }
        }
        public string SunSign
        {
            get { return _person?.SunSign; }
        }
        public string ChineseSign
        {
            get { return _person?.ChineseSign; }
        }
        public string IsBirthday
        {
            get { if (_person == null) { return ""; } return _person.IsBirthday?"Today is your birtday!!!":""; }
        }
        #endregion

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(ProceedInplementation,
                    o => CanExecuteCommand()));
            }
        }

        public RelayCommand<Object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }

        async private void ProceedInplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => ProceedData());
            LoaderManager.Instance.HideLoader();
        }

        private void ProceedData()
        {
            try
            {
                _person = new Person(NameField, SurnameField, EmailField, BirthDateField);

                if (_person.IsBirthday) { MessageBox.Show($"Happy birthday, {Name} !"); }
                #region Change Properties
                OnPropertyChanged("Name");
                OnPropertyChanged("Surname");
                OnPropertyChanged("Email");
                OnPropertyChanged("BirthDate");
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("SunSign");
                OnPropertyChanged("ChineseSign");
                OnPropertyChanged("IsBirthday");
                #endregion
            }
            catch (FutureBirthDateException exp)
            {
                MessageBox.Show($"Error: {exp.Message} !\n Your input: {exp.Value}");
            }
            catch (OldBirthDateException exp)
            {
                MessageBox.Show($"Error: {exp.Message} !\n Your input: {exp.Value}");
            }
            catch (InvalidEmailException exp)
            {
                MessageBox.Show($"Error: {exp.Message} !\n Your input: {exp.Value}");
            }
        }
        #endregion

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(NameField)&& !string.IsNullOrWhiteSpace(SurnameField)&& !string.IsNullOrWhiteSpace(EmailField);
        }
    }
}
