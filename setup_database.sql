-- Criar tabelas
CREATE TABLE IF NOT EXISTS Competencias (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Categoria VARCHAR(100),
    Descricao TEXT
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS Trilhas (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL,
    Descricao TEXT,
    Nivel VARCHAR(50) NOT NULL,
    CargaHoraria INT NOT NULL,
    FocoPrincipal VARCHAR(100)
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS Usuarios (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE,
    AreaAtuacao VARCHAR(100),
    NivelCarreira VARCHAR(50),
    DataCadastro DATETIME(6) NOT NULL
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS TrilhaCompetencias (
    TrilhaId BIGINT NOT NULL,
    CompetenciaId BIGINT NOT NULL,
    PRIMARY KEY (TrilhaId, CompetenciaId),
    FOREIGN KEY (TrilhaId) REFERENCES Trilhas(Id) ON DELETE CASCADE,
    FOREIGN KEY (CompetenciaId) REFERENCES Competencias(Id) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS Matriculas (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    UsuarioId BIGINT NOT NULL,
    TrilhaId BIGINT NOT NULL,
    DataInscricao DATETIME(6) NOT NULL,
    Status VARCHAR(50) NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE,
    FOREIGN KEY (TrilhaId) REFERENCES Trilhas(Id) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

-- Inserir dados iniciais - Competências
INSERT INTO Competencias (Id, Nome, Categoria, Descricao) VALUES
(1, 'Inteligência Artificial', 'Tecnologia', 'Machine Learning, Deep Learning, IA Generativa'),
(2, 'Análise de Dados', 'Tecnologia', 'Big Data, Analytics, Data Science'),
(3, 'Cloud Computing', 'Tecnologia', 'AWS, Azure, GCP'),
(4, 'Empatia e Inteligência Emocional', 'Humana', 'Soft Skills essenciais para liderança'),
(5, 'Colaboração Digital', 'Humana', 'Trabalho remoto e híbrido'),
(6, 'Sustentabilidade e Green Tech', 'Tecnologia', 'Tecnologias verdes e sustentáveis');

-- Inserir dados iniciais - Trilhas
INSERT INTO Trilhas (Id, Nome, Descricao, Nivel, CargaHoraria, FocoPrincipal) VALUES
(1, 'IA para Iniciantes', 'Introdução à Inteligência Artificial', 'INICIANTE', 40, 'IA'),
(2, 'Cientista de Dados Completo', 'Trilha completa de Data Science', 'INTERMEDIARIO', 120, 'Dados'),
(3, 'Liderança Digital', 'Soft Skills para líderes do futuro', 'AVANCADO', 60, 'Soft Skills'),
(4, 'Cloud Architecture', 'Arquitetura de soluções em nuvem', 'AVANCADO', 80, 'Cloud');

-- Inserir dados iniciais - Usuários
INSERT INTO Usuarios (Id, Nome, Email, AreaAtuacao, NivelCarreira, DataCadastro) VALUES
(1, 'Maria Silva', 'maria.silva@email.com', 'Tecnologia', 'Junior', '2025-01-15 00:00:00'),
(2, 'João Santos', 'joao.santos@email.com', 'Gestão', 'Pleno', '2025-02-20 00:00:00');

-- Inserir dados iniciais - TrilhaCompetencias
INSERT INTO TrilhaCompetencias (TrilhaId, CompetenciaId) VALUES
(1, 1),
(2, 2),
(2, 1),
(3, 4),
(3, 5),
(4, 3);

-- Inserir dados iniciais - Matrículas
INSERT INTO Matriculas (Id, UsuarioId, TrilhaId, DataInscricao, Status) VALUES
(1, 1, 1, '2025-03-01 00:00:00', 'ATIVA'),
(2, 2, 3, '2025-03-10 00:00:00', 'ATIVA');
