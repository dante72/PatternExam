using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExam
{
    class ClientBase
    {
        private static int currentId = 1;
        public List<Client> Clients { get; } = new List<Client>();

        public void Add(string name, string surname, string secondName, DateTime birthday, string phone, string address)
        {
            var client = new Client()
            {
                Id = currentId++,
                Name = name,
                Surname = surname,
                SecondName = secondName,
                Birthday = birthday,
                Phone = phone,
                Address = address
            };

            Clients.Add(client);
        }
    }
}
