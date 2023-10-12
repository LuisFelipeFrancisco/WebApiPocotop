using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Proprietario
    {
        public int idProprietario { get; set; }
        [Required(ErrorMessage = "O nome do proprietário é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do proprietário deve conter no máximo 100 caracteres")]
        public string nomeProprietario { get; set; }
        [Required(ErrorMessage = "O email do proprietário é obrigatório")]
        [MaxLength(100, ErrorMessage = "O email do proprietário deve conter no máximo 100 caracteres")]
        public string emailProprietario { get; set; }
        [Required(ErrorMessage = "A data de nascimento do proprietário é obrigatória")]
        public DateTime dataNascimentoProprietario { get; set; }
        [Required(ErrorMessage = "O estado do proprietário é obrigatório")]
        [MaxLength(2, ErrorMessage = "O estado do proprietário deve conter no máximo 2 caracteres")]
        public string estadoProprietario { get; set; }
        [Required(ErrorMessage = "A cidade do proprietário é obrigatória")]
        [MaxLength(30, ErrorMessage = "A cidade do proprietário deve conter no máximo 30 caracteres")]
        public string cidadeProprietario { get; set; }
        [Required(ErrorMessage = "O bairro do proprietário é obrigatório")]
        [MaxLength(30, ErrorMessage = "O bairro do proprietário deve conter no máximo 30 caracteres")]
        public string bairroProprietario { get; set; }
        [Required(ErrorMessage = "A rua do proprietário é obrigatória")]
        [MaxLength(30, ErrorMessage = "A rua do proprietário deve conter no máximo 30 caracteres")]
        public string ruaProprietario { get; set; }
        [Required(ErrorMessage = "O número do proprietário é obrigatório")]
        [MaxLength(10, ErrorMessage = "O número do proprietário deve conter no máximo 10 caracteres")]
        public string numeroProprietario { get; set; }
        [MaxLength(30, ErrorMessage = "O complemento do proprietário deve conter no máximo 30 caracteres")]
        public string complementoProprietario { get; set; }
        [Required(ErrorMessage = "O telefone do proprietário é obrigatório")]
        [MaxLength(15, ErrorMessage = "O telefone do proprietário deve conter no máximo 15 caracteres")]
        public string telefoneProprietario { get; set; }
        [Required(ErrorMessage = "O CPF/CNPJ do proprietário é obrigatório")]
        [MaxLength(20, ErrorMessage = "O CPF/CNPJ do proprietário deve conter no máximo 20 caracteres")]
        public string cpfcnpjProprietario { get; set; }
        [Required(ErrorMessage = "A data de cadastro do proprietário é obrigatória")]
        public DateTime dataCadastroProprietario { get; set; }
        
        public Proprietario()
        {
            this.idProprietario = 0;
            this.nomeProprietario = "";
            this.emailProprietario = "";
            this.dataNascimentoProprietario = DateTime.Now;
            this.estadoProprietario = "";
            this.cidadeProprietario = "";
            this.bairroProprietario = "";
            this.ruaProprietario = "";
            this.numeroProprietario = "";
            this.complementoProprietario = "";
            this.telefoneProprietario = "";
            this.cpfcnpjProprietario = "";
            this.dataCadastroProprietario = DateTime.Now;
        }
    }
}
