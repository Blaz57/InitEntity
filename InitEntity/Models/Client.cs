using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InitEntity.Models
{
    public class Client
    {
        public int Id { get; set; }

        // Permet de rendre obligatoire le renseignement du nom et affiche un message d'erreur lorsque cela n'est pas fait.
        [Required (ErrorMessage ="Le prénom est recquis")]
        [StringLength(32,MinimumLength =2, ErrorMessage ="Leprénom est trop long")]
        [Display(Name ="Prénom")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Le nom est recquis")]
        public string Lastname { get; set; }

        public Client()
        {
        }
        
    }
}