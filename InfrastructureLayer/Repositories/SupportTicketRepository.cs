using CoreLayer.Entities;
using CoreLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class SupportTicketRepository : ISupportTicketRepository
    {
        private readonly AppDbContext _context;

        public SupportTicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupportTicketEntity>> GetAllAsync()
        {
            return await _context.SupportTickets
                .OrderByDescending(t => t.Status == "open")
                .ThenByDescending(t => t.CreatedAt)
                .Take(100)
                .ToListAsync();
        }


        public async Task<SupportTicketEntity?> GetByIdAsync(int id)
        {
            return await _context.SupportTickets
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<SupportTicketEntity>> GetByUserIdAsync(int userId)
        {
            return await _context.SupportTickets
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(SupportTicketEntity ticket)
        {
            await _context.SupportTickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SupportTicketEntity ticket)
        {
            _context.SupportTickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticket = await _context.SupportTickets.FindAsync(id);
            if (ticket != null)
            {
                _context.SupportTickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> MarkAsOpenAsync(int id)
        {
            var ticket = await _context.SupportTickets.FindAsync(id);
            if (ticket != null)
            {
                ticket.Status = "open";
                ticket.UpdatedAt = DateTime.UtcNow;
                _context.SupportTickets.Update(ticket);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> MarkAsClosedAsync(int id)
        {
            var ticket = await _context.SupportTickets.FindAsync(id);
            if (ticket != null)
            {
                ticket.Status = "closed";
                ticket.UpdatedAt = DateTime.UtcNow;
                _context.SupportTickets.Update(ticket);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
