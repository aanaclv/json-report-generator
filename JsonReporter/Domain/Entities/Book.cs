using System.ComponentModel.DataAnnotations;
using JsonReporter.Domain.Common;

namespace JsonReporter.Domain.Entities{
public sealed class Book : BaseEntity
{
    public string Title {get; set; }
    public string Author {get; set; }
    public string Genre {get; set; }
    public int PagesCount {get; set; }
    public double Rating {get; set; }
    public bool IsRead {get; set; }
    
    
    public Book(string title, string author, string genre, int pagescount, double rating, bool isread)
        {
            ValidateDomain(title, author, genre, pagescount, rating, isread);
            Title = title;
            Author = author;
            Genre = genre;
            PagesCount = pagescount;
            Rating = rating;
            IsRead = isread;
        }
        
    public void ValidateDomain(string title, string author, string genre, int pagescount, double rating, bool isread)
        {
            if (string.IsNullOrEmpty(title))
            throw new ValidationException("O título não pode ser nulo ou vazio.");

            if (string.IsNullOrEmpty(author))
                throw new ValidationException("O autor não pode ser nulo ou vazio.");

            if (string.IsNullOrEmpty(genre))
                throw new ValidationException("O gênero não pode ser nulo ou vazio.");

            if (pagescount <= 0)
                throw new ValidationException("O número de páginas deve ser maior que zero.");

            if (rating < 0 || rating > 5)
            throw new ValidationException("A avaliação deve estar entre 0 e 5.");

            if (!isread && rating > 0)
            throw new ValidationException("Livros que ainda não foram lidos não podem possuir avaliação.");
        }

    }
}