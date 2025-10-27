using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.DTO;
public class PromotionDTO
{
    public string Id { get; set; }
    [Required]
    public string? Title { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal DiscountPercentage { get; set; }
}

public class PromotionFormDTO
{
    [Required]
    public string? Title { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal DiscountPercentage { get; set; }
}
