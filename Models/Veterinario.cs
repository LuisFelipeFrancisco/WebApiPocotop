using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Veterinario
    {
        public int idVeterinario { get; set; }
        [Required(ErrorMessage = "O nome do veterinário é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do veterinário somente pode ter no máximo 100 caracteres")]
        public string nomeVeterinario { get; set; }
        [Required(ErrorMessage = "A data de nascimento do veterinário é obrigatória")]
        public DateTime dataNascimentoVeterinario { get; set; }
        [MaxLength(100, ErrorMessage = "A foto do veterinário somente pode ter no máximo 100 caracteres")]
        public string fotoVeterinario { get; set; }
        [Required(ErrorMessage = "O email do veterinário é obrigatório")]
        [MaxLength(100, ErrorMessage = "O email do veterinário somente pode ter no máximo 100 caracteres")]
        public string emailVeterinario { get; set; }
        [Required(ErrorMessage = "A senha do veterinário é obrigatória")]
        [MaxLength(100, ErrorMessage = "A senha do veterinário somente pode ter no máximo 100 caracteres")]
        public string senhaVeterinario { get; set; }
        [Required(ErrorMessage = "O estado do veterinário é obrigatório")]
        [MaxLength(2, ErrorMessage = "O estado do veterinário somente pode ter no máximo 2 caracteres")]
        public string estadoVeterinario { get; set; }
        [Required(ErrorMessage = "A cidade do veterinário é obrigatória")]
        [MaxLength(30, ErrorMessage = "A cidade do veterinário somente pode ter no máximo 30 caracteres")]
        public string cidadeVeterinario { get; set; }
        [Required(ErrorMessage = "O bairro do veterinário é obrigatório")]
        [MaxLength(30, ErrorMessage = "O bairro do veterinário somente pode ter no máximo 30 caracteres")]
        public string bairroVeterinario { get; set; }
        [Required(ErrorMessage = "A rua do veterinário é obrigatória")]
        [MaxLength(30, ErrorMessage = "A rua do veterinário somente pode ter no máximo 30 caracteres")]
        public string ruaVeterinario { get; set; }
        [Required(ErrorMessage = "O número do veterinário é obrigatório")]
        [MaxLength(10, ErrorMessage = "O número do veterinário somente pode ter no máximo 10 caracteres")]
        public string numeroVeterinario { get; set; }
        [MaxLength(30, ErrorMessage = "O complemento somente pode ter no máximo 30 caracteres")]
        public string complementoVeterinario { get; set; }
        [Required(ErrorMessage = "O telefone do veterinário é obrigatório")]
        [MaxLength(15, ErrorMessage = "O telefone do veterinário somente pode ter no máximo 15 caracteres")]
        public string telefoneVeterinario { get; set; }
        [Required(ErrorMessage = "O CRMV do veterinário é obrigatório")]
        [MaxLength(10, ErrorMessage = "O CRMV do veterinário somente pode ter no máximo 10 caracteres")]
        public string crmvVeterinario { get; set; }
        [Required(ErrorMessage = "A data de cadastro do veterinário é obrigatória")]
        public DateTime dataCadastroVeterinario { get; set; }

        public Veterinario()
        {
            this.idVeterinario = 0;
            this.nomeVeterinario = "";
            this.dataNascimentoVeterinario = DateTime.Now;
            this.fotoVeterinario = "";
            this.emailVeterinario = "";
            this.senhaVeterinario = "";
            this.estadoVeterinario = "";
            this.cidadeVeterinario = "";
            this.bairroVeterinario = "";
            this.ruaVeterinario = "";
            this.numeroVeterinario = "";
            this.complementoVeterinario = "";
            this.telefoneVeterinario = "";
            this.crmvVeterinario = "";
            this.dataCadastroVeterinario = DateTime.Now;
        }

    }

}
