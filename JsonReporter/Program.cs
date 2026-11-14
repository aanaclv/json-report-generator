using System;
using System.Collections.Generic;
using System.ComponentModel;
using JsonReporter.Domain.Entities;

namespace JsonReportGenerator{

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
                    Console.WriteLine($"- {book.Title} ({book.Author}) | Nota: {book.Rating}");
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
    }
}
}