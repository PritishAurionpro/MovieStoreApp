﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary
{
    public class NoMovieFoundException:Exception
    {
        public NoMovieFoundException(string message) : base(message) { }
    }
}
