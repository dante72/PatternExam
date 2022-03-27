using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    class SochiTourFactory : TourFactory
    {
        private readonly decimal _price;
        private readonly string _description;
        private readonly string _name;
        private readonly DateTime _begin;
        private readonly DateTime _end;
        private readonly List<Client> _clients;
        public SochiTourFactory(DateTime begin, int days, decimal dayPrice, List<Client> clients = null)
        {
            _name = "Sochi Tour";
            _begin = begin;
            _end = begin + TimeSpan.FromDays(days);
            _clients = clients;

            var beginSeason = GetSeason(_begin);

            if (beginSeason == Season.Summer)
            {
                _description = "Summer tour, swiming";
                _price = dayPrice * days / 2;
            }
            else
            {
                _description = "Winter tour, skiing";
                _price = dayPrice * days;
            }

        }
        public override Tour GetTour()
        {
            var tour = new SochiTour();
            foreach (var client in _clients)
                tour.AddClient(client);
            tour.Price = _price;
            tour.Description = _description;
            tour.Name = _name;
            tour.BeginDate = _begin;
            tour.EndDate = _end;

            return tour;
        }

        private Season GetSeason(DateTime date)
        {
            if (date.Month >= 10 && date.Day >= 20 && date.Month <= 12 || date.Month >= 1 && date.Month <= 3)
                return Season.Winter;

            return Season.Summer;
        }
    }
}
