using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Models
{
    public class CreateUserWithRoleViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required] 
        public string Nome { get; set; }
        [Required] 
        public string Apelido { get; set; }
        [Required]
        public string idRole { get; set; }
        [Required]
        [Display(Name = "Regadio")]
        public string [] IdRegadios { get; set; }
        [Required]
        [Display(Name = "Menu")]
        public string [] IdInqueritos { get; set; }
        [Required]
        [Display(Name = "Associação")]
        public string[] IdAssociacaoes { get; set; }
        [Required]
        [Display(Name = "Escola")]
        public string[] IdEscolas { get; set; }
    }
}
