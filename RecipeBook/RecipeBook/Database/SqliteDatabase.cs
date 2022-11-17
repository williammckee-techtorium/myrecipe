using RecipeBook.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;


namespace RecipeBook.Database
{
    internal class SqliteDatabase
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Recipebook.db");
            db = new SQLiteAsyncConnection(databasePath);


             await db.CreateTableAsync<User>();
             await db.CreateTableAsync<Recipe>();
        }
        public static async Task<List<Recipe>> GetRecipesAsync()
        {
            await Init();
            var recipes = await db.Table<Recipe>().ToListAsync();
            return recipes;
        }
        public static async Task<int> SaveRecipeAsync(Recipe recipe)
        {
            await Init();
            return await db.InsertAsync(recipe);
        }
        public static async Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            await Init();
            return await db.DeleteAsync(recipe);
        }
        public static async Task<int> SaveUserAsync(User user)
        {
            await Init();
            var result= await GetUserByUserNameAsync(user.Username,user.Password);
            if (result == null)
            {
                return await db.InsertAsync(user);
            }
            return -1;
        }

        public static async Task<User> GetUserByUserNameAsync(string username,string password)
        {
            await Init();
            var user = await db.Table<User>().FirstOrDefaultAsync(u=>u.Username == username);
            return user;
        }
        public static async Task<User> LoginAsync(string username, string password)
        {
            await Init();
            var user = await db.Table<User>().FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            return user;
        }
    }
}
