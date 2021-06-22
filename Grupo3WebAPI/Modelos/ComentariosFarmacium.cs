using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Grupo3WebAPI.Modelos
{
    public partial class ComentariosFarmacium
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdComentarioFarmacia { get; set; }
        [Column("idFarmacia")]
        public int IdFarmacia { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Comentarios { get; set; }
        [Column(TypeName = "text")]
        public string PlanDeAccion { get; set; }

        [ForeignKey(nameof(IdFarmacia))]
        [InverseProperty(nameof(Farmacium.ComentariosFarmacia))]
        public virtual Farmacium IdFarmaciaNavigation { get; set; }
        public virtual ICollection<Farmacium> Farmacia { get; set; }
        
    }
}
