using System.Collections.Generic;

namespace LegacyApp
{
    public class Client
    {
        public string Name { get; internal set; }
        public int ClientId { get; internal set; }
        public string Email { get; internal set; }
        public string Address { get; internal set; }
        public string Type { get; set; }
    }

    public partial class ClientService
    {
        private readonly List<Client> _clients;

        public ClientService()
        {
            _clients = new List<Client>();
        }

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public void RemoveClient(int clientId)
        {
            _clients.RemoveAll(c => c.ClientId == clientId);
        }

        public List<Client> GetAllClients()
        {
            return _clients;
        }
    }
}