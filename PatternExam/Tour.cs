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
        public List<Client> Clients { get; set; }
        public override string ToString()
        {
            var str = $"{Name}\n{Description}\nPrice: {Price}\nBeginDate: {BeginDate.ToShortDateString()}\nEndDate: {EndDate.ToShortDateString()}\nClients:\n";
            foreach(var client in Clients)
            {
                str += $"{client.Name}\t{client.Surname}\t{client.Birthday.ToShortDateString()}\n";
            }
            return str;
        }

    }
}
