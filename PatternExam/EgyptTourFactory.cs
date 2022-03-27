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
        public EgyptTourFactory(DateTime begin, int days, decimal dayPrice)
        {
            _name = "Egypt Tour";
            _description = "YearRound season, pyramids";
            _price = dayPrice * days;
            _begin = begin;
            _end = begin + TimeSpan.FromDays(days);
        }
        public override Tour GetTour()
        {
            return new EgyptTour()
            {
                Price = _price,
                Description = _description,
                Name = _name,
                BeginDate = _begin,
                EndDate = _end
            };
        }
    }
}
