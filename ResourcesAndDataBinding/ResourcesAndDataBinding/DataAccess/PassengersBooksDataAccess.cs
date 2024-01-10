using ResourcesAndDataBinding.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace ResourcesAndDataBinding.DataAccess
{
    public class PassengersBooksDataAccess
    {
        public static SQLiteConnection Database;
        private static object collisionLock = new object();

        public PassengersBooksDataAccess()
        {
            Database = new SQLiteConnection(DataAccessHelper.DatabasePath);
            Database.CreateTable<PassengersBook>();
        }

        public List<PassengersBook> Paid()
        {
            lock (collisionLock)
            {
                var contacts = Database.Table<PassengersBook>();
                var result = contacts.Where(c => c.IsPaid).ToList();
                return result;
            }
        }

        public void AddPassengersBook(PassengersBook Book)
        {
            lock (collisionLock)
            {
                Database.Insert(Book);
            }
        }

        public void DeletePassengersBook(PassengersBook Book)
        {
            lock (collisionLock)
            {
                Database.Delete(Book);
            }
        }

        public void EditPassengersBook(PassengersBook Book)
        {
            lock (collisionLock)
            {
                Database.Update(Book);
            }
        }

        public void SaveAll(IEnumerable<PassengersBook> Books)
        {
            lock (collisionLock)
            {
                var existingPassengersBooks = Books.Where(c => c.PassengersBookID != 0);
                var newPassengersBooks = Books.Where(c => c.PassengersBookID == 0);

                Database.UpdateAll(existingPassengersBooks);
                Database.InsertAll(newPassengersBooks);
            }
        }
    }
}
