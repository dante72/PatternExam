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

        private DateTime _beginDate;
        private int _days;
        private string _typeTour;
        private List<Client> _clients;

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
            TourChoise();
            DateChoise();
            CountOfDaysChoise();
            AddClientsToTour();
            var tour = _tourBase.GetTourFactory(_typeTour, _beginDate, _days).GetTour();
            tour.Clients = _clients;
            _tourBase.Add(tour);
            Console.WriteLine(tour);

        }

        private void AddClientsToTour()
        {
            _clients = new List<Client>();
            Console.WriteLine("Выберите клиентов из списка:\n");
            foreach(var client in _clientBase.Clients)
                Console.WriteLine(client);

            int clientId;
            while(true)
            {
                try
                {
                    Console.WriteLine("Введите верный Id клиента или 0 для выхода:\n");
                    if (int.TryParse(Console.ReadLine(), out clientId))
                    {
                        if (clientId == 0 && _clients.Count > 0)
                            break;

                        var client = _clientBase.Clients.First(i => i.Id == clientId);

                        if (_clients.Contains(client))
                            Console.WriteLine("Этот клиент уже добавлен");
                        else
                        {
                            _clients.Add(client);
                            Console.WriteLine("Клиент добавлен!");
                        }
                    }
                }
                catch
                {

                }
                
            }
        }

        private void DateChoise()
        {
            do
            {
                Console.WriteLine("Введите дату (dd\\mm\\yy)\n");
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
            while (true)
            {
                Console.WriteLine("Выберете путевку\nS - Сочи\nE - Египет\n");
                try
                {
                    _typeTour = Console.ReadLine();
                    _ = _tourBase.GetTourFactory(_typeTour, _beginDate, _days);
                   
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
