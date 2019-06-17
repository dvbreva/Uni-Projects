using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdValidator
{
    class Program
    {
        private enum Sex { Male, Female };

        static void Main(string[] args)
        {
            String myEgn;

            do
            {
                Console.Out.WriteLine("Personal ID number: ");
                myEgn = Console.ReadLine();
                if (myEgn.Length != 10)
                {
                    Console.Out.WriteLine("Your number needs to be 10 symbols long.");

                }
                else
                {
                    Validator(myEgn, out String birthDate, out bool exists, out Sex sex);
                    Console.Out.Write("Personal ID number exists:" + exists + "\nTime of birth:" + birthDate + "\nSex:" + sex);
                    Console.ReadKey();
                }
            } while (myEgn.Length != 10);
        }

        static void Validator(String egn, out String birthDate, out bool exists, out Sex sex)
        {
            String year = egn.Substring(0, 2);
            int month = Int32.Parse(egn.Substring(2, 2));
            int day = Int32.Parse(egn.Substring(4, 2));

            String birthdayYear = "";
            String birthdayMonth = "";
            String birthdayDay = "";

            if (month > 20 && month < 40)
            {
                birthdayYear = "18" + year;
                birthdayMonth = (month - 20).ToString();
                birthdayDay = day.ToString();
            }
            if (month > 40)
            {
                birthdayYear = "20" + year;
                birthdayMonth = (month - 40).ToString();
                birthdayDay = day.ToString();
            }
            if (month < 20)
            {
                birthdayYear = "19" + year;
                birthdayMonth = month.ToString();
                birthdayDay = day.ToString();
            }

            switch (int.Parse(birthdayMonth))
            {
                case 1:
                    birthdayMonth = "January";
                    break;
                case 2:
                    birthdayMonth = "February";
                    break;
                case 3:
                    birthdayMonth = "March";
                    break;
                case 4:
                    birthdayMonth = "April";
                    break;
                case 5:
                    birthdayMonth = "May";
                    break;
                case 6:
                    birthdayMonth = "June";
                    break;
                case 7:
                    birthdayMonth = "July";
                    break;
                case 8:
                    birthdayMonth = "August";
                    break;
                case 9:
                    birthdayMonth = "September";
                    break;
                case 10:
                    birthdayMonth = "October";
                    break;
                case 11:
                    birthdayMonth = "November";
                    break;
                case 12:
                    birthdayMonth = "December";
                    break;
                default:
                    break;

            }
            birthDate = birthdayYear + " " + birthdayMonth + " " + birthdayDay;

            int sum = int.Parse(egn.Substring(0, 1)) * 2 + int.Parse(egn.Substring(1, 1)) * 4 + int.Parse(egn.Substring(2, 1)) * 8
            + int.Parse(egn.Substring(3, 1)) * 5 + int.Parse(egn.Substring(4, 1)) * 10 + int.Parse(egn.Substring(5, 1)) * 9 +
            int.Parse(egn.Substring(6, 1)) * 7 + int.Parse(egn.Substring(7, 1)) * 3 + int.Parse(egn.Substring(8, 1)) * 6;

            int result = (sum / 11) * 11;
            double lastNumControl = sum - result;

            lastNumControl = lastNumControl % 11;

            bool controlNum = false;

            if (lastNumControl < 10 && lastNumControl == Int32.Parse(egn.Substring(9, 1)))
            {
                controlNum = true;
            }
            else if (Int32.Parse(egn.Substring(9, 1)) == 0)
            {
                controlNum = true;
            }
            else controlNum = false;

            //check if year is leap
            bool leapYear = true;
            if (birthdayMonth == "February")
            {
                if (birthdayDay == "29")
                {
                    if (!(Int32.Parse(birthdayYear) % 4 == 0 || Int32.Parse(birthdayYear) % 100 == 0 || Int32.Parse(birthdayYear) % 400 == 0))
                    {
                        leapYear = false;
                    }
                }
            }

            if (controlNum && leapYear)
            {
                exists = true;
            }
            else
            {
                exists = false;
            }

            //ENUM check
            if (int.Parse(egn.Substring(8, 1)) % 2 == 0)
            {
                sex = Sex.Male;
            }
            else
            {
                sex = Sex.Female;
            }
        }
    }
}
