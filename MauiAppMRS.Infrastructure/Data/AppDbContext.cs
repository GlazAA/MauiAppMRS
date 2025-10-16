using Microsoft.EntityFrameworkCore;
using MauiAppMRS.Core.Entities;

namespace MauiAppMRS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<Installation> Installations { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationAddress> OrganizationAddresses { get; set; }
        public DbSet<OrganizationEmployee> OrganizationEmployees { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilitySystem> FacilitySystems { get; set; }
        public DbSet<SystemEquipmentType> SystemEquipmentTypes { get; set; }
        public DbSet<EquipmentModel> EquipmentModels { get; set; }
        public DbSet<ChecklistTemplate> ChecklistTemplates { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<ChecklistTemplateItem> ChecklistTemplateItems { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistResponse> ChecklistResponses { get; set; }
        public DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<ChecklistDocumentation> ChecklistDocumentations { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<OwnershipForm> OwnershipForms { get; set; }
        public DbSet<OrganizationData> OrganizationData { get; set; }
        public DbSet<UserPersonalData> UserPersonalData { get; set; }
        public DbSet<OrganizationHistory> OrganizationHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Составной ключ для SystemEquipmentType
            modelBuilder.Entity<SystemEquipmentType>()
                .HasKey(x => new { x.SystemId, x.EquipmentTypeId });

            // Настройка каскадного удаления
            modelBuilder.Entity<ChecklistResponse>()
                .HasOne(cr => cr.Checklist)
                .WithMany(c => c.Responses)
                .HasForeignKey(cr => cr.ChecklistId)
                .OnDelete(DeleteBehavior.Cascade);

            // Индексы для производительности
            modelBuilder.Entity<Checklist>()
                .HasIndex(c => new { c.InstallationId, c.MaintenanceTypeId });

            modelBuilder.Entity<MaintenanceHistory>()
                .HasIndex(m => m.InstallationId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();
        }
    }
}