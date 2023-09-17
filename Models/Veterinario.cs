using System;

/* 
idVeterinario int IDENTITY(1,1) PRIMARY KEY,
nomeVeterinario varchar(100) NOT NULL,
emailVeterinario varchar(100) NOT NULL,
senhaVeterinario varchar(100) NOT NULL,
estadoVeterinario varchar(100) NOT NULL,
cidadeVeterinario varchar(100) NOT NULL,
bairroVeterinario varchar(100) NOT NULL,
ruaVeterinario varchar(100) NOT NULL,
numeroVeterinario varchar(100) NOT NULL,
complementoVeterinario varchar(100) NULL,
telefoneVeterinario varchar(100) NOT NULL,
crmvVeterinario varchar(100) NOT NULL,
dataCadastroVeterinario date NOT NULL
*/
namespace Models
{
    public class Veterinario
    {
        // TODO: DATAANNOTATIONS
        public int idVeterinario { get; set; }
        public string nomeVeterinario { get; set; }
        public string emailVeterinario { get; set; }
        public string senhaVeterinario { get; set; }
        public string estadoVeterinario { get; set; }
        public string cidadeVeterinario { get; set; }
        public string bairroVeterinario { get; set; }
        public string ruaVeterinario { get; set; }
        public string numeroVeterinario { get; set; }
        public string complementoVeterinario { get; set; }
        public string telefoneVeterinario { get; set; }
        public string crmvVeterinario { get; set; }
        public DateTime dataCadastroVeterinario { get; set; }

        public Veterinario()
        {
            this.idVeterinario = 0;
            this.nomeVeterinario = "";
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
