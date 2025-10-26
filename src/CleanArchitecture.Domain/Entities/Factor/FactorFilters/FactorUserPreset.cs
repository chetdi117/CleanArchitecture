using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArchitecture.Domain.Entities.Factor.FactorFilters
{
    public class FactorUserPreset : EntityBase<string>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public static FactorUserPreset New(string email, string name, string phone) => new FactorUserPreset
        {
            Id = Guid.NewGuid().ToString(),
            FullName = name,
            Email = email,
            Phone = phone
        };

        public FactorUserPreset WithName(string name)
        {
            FullName = name;
            return this;
        }
    }
}
