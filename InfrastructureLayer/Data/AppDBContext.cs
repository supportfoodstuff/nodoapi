using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;
using InfrastructureLayer.Repositories;

namespace InfrastructureLayer.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<FaqEntity> Faqs { get; set; }
        public DbSet<PoActivityLogEntity> PoActivityLogs { get; set; }
        public DbSet<PoStatisticsMonthlyEntity> PoStatisticsMonthly { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PurchaseOrderEntity> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItemEntity> PurchaseOrderItems { get; set; }
        public DbSet<RepaymentEntity> Repayments { get; set; }
        public DbSet<SettingEntity> Settings { get; set; }
        public DbSet<SupportTicketEntity> SupportTickets { get; set; }
        public DbSet<SupportTicketLogEntity> SupportTicketLogs { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SubUserEntity> SubUsers { get; set; }
        public DbSet<VendorEntity> Vendors { get; set; }
    }
}
