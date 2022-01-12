using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms.PlatformConfiguration;

namespace PicListExp.Models
{
    public class LandmarkDB
    {
        

       

        readonly SQLiteAsyncConnection _database;
        public LandmarkDB(string connectionString)
        {
            try
            {
                _database = new SQLiteAsyncConnection(connectionString);
                _database.CreateTableAsync<Landmark>().Wait();
                Console.WriteLine("===================Database open!!!============================");
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Task<List<Landmark>> GetLandmarksAsync()
        {
            return _database.Table<Landmark>().ToListAsync();
        }

        public Task<Landmark> GetLandmarkAsync(int id)
        {
            return _database.Table<Landmark>().Where(item=>item.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveLandmark(Landmark data)
        {
            if(data.Id != 0)
            {
                return _database.UpdateAsync(data);
            }
            else
            {
                return _database.InsertAsync(data);
            }
            
        }
        public async Task<int> DeleteLandmarkAsync(int id)
        {
            return await _database.DeleteAsync(id);
        }
    }
}
