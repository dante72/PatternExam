using System;

namespace PatternExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientBase = new ClientBase();
            var tourBase = new TourBase();

            var facade = new Facade(tourBase, clientBase);

            facade.CreateTour();
        }
    }
}
