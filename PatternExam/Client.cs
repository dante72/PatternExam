using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    class Client : Person, IEntity, IObserver
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string History { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name,7}\t{Surname,7}\t{SecondName,7}\t{Birthday.ToShortDateString()}\t{Phone,7}\nHistory: {History}\n";
        }

        public void Update(string property, object value)
        {
            switch(property)
            {
                case "Client":
                    History += $"\nКлиент добавлен! Id - {value} ({DateTime.Now})";
                    break;
                case "BeginDate":
                    History += $"\nНачальная дата изменена - {((DateTime)value).ToShortDateString()} ({DateTime.Now})";
                    break;
                case "EndDate":
                    History += $"\nКонечная дата изменена - {((DateTime)value).ToShortDateString()} ({DateTime.Now})";
                    break;
                default:
                    History += $"\n{property} changed on {value} ({DateTime.Now})";
                    break;
            }
            
        }
    }
}
