using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public class SeriesService
    {

        public static bool AddSeries(User loggedUser, string name, string yearStr, string url, string genre, string desc, string actors, string producer)
        {
            DateTime year;
            UserService.IsAdmin(loggedUser);
            ValidateSeries(name, genre, producer, actors, yearStr);
            DateTime.TryParse(yearStr, out year);

            return DataAccessSeries.AddSeriesQuery(name, year, url, genre, desc, actors, producer);
        }
        public static bool EditSeries(User loggedUser, int id, string name, string yearStr, string url, string genre, string desc, string actors, string producer)
        {
            DateTime year;
            UserService.IsAdmin(loggedUser);
            ValidateSeries(name, genre, producer, actors, yearStr);
            DateTime.TryParse(yearStr, out year);

            return DataAccessSeries.EditSeriesQuery(id, name, year, url, genre, desc, actors, producer);
        }
        public static bool ValidateSeries(string name, string genre, string producer, string actors, string yearStr)
        {
            if (String.IsNullOrEmpty (name) || name.Length < 3)
            {
                throw new Exception("Name must be at least 3 characters long!");
            }
            else if (String.IsNullOrEmpty(genre))
            {
                throw new Exception("You must enter Genre");
            }
            else if (String.IsNullOrEmpty(producer))
            {
                throw new Exception("You must enter a producer");
            }
            else if (String.IsNullOrEmpty(actors))
            {
                throw new Exception("You must enter actors");
            }
            DateTime year;
            bool s = DateTime.TryParse(yearStr, out year);
            if (!s)
            {
                throw new Exception("Date not in correct format! Use YYYY-DD-MM");
            }
            else if (year == DateTime.MinValue)
            {
                throw new Exception("You must enter a date.");
            }
            return true;
        }
        public static List<Series> GetSeries(int offset)
        {
            return DataAccessSeries.GetSeriesQuery(offset);
        }
        public static List<Series> SearchSeries(string keyword)
        {
            return DataAccessSeries.SearchSeriesQuery(keyword.Trim());
        }
        public static Series GetSeriesById(int id)
        {
            return DataAccessSeries.GetSeriesByIdQuery(id);
        }

        public static bool DeleteSeries(User loggedUser, int id)
        {
            UserService.IsAdmin(loggedUser);
            return DataAccessSeries.DeleteSeriesQuery(id);
        }

        //FOR UNIT TESTING
        public static bool DeleteLastSeries(User loggedUser)
        {
            UserService.IsAdmin(loggedUser);
            return DataAccessSeries.DeleteLastSeriesQuery();

        }
        public static int GetLastSeriesId(User loggedUser)
        {
            UserService.IsAdmin(loggedUser);
            return DataAccessSeries.GetLastSeriesIdQuery();
        }
        //
    }
}
