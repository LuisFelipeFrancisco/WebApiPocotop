using System;

/* 
idProprietario int IDENTITY(1,1) PRIMARY KEY,
nomeProprietario varchar(100) NOT NULL,
emailProprietario varchar(100) NOT NULL,
estadoProprietario varchar(100) NOT NULL,
cidadeProprietario varchar(100) NOT NULL,
bairroProprietario varchar(100) NOT NULL,
ruaProprietario varchar(100) NOT NULL,
numeroProprietario varchar(100) NOT NULL,
complementoProprietario varchar(100) NULL,
telefoneProprietario varchar(100) NOT NULL,
cpfcnpjProprietario varchar(100) NOT NULL,
dataCadastroProprietario datetime NOT NULL
 */

namespace Models
{
    public class Proprietario
    {
        public int idProprietario { get; set; }
        public string nomeProprietario { get; set; }
        public string emailProprietario { get; set; }
        public string estadoProprietario { get; set; }
        public string cidadeProprietario { get; set; }
        public string bairroProprietario { get; set; }
        public string ruaProprietario { get; set; }
        public string numeroProprietario { get; set; }
        public string complementoProprietario { get; set; }
        public string telefoneProprietario { get; set; }
        public string cpfcnpjProprietario { get; set; }
        public DateTime dataCadastroProprietario { get; set; }

        public Proprietario()
        {
            this.idProprietario = 0;
            this.nomeProprietario = "";
            this.emailProprietario = "";
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
