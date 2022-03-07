using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AlatechMachines.webAPI.Domains;

#nullable disable

namespace AlatechMachines.webAPI.Contexts
{
    public partial class AlatechDbContext : DbContext
    {
        public AlatechDbContext()
        {
        }

        public AlatechDbContext(DbContextOptions<AlatechDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Badge80Plu> Badge80Plus { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<GraphicCard> GraphicCards { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<MachineHasStorageDevice> MachineHasStorageDevices { get; set; }
        public virtual DbSet<Motherboard> Motherboards { get; set; }
        public virtual DbSet<PowerSupply> PowerSupplies { get; set; }
        public virtual DbSet<Processor> Processors { get; set; }
        public virtual DbSet<RamMemory> RamMemories { get; set; }
        public virtual DbSet<RamMemoryType> RamMemoryTypes { get; set; }
        public virtual DbSet<SocketType> SocketTypes { get; set; }
        public virtual DbSet<StorageDevice> StorageDevices { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=DESKTOP-KVKV9TT\\SA; initial catalog=AlatechMachines; user id=sa; pwd=senai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Badge80Plu>(entity =>
            {
                entity.ToTable("badge80Plus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GraphicCard>(entity =>
            {
                entity.ToTable("graphicCard");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.MemorySize).HasColumnName("memorySize");

                entity.Property(e => e.MemoryType).HasColumnName("memoryType");

                entity.Property(e => e.MinimumPowerSupply).HasColumnName("minimumPowerSupply");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.SupportMultiGpu).HasColumnName("supportMultiGpu");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.GraphicCards)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__graphicCa__brand__3B75D760");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.ToTable("machine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.GraphicCardAmount).HasColumnName("graphicCardAmount");

                entity.Property(e => e.GraphicCardId).HasColumnName("graphicCardId");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.MotherboardId).HasColumnName("motherboardId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PowerSupplyId).HasColumnName("powerSupplyId");

                entity.Property(e => e.ProcessorId).HasColumnName("processorId");

                entity.Property(e => e.RamMemoryAmount).HasColumnName("ramMemoryAmount");

                entity.Property(e => e.RamMemoryId).HasColumnName("ramMemoryId");

                entity.HasOne(d => d.GraphicCard)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.GraphicCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__machine__graphic__46E78A0C");

                entity.HasOne(d => d.Motherboard)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.MotherboardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__machine__motherb__440B1D61");

                entity.HasOne(d => d.PowerSupply)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.PowerSupplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__machine__powerSu__47DBAE45");

                entity.HasOne(d => d.Processor)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.ProcessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__machine__process__44FF419A");

                entity.HasOne(d => d.RamMemory)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.RamMemoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__machine__ramMemo__45F365D3");
            });

            modelBuilder.Entity<MachineHasStorageDevice>(entity =>
            {
                entity.ToTable("machineHasStorageDevice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.MachineId).HasColumnName("machineId");

                entity.Property(e => e.StorageDeviceId).HasColumnName("storageDeviceId");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.MachineHasStorageDevices)
                    .HasForeignKey(d => d.MachineId)
                    .HasConstraintName("FK__machineHa__machi__4AB81AF0");

                entity.HasOne(d => d.StorageDevice)
                    .WithMany(p => p.MachineHasStorageDevices)
                    .HasForeignKey(d => d.StorageDeviceId)
                    .HasConstraintName("FK__machineHa__stora__4BAC3F29");
            });

            modelBuilder.Entity<Motherboard>(entity =>
            {
                entity.ToTable("motherboard");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.M2Slots).HasColumnName("m2Slots");

                entity.Property(e => e.MaxTdp).HasColumnName("maxTdp");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PciSlots).HasColumnName("pciSlots");

                entity.Property(e => e.RamMemorySlots).HasColumnName("ramMemorySlots");

                entity.Property(e => e.RamMemoryTypeId).HasColumnName("ramMemoryTypeId");

                entity.Property(e => e.SataSlots).HasColumnName("sataSlots");

                entity.Property(e => e.SocketTypeId).HasColumnName("socketTypeId");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Motherboards)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__motherboa__brand__2E1BDC42");

                entity.HasOne(d => d.RamMemoryType)
                    .WithMany(p => p.Motherboards)
                    .HasForeignKey(d => d.RamMemoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__motherboa__ramMe__2C3393D0");

                entity.HasOne(d => d.SocketType)
                    .WithMany(p => p.Motherboards)
                    .HasForeignKey(d => d.SocketTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__motherboa__socke__2D27B809");
            });

            modelBuilder.Entity<PowerSupply>(entity =>
            {
                entity.ToTable("powerSupply");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Badge80PlusId).HasColumnName("badge80PlusId");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Potency).HasColumnName("potency");

                entity.HasOne(d => d.Badge80Plus)
                    .WithMany(p => p.PowerSupplies)
                    .HasForeignKey(d => d.Badge80PlusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__powerSupp__badge__403A8C7D");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.PowerSupplies)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__powerSupp__brand__412EB0B6");
            });

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.ToTable("processor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BaseFrequency).HasColumnName("baseFrequency");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.CacheMemory).HasColumnName("cacheMemory");

                entity.Property(e => e.Cores).HasColumnName("cores");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.MaxFrequency).HasColumnName("maxFrequency");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.SocketTypeId).HasColumnName("socketTypeId");

                entity.Property(e => e.Tdp).HasColumnName("tdp");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Processors)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__processor__brand__31EC6D26");

                entity.HasOne(d => d.SocketType)
                    .WithMany(p => p.Processors)
                    .HasForeignKey(d => d.SocketTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__processor__socke__30F848ED");
            });

            modelBuilder.Entity<RamMemory>(entity =>
            {
                entity.ToTable("ramMemory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.Frequency).HasColumnName("frequency");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RamMemoryTypeId).HasColumnName("ramMemoryTypeId");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.RamMemories)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ramMemory__brand__35BCFE0A");

                entity.HasOne(d => d.RamMemoryType)
                    .WithMany(p => p.RamMemories)
                    .HasForeignKey(d => d.RamMemoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ramMemory__ramMe__34C8D9D1");
            });

            modelBuilder.Entity<RamMemoryType>(entity =>
            {
                entity.ToTable("ramMemoryType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SocketType>(entity =>
            {
                entity.ToTable("socketType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<StorageDevice>(entity =>
            {
                entity.ToTable("storageDevice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.StorageDeviceInterface).HasColumnName("storageDeviceInterface");

                entity.Property(e => e.StorageDeviceType).HasColumnName("storageDeviceType");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.StorageDevices)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__storageDe__brand__38996AB5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessToken)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("accessToken");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
