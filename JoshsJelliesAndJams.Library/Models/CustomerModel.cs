﻿using System;
using JoshsJelliesAndJams.Library.Validator;

namespace JoshsJelliesAndJams.Library
{
    public class CustomerModel
    {
        private string _firstName;
        private string _lastName;
        private string _address1;
        private string _address2;
        private string _city;
        private string _state;
        private int _zipcode;
        private string _defaultStore; 
        public int CustomerID { get; set; }
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value.StringValidator(); 
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value.StringValidator();
        }

        public string StreetAddress1
        {
            get => _address1;
            set => _address1 = value.StringValidator();
        }

        public string StreetAddress2
        {
            get => _address2;
            set => _address2 = value.ToUpper(); 
        }

        public string City
        {
            get => _city;
            set => _city = value.StringValidator();
        }

        public string State
        {
            get => _state;
            set => _state = value.StateValidator();
        }

        public int Zipcode 
        { 
            get => _zipcode; 
            set => _zipcode = value.ZipcodeValidator(); 
        }

        public string DefaultStore
        {
            get => _defaultStore;
            set => _defaultStore = value.StringValidator();
        }
    }
}