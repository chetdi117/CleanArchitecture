using CleanArchitecture.Domain.Entities.Factor.FactorFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Services.Das
{
    public interface IFactorPromotionPresetDas
    {
        Task<List<FactorPromotionPreset>> GetAllAsync();

        Task<FactorPromotionPreset> GetByIdAsync(string id);

        Task<FactorPromotionPreset> AddAsync(FactorPromotionPreset entity);

        Task UpdateAsync(FactorPromotionPreset entity);

        Task DeleteAsync(string id);
    }
}
