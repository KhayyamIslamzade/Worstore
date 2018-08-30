using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worstore.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Worstore.AccessLayer.Entity
{
    public class Initializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DatabaseContext>();
            context.Database.EnsureCreated();
            if (!context.SpeekingLanguage.Any())
            {
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "zh", Label = "Chinese"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "es", Label = "Spanish" });
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "en", Label = "English" });
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "hi", Label = "Hindi"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "ar", Label = "Arabic"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "pt", Label = "Portuguese"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "ru", Label = "Russian"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "ja", Label = "Japanese"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "de", Label = "German"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "ko", Label = "Korean"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "fr", Label = "French"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "tr", Label = "Turkish"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "az", Label = "Azerbaijani"});
                context.SpeekingLanguage.Add(new SpokenLanguage() {Code = "nl", Label = "Dutch"});


                context.SaveChanges();
            }


        }
    }
}
