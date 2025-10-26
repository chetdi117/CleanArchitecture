using CleanArchitecture.Domain.Entities.Factor.FactorFilters;
using CleanArchitecture.Domain.Entities.User;
using CleanArchitecture.Domain.Interfaces.Das;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services.Das
{
    public class FactorUserPresetDas : IFactorUserPresetDas
    {
        private MongoDbContext _context;
        public FactorUserPresetDas(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<List<FactorUserPreset>> GetAllAsync()
        {
            var users = await _context.Users.AsQueryable().ToListAsync();
            return users.ConvertAll(u => new FactorUserPreset
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Phone = u.Phone
            });
        }

        public async Task<FactorUserPreset> GetByIdAsync(string id)
        {
            var user = await _context.Users.AsQueryable()
                                           .FirstOrDefaultAsync(u => u.Id.Equals(id, StringComparison.Ordinal));
            if (user == null) // Fix for CS8602: Check if user is null before dereferencing
            {
                return null;
            }

            return new FactorUserPreset
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Phone = user.Phone
            };
        }

        public async Task<FactorUserPreset> AddAsync(FactorUserPreset entity)
        {
            var user = new User
            {
                Id = entity.Id ?? Guid.NewGuid().ToString(),
                FullName = entity.FullName,
                Email = entity.Email,
                Phone = entity.Phone,
            };
            await _context.Users.InsertOneAsync(user);
            entity.Id = user.Id;
            return entity;
        }

        public async Task UpdateAsync(FactorUserPreset entity) { 
            await _context.Users.ReplaceOneAsync(u => u.Id == entity.Id, new User
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Phone = entity.Phone,
            });

        }

        public async Task DeleteAsync(string id) {
            if(!string.IsNullOrEmpty(id))
            {
                await _context.Users.DeleteOneAsync(u => u.Id == id);
            }
        }

        public Task<FactorUserPreset> GetByIdAsync(int id)
        {
            var user = _context.Users.AsQueryable().FirstOrDefault(u => u.Id.Equals(id.ToString(), StringComparison.Ordinal));
            if(user == null) // Fix for CS8602: Check if user is null before dereferencing
            {
                return Task.FromResult<FactorUserPreset>(null);
            }


            return Task.FromResult(new FactorUserPreset
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Phone = user.Phone
            });
        }
    }
}
