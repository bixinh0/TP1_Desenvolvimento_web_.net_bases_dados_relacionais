using System;
using System.ComponentModel.DataAnnotations;

namespace Exercicio12.Models
{
    // Entidade Event: só guarda os dados do evento
    public class Event
    {
        [Display(Name = "Título")]
        [Required(ErrorMessage = "Informe o título do evento.")]
        [StringLength(100, ErrorMessage = "O título pode ter no máximo 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Informe a data do evento.")]
        public DateTime? Data { get; set; }

        [Display(Name = "Local")]
        [Required(ErrorMessage = "Informe o local do evento.")]
        [StringLength(100, ErrorMessage = "O local pode ter no máximo 100 caracteres.")]
        public string Local { get; set; } = string.Empty;
    }
}