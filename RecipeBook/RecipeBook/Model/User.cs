using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBook.Model
{
    internal class User
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
    }
}
