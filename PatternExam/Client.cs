using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    class Client : Person, IEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Id,10} - {Name,10}\t{Surname,10}\t{SecondName,10}\t{Birthday}\t{Phone,10}";
        }

    }
}
