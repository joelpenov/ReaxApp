using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using ReaxApp.ReaxDbContext.Entities;
using ReaxApp.ReaxDbContext.Entities.Enums;

namespace ReaxApp.SampleData
{
    class SampleDataBuilder
    {
        public List<Movie> GetSampleData()
        {
            var fileDirectory = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\" + @"SampleData\movies.json";
            var fakeId = -1000000;
            var mediaData = new List<Movie>();
            using (var r = new StreamReader(fileDirectory))
            {
                var json = r.ReadToEnd();

                dynamic fileDeserializedObject = JsonConvert.DeserializeObject(json);
                foreach (var line in fileDeserializedObject)
                {
                    Movie currentMovie;
                    try
                    {
                        var content = line.content[0];
                        currentMovie = new Movie()
                        {
                            Id = ++fakeId,
                            MediaType = MediaTypes.Movie,
                            OriginalId = line._id,
                            Title = line.title,
                            Year = line.year,
                            Released = line.released,
                            Runtime = line.runtime,
                            Rated = line.rated,
                            Rating = line.rating,
                            Synopsis = line.synopsis,
                            SynopsisEnglish = line.synopsisEng,
                            ImdbId = line.imdbId,
                            CovertImage = line.covertImage,
                            FullImage = line.fullImage,
                            Trailer = line.trailer,
                            Actors = line.actors,
                            DateUpdate = Convert.ToDateTime(line.dateUpdate),
                            Categories = string.Join(", ", line.categories),
                            Link = content.link,
                            Quality = content.quality,
                            HasOscar = line.hasOscar,
                            IsPremiere = line.isPremiere,
                            Genres = string.Join(", ", line.genres),
                            Views = line.view,
                            UserCreate = line.userCreate,
                            UserUpdate = line.userUpdate,
                            OnlyEnglish = line.onlyEnglish,
                            MonoAudio = line.monoAudio,
                            SubtitleSpanish = content.subtitleSpa,
                            SubtitleEnglish = content.subtitleEng,
                            AudioSpanish = line.audioSpa,
                            AudioEnglish = line.audioEng,
                            MailOrigin = line.mailOrigin
                        };
                        mediaData.Add(currentMovie);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
            }

            return mediaData;

        }
    }
}

