namespace DesACID_ApiWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Datos
    {
        [Key]
        public int Datos_id { get; set; }

        [StringLength(50)]
        public string country_code { get; set; }

        [StringLength(50)]
        public string Indicador { get; set; }

        [StringLength(50)]
        public string Tasa { get; set; }

        public int? Ano { get; set; }

        [StringLength(100)]
        public string Country_Name { get; set; }
    }
}
