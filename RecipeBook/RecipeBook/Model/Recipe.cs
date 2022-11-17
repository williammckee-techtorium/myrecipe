﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBook.Model
{
    internal class Recipe
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }
    }
}
