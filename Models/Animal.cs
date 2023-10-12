using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Animal
    {
        public int idAnimal { get; set; }
        [Required(ErrorMessage = "O proprietário é obrigatório")]
        public int idProprietario { get; set; }
        [MaxLength(100, ErrorMessage = "A foto do animal deve conter no máximo 100 caracteres")]
        public string fotoAnimal { get; set; }
        [Required(ErrorMessage = "O nome do animal é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do animal deve conter no máximo 100 caracteres")]
        public string nomeAnimal { get; set; }
        [Required(ErrorMessage = "O sexo do animal é obrigatório")]
        [MaxLength(1, ErrorMessage = "O sexo do animal deve conter no máximo 1 caractere")]
        public string sexoAnimal { get; set; }
        [MaxLength(20, ErrorMessage = "O registro do animal deve conter no máximo 20 caracteres")]
        public string registroAnimal { get; set; }
        [Required(ErrorMessage = "A data de nascimento do animal é obrigatória")]
        public DateTime dataNascimentoAnimal { get; set; }
        [Required(ErrorMessage = "A raça do animal é obrigatória")]
        [MaxLength(50, ErrorMessage = "A raça do animal deve conter no máximo 50 caracteres")]
        public string racaAnimal { get; set; }
        [MaxLength(50, ErrorMessage = "A pelagem do animal deve conter no máximo 50 caracteres")]
        public string pelagemAnimal { get; set; }
        [MaxLength(50, ErrorMessage = "O temperamento do animal deve conter no máximo 50 caracteres")]
        public string temperamentoAnimal { get; set; }
        [MaxLength(100, ErrorMessage = "As observações do animal deve conter no máximo 100 caracteres")]
        public string observacoesAnimal { get; set; }
        [Required(ErrorMessage = "A data de cadastro do animal é obrigatória")]
        public DateTime dataCadastroAnimal { get; set; }

        
        public Animal()
        {
            this.idAnimal = 0;
            this.idProprietario = 0;
            this.fotoAnimal = "";
            this.nomeAnimal = "";
            this.sexoAnimal = "";
            this.registroAnimal = "";
            this.dataNascimentoAnimal = DateTime.Now;
            this.racaAnimal = "";
            this.pelagemAnimal = "";
            this.temperamentoAnimal = "";
            this.observacoesAnimal = "";
            this.dataCadastroAnimal = DateTime.Now;
        }
    }
}
