using Chapter.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Chapter.WebApi.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Essa string de conexão foi depende da SUA máquina.
                //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;" + "Database=Chapter;Trusted_Connection=True;");

                // Exemplo 1 de string de conexão:
                optionsBuilder.UseSqlServer("UserID=sa; Password=12345; Server=16.0.1050; Database=Chapter;" + "Trusted_Connection=True;");

                // UserPassword= ID=sa;admin;Server=localhost;Database=Chapter;-
                // + Trusted_Connection=False;

                // Exemplo 2 de string de conexão:
                //Server=localhost\\SQLEXPRESS;Database=Chapter;Trusted_Connection=True;
            }
        }
        public DbSet<Livro> Livros { get; set; }
    }
}