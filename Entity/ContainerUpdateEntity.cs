using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class ContainerUpdateEntity
    {
        [Range(1, long.MaxValue)] 
        public long Id { get; set; }

        [Required] // String değeri boş olamaz
        [MaxLength(50),MinLength(1)]
        public string ContainerName { get; set; }
        [Range (-90.0,90.0)]
        public decimal Latitude { get; set; }
        [Range(-180.0, 180.0)]
        public decimal Longitude { get; set; }
    }
}
