using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Gestion.Models;

namespace Gestion.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
           
            modelBuilder.Entity<Commande>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Commandes)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Produit>();
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Livraison>();

            
            
        }

        public DbSet<Client>? Clients{ get; set; }
        public DbSet<User>? Users{ get; set; }
        public DbSet<Dette>? Commandes{ get; set; }
        public DbSet<Article>? Produits{ get; set; }
        public DbSet<Payment>? Payments{ get; set; }
        public DbSet<Livraison>? Livraisons { get; set; }
        
    }
}