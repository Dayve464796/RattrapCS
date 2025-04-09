using Gestion.Entities;

namespace Gestion.View
{
    public static class ClientView
    {
        public static void ListClients(List<Client> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine($"Id: {client.Id}, Surnom: {client.Surnom}, Telephone: {client.Telephone}, Addresse: {client.Adresse}");
            }
        }

        public static Client CreateClient()
        {

            Console.WriteLine("New client:");
            Console.Write("Veuillez entrer un surnom au client: ");
            string surnom = Console.ReadLine();
            
            Console.Write("Veuillez entrer le numéro de téléphone du client: ");
            string telephone = Console.ReadLine();
            
            Console.Write("Veuillez saisir l'adresse  du client: ");
            string addresse = Console.ReadLine();

            return new Client(surnom, telephone, addresse);
        }
    }
}