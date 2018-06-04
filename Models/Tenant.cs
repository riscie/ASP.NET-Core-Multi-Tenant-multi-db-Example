using System;
using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Models
{
    public class Tenant
    {
        [Key]
        public Guid Guid { get; set; }

        public string ConnectionString { get; set; }
        public string Name { get; set; }
    }
}