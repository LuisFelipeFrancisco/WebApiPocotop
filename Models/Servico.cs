using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Servico
    {
        public int idServico { get; set; }
        [Required(ErrorMessage = "O nome do serviço é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome do serviço deve conter no máximo 50 caracteres")]
        public string nomeServico { get; set; }
        [Required(ErrorMessage = "O valor do serviço é obrigatório")]
        [Range(0, 9999999999.99, ErrorMessage = "O valor do serviço deve ser menor que 9999999999.99")]
        public decimal valorServico { get; set; }
        [MaxLength(100, ErrorMessage = "As observações do serviço deve conter no máximo 100 caracteres")]
        public string observacoesServico { get; set; }
        [Required(ErrorMessage = "A data de cadastro do serviço é obrigatória")]
        public DateTime dataCadastroServico { get; set; }
        

        public Servico()
        {
            this.idServico = 0;
            this.nomeServico = "";
            this.valorServico = 0;
            this.observacoesServico = "";
            this.dataCadastroServico = DateTime.Now;
        }
    }
}
