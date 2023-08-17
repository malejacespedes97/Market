using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        //las restricciones se ponen encima del campo
        [Display (Name="Pais")]
        [MaxLength (100)]
        [Required  (ErrorMessage ="El campo {0} es obligatorio")] //El campo cero hace referencia al nombre
        public string Name { get; set; } = null;



    }
}
