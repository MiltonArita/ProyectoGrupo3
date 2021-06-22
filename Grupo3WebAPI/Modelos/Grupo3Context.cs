using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Grupo3WebAPI.Modelos
{
    public partial class Grupo3Context : DbContext
    {
       public Grupo3Context()
        {
        }

       public Grupo3Context(DbContextOptions<Grupo3Context> options)
            : base(options)
        {
        }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ComentariosFarmacium> ComentariosFarmacia { get; set; }
        public DbSet<DirectorioMedico> DirectorioMedicos { get; set; }
        public DbSet<Farmacium> Farmacia { get; set; }

        public string connectionString = @"Data Source= DESKTOP-UH6IJIM ;Initial Catalog=GRUPO3;Integrated Security=True";    //llamar la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder options)

          => options.UseSqlServer(connectionString);

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             if (!optionsBuilder.IsConfigured)
             {
 #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                 optionsBuilder.UseSqlServer("Data Source=DESKTOP-UH6IJIM;Initial Catalog=GRUPO3;Integrated Security=True");
             }
         }                                                           //DESKTOP-UH6IJIM  sql

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

             modelBuilder.Entity<Cita>(entity =>
             {
                 entity.HasKey(e => e.IdCita)
                     .HasName("PK_Cita");

                 entity.Property(e => e.ComentarioAdicional).IsUnicode(false);

                 entity.HasOne(d => d.IdClienteNavigation)
                     .WithMany(p => p.Cita)
                     .HasForeignKey(d => d.IdCliente)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_CitaXCliente");

                 entity.HasOne(d => d.IdDoctorNavigation)
                     .WithMany(p => p.Cita)
                     .HasForeignKey(d => d.IdDoctor)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_CitaXDoctor");
             });

             modelBuilder.Entity<Cliente>(entity =>
             {
                 entity.Property(e => e.IdCliente).ValueGeneratedNever();
             });

             modelBuilder.Entity<ComentariosFarmacium>(entity =>
             {
                 entity.HasKey(e => e.IdComentarioFarmacia)
                     .HasName("PK__Comentar__BFF36B497FD6AAD3");

                 entity.HasOne(d => d.IdFarmaciaNavigation)
                     .WithMany(p => p.ComentariosFarmacia)
                     .HasForeignKey(d => d.IdFarmacia)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_ComentariosProductoFarmacia");
             });

             modelBuilder.Entity<DirectorioMedico>(entity =>
             {
                 entity.Property(e => e.IdDoctor).ValueGeneratedNever();
             });

             modelBuilder.Entity<Farmacium>(entity =>
             {
                 entity.HasKey(e => e.IdFarmacia)
                     .HasName("PK__Farmacia__01183E4B6831AFDB");
             });

             OnModelCreatingPartial(modelBuilder);
         }

         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}
