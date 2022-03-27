using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    abstract class Tour : IEntity, IObservable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        private DateTime _beginDate;
        public DateTime BeginDate {
            get => _beginDate;
            set
            {
                _beginDate = value;
                NotifyObservers(nameof(BeginDate), _beginDate);
            }
        }
        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                NotifyObservers(nameof(EndDate), _endDate);
            }
        }
        public List<Client> Clients { get; set; } = new List<Client>();

        public void AddClient(Client client)
        {
            Clients.Add(client);
            NotifyObservers("Client", client.Id);
        }
        public void AddObserver(IObserver observer)
        {
            AddClient((Client)observer);
        }

        public void NotifyObservers(string property, object value)
        {
            foreach (var observer in Clients)
                observer.Update(property, value);
        }

        public void RemoveObserver(IObserver observer)
        {
            Clients.Remove((Client)observer);
        }

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
