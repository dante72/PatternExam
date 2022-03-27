using System;

namespace PatternExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientBase = new ClientBase();
            clientBase.Add("Petr", "Petrov", "Petrovich", DateTime.Parse("22/02/01"), "77-77-77", "Moscow");
            clientBase.Add("Ivan", "Ivanov", "Ivanovich", DateTime.Parse("11/11/01"), "77-77-75", "Moscow");
            var tourBase = new TourBase();

            var facade = new Facade(tourBase, clientBase);

            facade.CreateTour();

            facade.PrintAllClients();
        }
    }
}
