using CleanArchitecture.Domain.Entities.Factor.FactorFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces.Das
{
    public interface IFactorUserPresetDas
    {
        Task<List<FactorUserPreset>> GetAllAsync();

        Task<FactorUserPreset> GetByIdAsync(string id);

        Task<FactorUserPreset> AddAsync(FactorUserPreset entity);

        Task UpdateAsync(FactorUserPreset entity);

        Task DeleteAsync(string id);
    }
}
