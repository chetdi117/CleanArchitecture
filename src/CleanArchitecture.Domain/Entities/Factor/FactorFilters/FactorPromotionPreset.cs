using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Factor.FactorFilters
{
    public class FactorPromotionPreset : EntityBase<string>
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal DiscountPercentage { get; set; }

        public static FactorPromotionPreset New(string title, DateTime startDate, DateTime enđate) => new FactorPromotionPreset
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            StartDate = startDate,
            EndDate = enđate
        };

        public FactorPromotionPreset WithTitle(string title)
        {
            Title = title;
            return this;
        }
    }
}
