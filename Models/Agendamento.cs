using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Agendamento
    {
        public int idAgendamento { get; set; }
        [Required(ErrorMessage = "O campo idProprietario é obrigatório.")]
        public int idProprietario { get; set; }
        [Required(ErrorMessage = "O campo idAnimal é obrigatório.")]
        public int idAnimal { get; set; }
        [Required(ErrorMessage = "O campo idServico é obrigatório.")]
        public int idServico { get; set; }
        [Required(ErrorMessage = "O campo idVeterinario é obrigatório.")]
        public int idVeterinario { get; set; }
        [Required(ErrorMessage = "O campo dataAgendamento é obrigatório.")]
        public DateTime dataAgendamento { get; set; }
        [Required(ErrorMessage = "O campo horaAgendamento é obrigatório.")]
        public TimeSpan horaAgendamento { get; set; }
        [MaxLength(100, ErrorMessage = "O campo observacoesAgendamento não pode ter mais que 100 caracteres.")]
        public string observacoesAgendamento { get; set; }
        [Required(ErrorMessage = "O campo dataCadastroAgendamento é obrigatório.")]
        public DateTime dataCadastroAgendamento { get; set; }
        

        public Agendamento()
        {
            this.idAgendamento = 0;
            this.idProprietario = 0;
            this.idAnimal = 0;
            this.idServico = 0;
            this.idVeterinario = 0;
            this.dataAgendamento = DateTime.Now;
            this.horaAgendamento = TimeSpan.Zero;
            this.observacoesAgendamento = "";
            this.dataCadastroAgendamento = DateTime.Now;
        }
    }
}
