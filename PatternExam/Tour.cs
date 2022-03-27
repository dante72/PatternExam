using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    abstract class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Client Owner { get; set; }
        public override string ToString()
        {
            return $"{Name}\n{Description}\nPrice: {Price}\nBeginDate: {BeginDate.ToShortDateString()}\nEndDate: {EndDate.ToShortDateString()}\nOwner: {Owner?.Name} {Owner?.Surname} {Owner?.SecondName}";
        }

    }
}
