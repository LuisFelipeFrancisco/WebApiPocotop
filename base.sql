-- Proprietários
-- Nome do Proprietário - Nome do proprietário
-- Email do Proprietário - Email do proprietário
-- Estado - Estado do proprietário
--     Cidade - Cidade do proprietário
--     Bairro - Bairro do proprietário
--     Rua - Rua do proprietário
--     Número - Número da casa do proprietário
--     Complemento - Complemento do endereço do proprietário
-- Telefone - Telefone do proprietário
-- CPF/CNPJ - CPF ou CNPJ do proprietário
-- Data do Cadastro - Data do cadastro do proprietário

-- Animal
-- Foto do animal - Adicionar foto do animal *Adicionar
-- Proprietário - Selecione o proprietário deste animal
-- Nome do Animal - Nome do animal para melhor identifica-lo
-- Sexo do animal - Sexo deste animal
-- Registro - Registro deste animal
-- Data de nascimento - Data de nascimento para calculo da idade
-- Raça - Indica a raça deste animal
-- Pelagem - Descreve o tipo de pelagem do animal
-- Temperamento do Animal - Indica o tipo de temperamento deste animal
-- Observações - Observações sobre este animal
-- Data do Cadastro - Data do cadastro deste animal

-- Veterinário
-- Nome do Veterinário - Nome do veterinário
-- Foto do Veterinário - Adicionar foto do veterinário *Adicionar
-- Email do Veterinário - Email do veterinário
-- Senha do Veterinário - Senha do veterinário
-- Estado - Estado do veterinário
--     Cidade - Cidade do veterinário
--     Bairro - Bairro do veterinário
--     Rua - Rua do veterinário
--     Número - Número da casa do veterinário
--     Complemento - Complemento do endereço do veterinário
-- Telefone - Telefone do veterinário
-- CRMV - CRMV do veterinário
-- Data do Cadastro - Data do cadastro do veterinário


-- Serviços
-- Nome do Serviço - Nome do serviço
-- Valor do Serviço - Valor do serviço
-- Observações - Observações sobre este serviço
-- Data do Cadastro - Data do cadastro deste serviço

-- Agendamento
-- - Selecione o proprietário deste animal
-- Animal -  ProprietárioSelecione o animal deste agendamento
-- Serviço - Selecione o serviço deste agendamento
-- Data do Agendamento - Data do agendamento
-- Hora do Agendamento - Hora do agendamento
-- Observações - Observações sobre este agendamento
-- Data do Cadastro - Data do cadastro deste agendamento

-- DATABASE USANDO SQLSERVER

CREATE DATABASE pocotop;

use pocotop;

CREATE TABLE Proprietario (
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
);

CREATE TABLE Animal (
    idAnimal int IDENTITY(1,1) PRIMARY KEY,
    idProprietario int NOT NULL,
    fotoAnimal varchar(100) NULL,
    nomeAnimal varchar(100) NOT NULL,
    sexoAnimal varchar(100) NOT NULL,
    registroAnimal varchar(100) NOT NULL,
    dataNascimentoAnimal datetime NOT NULL,
    racaAnimal varchar(100) NOT NULL,
    pelagemAnimal varchar(100) NULL,
    temperamentoAnimal varchar(100) NULL,
    observacoesAnimal varchar(100) NULL,
    dataCadastroAnimal datetime NOT NULL,
    CONSTRAINT FK_Proprietario_Animal FOREIGN KEY (idProprietario) REFERENCES Proprietario(idProprietario)
);

CREATE TABLE Veterinario (
    idVeterinario int IDENTITY(1,1) PRIMARY KEY,
    nomeVeterinario varchar(100) NOT NULL,
    fotoVeterinario varchar(100) NULL,
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
    dataCadastroVeterinario datetime NOT NULL
);

CREATE TABLE Servico (
    idServico int IDENTITY(1,1) PRIMARY KEY,
    nomeServico varchar(100) NOT NULL,
    valorServico varchar(100) NOT NULL,
    observacoesServico varchar(100) NULL,
    dataCadastroServico datetime NOT NULL
);

CREATE TABLE Agendamento (
    idAgendamento int IDENTITY(1,1) PRIMARY KEY,
    idProprietario int NOT NULL,
    idAnimal int NOT NULL,
    idServico int NOT NULL,
    idVeterinario int NOT NULL,
    dataAgendamento datetime NOT NULL,
    horaAgendamento datetime NOT NULL,
    observacoesAgendamento varchar(100) NULL,
    dataCadastroAgendamento datetime NOT NULL,
    CONSTRAINT FK_Proprietario_Agendamento FOREIGN KEY (idProprietario) REFERENCES Proprietario(idProprietario),
    CONSTRAINT FK_Veterinario_Agendamento FOREIGN KEY (idVeterinario) REFERENCES Veterinario(idVeterinario),
    CONSTRAINT FK_Animal_Agendamento FOREIGN KEY (idAnimal) REFERENCES Animal(idAnimal),
    CONSTRAINT FK_Servico_Agendamento FOREIGN KEY (idServico) REFERENCES Servico(idServico)
);