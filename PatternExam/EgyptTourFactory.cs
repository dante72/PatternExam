using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    class EgyptTourFactory : TourFactory
    { 
        private readonly decimal _price;
        private readonly string _description;
        private readonly string _name;
        private readonly DateTime _begin;
        private readonly DateTime _end;
        private readonly List<Client> _clients;
        public EgyptTourFactory(DateTime begin, int days, decimal dayPrice, List<Client> clients = null)
        {
            _name = "Egypt Tour";
            _description = "YearRound season, pyramids";
            _price = dayPrice * days;
            _begin = begin;
            _end = begin + TimeSpan.FromDays(days);
            _clients = clients;
        }
        public override Tour GetTour()
        {
            var tour = new EgyptTour();
            foreach (var client in _clients)
                tour.AddClient(client);
            tour.Price = _price;
            tour.Description = _description;
            tour.Name = _name;
            tour.BeginDate = _begin;
            tour.EndDate = _end;

            return tour;
        }
    }
}
