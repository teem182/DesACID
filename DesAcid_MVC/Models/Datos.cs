namespace DesACID_ApiWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Datos
    {
        [Required]
        [StringLength(50)]
        public string Country_code { get; set; }

        [Key]
        [StringLength(50)]
        public string Indicador { get; set; }

        [Required]
        [StringLength(50)]
        public string Tasa { get; set; }

        [Required]
        
        public int Ano {get; set; }

        [StringLength(100)]
        public string Country_Name { get; set; }
    }
}
