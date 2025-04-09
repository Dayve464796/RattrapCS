using System;
using System.Collections.Generic;
using Gestion.Entities;
using Gestion.View;
using Gestion.Service;
using Gestion.Service.Impl;
using Gestion.Repository;
using Gestion.Repository.Impl;
using Gestion.Core;
using Gestion.Core.Factory;
using Gestion.Enums;

namespace Gestion
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IRepositoryFactory? factory = AbstractFactory.CreateFactory(Persistence.DATABASE);

            IRepositoryClient? repositoryClient = factory?.CreateClientRepository();
            IRepositoryNumero? repositoryNumero = factory?.CreateNumeroRepository();

            ClientService clientService = new ClientService(repositoryClient);
            NumeroService numeroService = new NumeroService(repositoryNumero);

            bool running = true;
            do
            {
                int choix = Menu();
                switch (choix)
                {
                    case 1: // Créer un client
                        Client newClient = new Client();
                        do
                        {
                            newClient = ClientView.CreateClient();
                        } while (clientService.GetByTel(newClient.Telephone) != null);

                        
                        clientService.Create(newClient);
                        Console.WriteLine("Client créer.");
                        break;

                    case 2: // Lister les clients
                        ClientView.ListClients(clientService.Show());
                        break;

                    case 3: // Ajouter un numéro à un client
                        Console.Write("Entrez un ID du client : ");
                        if (int.TryParse(Console.ReadLine(), out int clientId))
                        {
                            Client client = clientService.GetById(clientId);
                            if (client != null)
                            {
                                Numero numero = NumeroView.CreateNumero();
                                numero.ClientId = client.Id;
                                numero.Client = client;

                                numeroService.Create(numero);
                                Console.WriteLine("Numéro ajouté au client avec succes.");
                            }
                            else
                            {
                                Console.WriteLine("Client introuvable.");
                            }
                        }
                        else Console.WriteLine("ID invalide.");
                        break;

                    case 4: // Lister tous les numéros
                        NumeroView.ListNumeros(numeroService.Show());
                        break;

                    case 5: // Filtrer les numéros par client
                        Console.Write("Entrez l'ID du client : ");
                        if (int.TryParse(Console.ReadLine(), out int idClient))
                        {
                            List<Numero> numeros = numeroService.FindByClient(idClient);
                            NumeroView.ListNumeros(numeros);
                        }
                        else Console.WriteLine("ID invalide.");
                        break;

                    case 6: // Filtrer les numéros par opérateur
                        Console.Write("Entrez l’opérateur  : ");
                        string op = Console.ReadLine();
                        List<Numero> liste = numeroService.FindByOperateur(op);
                        NumeroView.ListNumeros(liste);
                        break;

                    case 7: // Quitter
                        running = false;
                        Console.WriteLine("Bye !");
                        break;

                    default:
                        Console.WriteLine("Choix invalider.");
                        break;
                }
            } while (running);
        }

        public static int Menu()
        {
            int choix;
            do
            {
                Console.WriteLine("\n============= Menu =============");
                Console.WriteLine("1. Créer un client");
                Console.WriteLine("2. Lister les clients");
                Console.WriteLine("3. Ajouter un numero à un client");
                Console.WriteLine("4. Lister tous les numeros");
                Console.WriteLine("5. Filtrer les numeros par client");
                Console.WriteLine("6. Filtrer les numeros par operateur");
                Console.WriteLine("7. Quitte");
                Console.Write("faites un   choix : ");

                if (int.TryParse(Console.ReadLine(), out choix) && choix >= 1 && choix <= 7)
                    return choix;

                Console.WriteLine("Choix invalide. .");
            } while (true);
        }
    }
}
