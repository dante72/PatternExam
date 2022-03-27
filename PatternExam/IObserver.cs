using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    interface IObserver
    {
        void Update(string property, object value);
    }
}
