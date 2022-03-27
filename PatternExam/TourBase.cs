using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    class TourBase
    {
        private static int currentId = 1;
        public List<Tour> Tours { get; } = new List<Tour>();

        public void Add(string name, DateTime beginDate, int days, List<Client> clients = null)
        {
            var factory = GetTourFactory(name, beginDate, days);
            var tour = factory.GetTour();
            tour.Clients = clients;
            tour.Id = currentId++;
            Tours.Add(tour);
        }

        public void Add(Tour tour)
        {
            tour.Id = currentId++;
            if (tour?.Clients.Count > 0)
                tour.Price *= tour.Clients.Count;
            Tours.Add(tour);
        }

        public TourFactory GetTourFactory(string name, DateTime beginDate, int days)
        {
            switch (name.ToLower())
            {
                case "s":
                    return new SochiTourFactory(beginDate, days, 2000);
                case "e":
                    return new EgyptTourFactory(beginDate, days, 1000);
                default:
                    throw new Exception("Error factory!");
            }
        }

    }
}
