using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class ClientsManager
    {
        private Dictionary<string, Client> m_clients;

        public ClientsManager()
        {
            m_clients = new Dictionary<string, Client>();
        }

        public void AddClient(string token, Client client)
        {
            try
            {
                m_clients.Add(token, client);
            }
            catch
            {
                throw new TokenException();
            }
        }

        public void RemoveClient(string token)
        {
            if (!m_clients.Remove(token))
                Console.WriteLine("client manager line 33 error");    
        }
        public void RemoveClient(Client client)
        {
            foreach (var item in m_clients.Where(kvp => kvp.Value == client).ToList())
            {
                m_clients.Remove(item.Key);
                return;
            }
            Console.WriteLine("client manager line 42 error");
        }
        private void RemoveDeadClients() { } // todo need to run every 1 minute when stateless
        // put time in m_clients

        public Client GetClient(string token)
        {
            try
            {
                return m_clients[token];
            }
            catch (Exception)
            {
                Console.WriteLine("clinet manager line 56 error");
                throw;
            }
        }

        public int GetCount() { return m_clients.Count; }
    }
}