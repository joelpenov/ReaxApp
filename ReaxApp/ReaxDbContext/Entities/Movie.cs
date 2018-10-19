using System;
using ReaxApp.ReaxDbContext.Entities.Enums;

namespace ReaxApp.ReaxDbContext.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string OriginalId { get; set; }
        public int Year { get; set; }
        public string Released { get; set; }
        public int Runtime { get; set; }
        public string Rated { get; set; }
        public double? Rating { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string ImdbId { get; set; }
        public string CovertImage { get; set; }
        public string FullImage { get; set; }
        public string Trailer { get; set; }
        public string Actors { get; set; }
        public DateTime DateUpdate { get; set; }
        public string UserCreate { get; set; }
        public string UserUpdate { get; set; }
        public string SynopsisEnglish { get; set; }
        public string Categories { get; set; }
        public bool OnlyEnglish { get; set; }
        public bool MonoAudio { get; set; }
        public bool AudioSpanish { get; set; }
        public bool AudioEnglish { get; set; }
        public string MailOrigin { get; set; }
        public int Views { get; set; }
        public bool HasOscar { get; set; }
        public bool IsPremiere { get; set; }
        public string Genres { get; set; }
        public string Link { get; set; }
        public string Quality { get; set; }
        public bool SubtitleEnglish { get; set; }
        public bool SubtitleSpanish { get; set; }
        public MediaTypes MediaType { get; set; }
    }
}
