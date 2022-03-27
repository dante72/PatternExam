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

    }
}
