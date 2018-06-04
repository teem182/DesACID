namespace DesACID_ApiWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Paises
    {
        [Required]
        [StringLength(100)]
        public string Country_Name { get; set; }

        [Key]
        [StringLength(50)]
        public string Country_Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Region { get; set; }

        [Required]
        [StringLength(50)]
        public string Income_Group { get; set; }
    }
}
