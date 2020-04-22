using Dekret_CSharpLab2.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Dekret_CSharpLab2.Models
{
    
    class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;

        private string[] _chineseZodiac = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        private string[] _sunZodiac = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" };



        public Person(string name, string surname, string email, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
        }
        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
        public Person(string name, string surname, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Email
        {
            get { return _email; }
            set {
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (!regex.IsMatch(value)) throw new InvalidEmailException(value);
                _email = value;
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set {
                if (DateTime.Today < value) throw new FutureBirthDateException(value);
                else if (new DateTime(DateTime.Today.Subtract(value).Ticks).Year > 135) throw new OldBirthDateException(value);
                _birthDate = value; 
            }
        }
        public bool IsAdult
        {
            get { return new DateTime(DateTime.Today.Subtract(BirthDate).Ticks).Year > 18; }
        }
        public string SunSign
        {
            get {switch (_birthDate.Month) {
                    case 1:
                        return _birthDate.Day <= 20 ? _sunZodiac[0] : _sunZodiac[1];
                    case 2:
                        return _birthDate.Day <= 19 ? _sunZodiac[1] : _sunZodiac[2];
                    case 3:
                        return _birthDate.Day <= 20 ? _sunZodiac[2] : _sunZodiac[3];
                    case 4:
                        return _birthDate.Day <= 20 ? _sunZodiac[3] : _sunZodiac[4];
                    case 5:
                        return _birthDate.Day <= 20 ? _sunZodiac[4] : _sunZodiac[5];
                    case 6:
                        return _birthDate.Day <= 21 ? _sunZodiac[5] : _sunZodiac[6];
                    case 7:
                        return _birthDate.Day <= 22 ? _sunZodiac[6] : _sunZodiac[7];
                    case 8:
                        return _birthDate.Day <= 23 ? _sunZodiac[7] : _sunZodiac[8];
                    case 9:
                        return _birthDate.Day <= 23 ? _sunZodiac[8] : _sunZodiac[9];
                    case 10:
                        return _birthDate.Day <= 22 ? _sunZodiac[9] : _sunZodiac[10];
                    case 11:
                        return _birthDate.Day <= 22 ? _sunZodiac[10] : _sunZodiac[11];
                    case 12:
                        return _birthDate.Day <= 21 ? _sunZodiac[11] : _sunZodiac[0];
                    default:
                        return null;
                }
            }
        }
        public string ChineseSign
        {
            get
            {
                uint chzodiac = (uint)((_birthDate.Year - 4) % 12);
                return _chineseZodiac[chzodiac];
            }
        }
        public bool IsBirthday
        {
            get { return DateTime.Today == BirthDate.Date; }
        }
    }
}
