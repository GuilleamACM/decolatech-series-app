using System;
using Series.Enums;

namespace Series.Classes
{
    public class TvSeries : BaseEntity
    {
        public Genre Genre { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public string Description { get; private set; }
        public bool Deleted { get; private set; }

        public TvSeries(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            var result = "";
            result += "Gênero: " + this.Genre + Environment.NewLine;
            result += "Título: " + this.Title + Environment.NewLine;
            result += "Descrição: " + this.Description + Environment.NewLine;
            result += "Ano de Lançamento: " + this.Year + Environment.NewLine;
            return result;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
    }
}