﻿using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JokesApp.Models
{
    public class Joke
    {
        public int id { get; set; }
        public string JokeQuestion { get; set; }
        public string JokeAnswer { get; set; }


    }
}
