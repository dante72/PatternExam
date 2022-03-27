using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    class Facade
    {
        private readonly TourBase _tourBase;
        private readonly ClientBase _clientBase;

        private static DateTime _beginDate;
        private static int _days;

        public Facade(TourBase tourBase, ClientBase clientBase)
        {
            _tourBase = tourBase;
            _clientBase = clientBase;
        }

        public void AddClient(string name, string surname, string secondName, DateTime birthday, string phone, string address)
        {
            _clientBase.Add(name, surname, secondName, birthday, phone, address);
        }

        public void CreateTour()
        {
            DateChoise();
            CountOfDaysChoise();
            TourChoise();
        }

        private void DateChoise()
        {
            do
            {
                Console.WriteLine("Введите дату (01\\01\\2022)\n");
            } while (DateTime.TryParse(Console.ReadLine(), out _beginDate));

        }

        private void CountOfDaysChoise()
        {
            while (true)
            {
                Console.WriteLine("Введите количество дней (не более 30 дней)\n");
                if (int.TryParse(Console.ReadLine(), out _days))
                {
                    if (_days >= 0 && _days <= 30)
                        break;
                }
            }
        }
        private void TourChoise()
        {
            string answer = "";
            while (true)
            {
                Console.WriteLine("Выберете путевку\nS - Сочи\nE - Египет\n");
                try
                {
                    answer = Console.ReadLine();
                    _tourBase.Add(answer, _beginDate, _days);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
