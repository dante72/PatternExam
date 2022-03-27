using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    interface IObservable
    {
        void AddObserver(IObserver observer);
        void NotifyObservers(string property, object value);
        void RemoveObserver(IObserver observer);
    }
}
