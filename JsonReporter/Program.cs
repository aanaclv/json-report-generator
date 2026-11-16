using System;
using System.Collections.Generic;
using System.ComponentModel;
using JsonReporter.Domain.Entities;
using System.Text.Json;
using System.Linq;

namespace JsonReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new []
            {
                new {Title = "Clean Architecture", Author = "Robert C. Martin", Genre = "Tecnologia", PagesCount = 432, Rating = 4.8, IsRead = true},
                new {Title = "", Author = "Joel Grus", Genre = "Tecnologia", PagesCount = 12, Rating = 4.8, IsRead = true},
                new {Title = "Senhor dos anéis", Author = "T.K.K", Genre = "Fantasia", PagesCount = 12, Rating = 5.0, IsRead = false},
            };

            var validBooks = new List<Book>();
            var errorMessages = new List<string>();

            foreach (var data in books)
            {
                try
                {
                    var book = new Book(data.Title, data.Author, data.Genre, data.PagesCount, data.Rating, data.IsRead);
                    validBooks.Add(book);
                }
                catch (Exception ex)
                {
                    errorMessages.Add($"[Erro no Livro '{data.Title}']: {ex.Message}");
                }
            }

            Console.WriteLine("=== RELATÓRIO DE PROCESSAMENTO ===");
            Console.WriteLine($"Total de livros válidos: {validBooks.Count}");
            Console.WriteLine($"Total de erros encontrados: {errorMessages.Count}\n");

            if (validBooks.Count > 0)
            {
                Console.WriteLine("--- LIVROS OK ---");
                foreach (var book in validBooks)
                {
                    Console.WriteLine($"{book.Title} ({book.Author}) | Nota: {book.Rating}");
                }
                Console.WriteLine();
            }

            if (errorMessages.Count > 0)
            {
                Console.WriteLine("--- ERROS DETECTADOS ---");
                foreach (var error in errorMessages)
                {
                    Console.WriteLine(error);
                }
            }

            // Serialização
            string jsonString = JsonSerializer.Serialize(validBooks, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText("report.json", jsonString);
            Console.WriteLine("JSON salvo com sucesso!");

            // Leitura
            string jsonStringRead = System.IO.File.ReadAllText("report.json");
            Console.WriteLine("\n=== JSON LIDO ===");
            Console.WriteLine(jsonStringRead);

            // Desserialização
            var booksRecuperados = JsonSerializer.Deserialize<List<Book>>(jsonStringRead);

            if (booksRecuperados != null)
            {
                Console.WriteLine("\n=== OBJETOS RECUPERADOS ===");

                foreach (var book in booksRecuperados)
                {
                    Console.WriteLine($"{book.Title} - {book.Author}");
                }

                // LINQ
                int totalBooks = booksRecuperados.Count;
                Console.WriteLine($"\nTotal de livros recuperados: {totalBooks}");

                int livrosLidos = booksRecuperados.Count(b => b.IsRead);
                Console.WriteLine($"Total de livros lidos: {livrosLidos}");

                int naoLidos = booksRecuperados.Count(b => !b.IsRead);
                Console.WriteLine($"Total de livros não lidos: {naoLidos}");

                double mediaRating = booksRecuperados.Average(b => b.Rating);
                Console.WriteLine($"Média de avaliação dos livros: {mediaRating:F2}");

                var melhorLivro = booksRecuperados.OrderByDescending(b => b.Rating).FirstOrDefault();
                if (melhorLivro != null)
                {
                    Console.WriteLine($"Melhor livro: {melhorLivro.Title} | Nota: {melhorLivro.Rating}");
                }
                else
                {
                    Console.WriteLine("Nenhum livro encontrado.");
                }

                var porGenero = booksRecuperados.GroupBy(b => b.Genre)
                    .Select(g => new { Genre = g.Key, Count = g.Count() });

                foreach (var grupo in porGenero)
                {
                    Console.WriteLine($"Gênero: {grupo.Genre} | Total de livros: {grupo.Count}");
                }
                
                int totalPaginas = booksRecuperados.Sum(b => b.PagesCount);
                Console.WriteLine($"Total de páginas de todos os livros: {totalPaginas}");

                Console.WriteLine("\n=== RELATÓRIO ANALÍTICO ===");
                Console.WriteLine($"Total de livros: {totalBooks}");
                Console.WriteLine($"Total de livros lidos: {livrosLidos}");
                Console.WriteLine($"Total de livros não lidos: {naoLidos}");
                Console.WriteLine($"Média de avaliação dos livros: {mediaRating:F2}");
                Console.WriteLine($"Total de páginas de todos os livros: {totalPaginas}");
            }
        }
    }
}