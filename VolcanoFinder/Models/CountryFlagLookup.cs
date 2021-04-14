using System.Collections.Generic;

namespace VolcanoFinder.Models
{
    public class CountryFlagLookup
    {

        public Dictionary<string, string> Countries { get; set; }

        public CountryFlagLookup()
        {
            Countries = new Dictionary<string, string>(){
                {"Russia", "ru"},
                {"Solomon Is.", "sb"},
                {"Ethiopia", "et"},
                {"Comoros","km" },
                {"Bolivia", "bo" },
                {"Canada", "ca" },
                {"Japan", "jp" },
                {"Argentina", "ar" },
                {"Philippines", "ph" },
                {"Italy", "it" },
                {"United States", "us" },
                {"Ecuador", "ec" },
                {"Madagascar", "mg" },
                {"Saudi Arabia", "sa" },
                {"Chile", "cl" },
                {"Indonesia", "id" },
                {"Guatemala", "gt" },
                {"El Salvador", "sv" },
                {"Jan Mayen", "sj" },
                {"Eritrea", "er" },
                {"Tanzania", "tz" },
                {"China", "cn" },
                {"Turkey", "tr" },
                {"Mexico", "mx" },
                {"New Zealand","nz" },
                {"Vanuatu", "vu" },
                {"Nicaragua", "ni" }
             };
        }
    }
}
