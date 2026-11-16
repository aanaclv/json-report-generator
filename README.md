# ˚˖𓍢ִ໋❀ JSON Report Generator (.NET) 𝜗𝜚˚⋆

Projeto desenvolvido em **C# / .NET** com o objetivo de servir como base de apoio e estudo para fluxos de validação de regras de negócio, tratamento de exceções, serialização/desserialização de dados em JSON e consultas analíticas utilizando **LINQ**.

---

## ʚɞ Funcionalidades e Fluxo do Projeto

O fluxo da aplicação simula um pipeline de processamento de dados robusto:
1. **Entrada de Dados:** Recebe uma lista de objetos brutos (neste exemplo, livros).
2. **Criação de Entidades:** Tenta instanciar os objetos aplicando validações de domínio no construtor.
3. **Tratamento de Falhas (Resiliência):** Captura exceções de validação de negócio sem interromper o fluxo total do lote, armazenando os erros separadamente.
4. **Serialização JSON:** Converte apenas os objetos que passaram pelas regras de validação em uma string JSON formatada (`Indented`) e a salva em disco (`report.json`).
5. **Desserialização e Leitura:** Lê o arquivo JSON gerado de volta para o sistema.
6. **Relatório Analítico via LINQ:** Processa os dados recuperados extraindo estatísticas (totais, contadores condicionais, médias, ordenações e agrupamentos por categoria).

---

## ʚɞ Tecnologias Utilizadas

* **.NET (C#)**
* **System.Text.Json** (Serialização e desserialização nativa)
* **LINQ** (Consultas, agregações e manipulação de coleções)

---

## ʚɞ Estrutura de Pastas (Base)

```text
json-report-generator/
│
├── JsonReporter/
│   ├── Domain/
│   │   └── Entities/          # Entidades de Domínio e Regras de Negócio
│   ├── Program.cs             # Fluxo principal, tratamento de erros e relatórios
│   └── JsonReporter.csproj    # Arquivo de configuração do projeto C#
│
└── README.md                  # Documentação do projeto
```

---

## ✦ Como Executar o Projeto

Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/) instalado em sua máquina.

1. Abra o terminal (PowerShell ou CMD) e navegue até o diretório do projeto:
   ```bash
   cd JsonReporter
   ```
2. Execute o comando de compilação e execução:
   ```bash
   dotnet run
   ```
