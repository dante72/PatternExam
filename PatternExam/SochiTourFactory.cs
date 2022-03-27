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
        public SochiTourFactory(DateTime begin, int days, decimal dayPrice)
        {
            _name = "Sochi Tour";
            _begin = begin;
            _end = begin + TimeSpan.FromDays(days);

            var beginSeason = GetSeason(_begin);
            var endSeason = GetSeason(_end);

            if (beginSeason != endSeason)
                throw new Exception("Error! Fix interval days");

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
            return new SochiTour()
            {
                Price = _price,
                Description = _description,
                Name = _name,
                BeginDate = _begin,
                EndDate = _end
            };
        }

        private Season GetSeason(DateTime date)
        {
            if (date.Month >= 10 && date.Day >= 20 && date.Month <= 12 || date.Month >= 1 && date.Month <= 3)
                return Season.Winter;

            return Season.Summer;
        }
    }
}
