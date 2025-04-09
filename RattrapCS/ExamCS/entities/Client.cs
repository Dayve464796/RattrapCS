namespace Gestion.Entities
{
    public class Client : IEntity
    {
        private readonly int id;
        private readonly string? nom;
        private readonly string? prenom;
        private static int count=1;
        

        public int Id { get => id; set => id = value; }
        public string? Nom { get => Nom; set => Nom = value; }
        public string? Prenom { get => Prenom; set => Prenom = value; }
        public string? Adresse { get => adresse; set => adresse = value; }
        public List<Commande> Commandes { get ; } = new List<Commande>();
        DateTime CreateAt { get; set; }
        DateTime UpdateAt { get; set; }

      
        void OnPrePersist()
        {
            this.UpdateAt = DateTime.Now;
            this.CreateAt = DateTime.Now;
        }

        
        void OnPreUpdate()
        {
            this.UpdateAt = DateTime.Now;
        }

        public void AddDette(Dette dette)
        {
            Dettes.Add(dette);
            dette.Client = this;
        }

        public void AddUser(User user)
        {
            Compte = user;
            user.Client = this;
        }

        public Client()
        {
           
            id = count++;
            surnom = string.Empty;
            telephone = string.Empty;
            addresse = string.Empty;
        }

        public Client(string surnom, string telephone, string addresse)
        {
            id = count++;
            this.surnom = surnom;
            this.telephone = telephone;
            this.addresse = addresse;
        }

        public override string ToString()
        {
            return $"Client [id={id}, surnom={surnom}, telephone={telephone}, addresse={addresse}]";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is null || GetType() != obj.GetType()) return false;
            var other = (Client)obj;
            return id == other.id &&
                    string.Equals(surnom, other.surnom, StringComparison.Ordinal) &&
                    string.Equals(telephone, other.telephone, StringComparison.Ordinal) &&
                    string.Equals(addresse, other.addresse, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, surnom, telephone, addresse);
        }
    }
}