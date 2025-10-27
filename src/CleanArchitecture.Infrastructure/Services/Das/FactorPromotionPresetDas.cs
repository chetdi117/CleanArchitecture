using CleanArchitecture.Domain.Entities.Factor.FactorFilters;
using CleanArchitecture.Domain.Entities.Promotion;
using CleanArchitecture.Domain.Entities.User;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services.Das
{
    public class FactorPromotionPresetDas: IFactorPromotionPresetDas
    {
        private MongoDbContext _context;
        public FactorPromotionPresetDas(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<List<FactorPromotionPreset>> GetAllAsync()
        {
            var promotions = await _context.Promotions.AsQueryable().ToListAsync();
            return promotions.ConvertAll(p => new FactorPromotionPreset
            {
                Id = p.Id,
                Title = p.Title,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                DiscountPercentage = p.DiscountPercentage
            });
        }

        public async Task<FactorPromotionPreset> GetByIdAsync(string id)
        {
            var promotion = await _context.Promotions.AsQueryable()
                                           .FirstOrDefaultAsync(u => u.Id.Equals(id, StringComparison.Ordinal));
            if (promotion == null) // Fix for CS8602: Check if user is null before dereferencing
            {
                return null;
            }

            return new FactorPromotionPreset
            {
                Id = promotion.Id,
                Title = promotion.Title,
                StartDate = promotion.StartDate,
                EndDate = promotion.EndDate,
                DiscountPercentage = promotion.DiscountPercentage
            };
        }

        public async Task<FactorPromotionPreset> AddAsync(FactorPromotionPreset entity)
        {
            var promotion = new Promotion
            {
                Id = entity.Id ?? Guid.NewGuid().ToString(),
                Title = entity.Title,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                DiscountPercentage = entity.DiscountPercentage
            };
            await _context.Promotions.InsertOneAsync(promotion);
            entity.Id = promotion.Id;
            return entity;
        }

        public async Task UpdateAsync(FactorPromotionPreset entity)
        {
            await _context.Promotions.ReplaceOneAsync(u => u.Id == entity.Id, new Promotion
            {
                Id = entity.Id,
                Title = entity.Title,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                DiscountPercentage = entity.DiscountPercentage
            });

        }

        public async Task DeleteAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                await _context.Users.DeleteOneAsync(u => u.Id == id);
            }
        }

        public Task<FactorPromotionPreset> GetByIdAsync(int id)
        {
            var promotion = _context.Promotions.AsQueryable().FirstOrDefault(u => u.Id.Equals(id.ToString(), StringComparison.Ordinal));
            if (promotion == null) // Fix for CS8602: Check if user is null before dereferencing
            {
                return Task.FromResult<FactorPromotionPreset>(null);
            }


            return Task.FromResult(new FactorPromotionPreset
            {
                Id = promotion.Id,
                Title = promotion.Title,
                StartDate = promotion.StartDate,
                EndDate = promotion.EndDate,
                DiscountPercentage = promotion.DiscountPercentage
            });
        }
    }
}
