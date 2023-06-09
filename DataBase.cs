using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using System.Data;
using WebApiWeatherBot.Models;

namespace WebApiWeatherBot
{
    public class DataBase
    {
        NpgsqlConnection connection = new NpgsqlConnection(Constants.Connect);
        public async Task InsertCityWeatherAsync(CityWeather cityWeather, string CityName)
        {
            var sql = "insert into public.\"CityWeather\"(\"CityName\", \"Temp\", \"Time\", \"Visibility\", \"SpeedWind\", \"GustWind\", \"Pressure\", \"Humidity\", \"Country\")"
                + $"values (@CityName, @Temp, @Time,@Visibility, @SpeedWind, @GustWind, @Pressure, @Humidity, @Country)";


            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("CityName", CityName);
            command.Parameters.AddWithValue("Temp", cityWeather.Main.Temp);
            command.Parameters.AddWithValue("Time", DateTime.Now);
            command.Parameters.AddWithValue("Visibility", cityWeather.Visibility);
            command.Parameters.AddWithValue("SpeedWind", cityWeather.Wind.Speed);
            command.Parameters.AddWithValue("Humidity", cityWeather.Main.Humidity);
            command.Parameters.AddWithValue("Pressure", cityWeather.Main.Pressure);
            command.Parameters.AddWithValue("GustWind", cityWeather.Wind.Gust);
            command.Parameters.AddWithValue("Country", cityWeather.Sys.Country);
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
            await connection.CloseAsync();
        }
        public async Task<List<CityMain>> SelectStatistic()
        {
            List<CityMain> cityMains = new List<CityMain>();
            await connection.OpenAsync();
            var sql = "select \"CityName\", \"Temp\", \"Time\", \"SpeedWind\",\"Visibility\", \"GustWind\", \"Pressure\", \"Humidity\", \"Country\" from public.\"CityWeather\"";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader npgsqlDataReader = await command.ExecuteReaderAsync();
            while (await npgsqlDataReader.ReadAsync())
            {
                cityMains.Add(new CityMain(npgsqlDataReader.GetString(0), npgsqlDataReader.GetDouble(1), npgsqlDataReader.GetDateTime(2), npgsqlDataReader.GetDouble(3), npgsqlDataReader.GetDouble(4), npgsqlDataReader.GetDouble(5), npgsqlDataReader.GetDouble(6), npgsqlDataReader.GetString(7)));
            }
            await connection.CloseAsync();
            return cityMains;
        }
        public async Task DeleteAllCityWeatherAsync(string cityName)
        {
            await connection.OpenAsync();
            var sql = "DELETE FROM public.\"CityWeather\"";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            await command.ExecuteNonQueryAsync();
            await connection.CloseAsync();
        }
        public async Task UpdateCityWeather(CityWeather cityWeather, string cityName)
        {
            await connection.OpenAsync();
            var sql = "UPDATE public.\"CityWeather\" SET \"Temp\" = @Temp, \"Time\" = @Time, \"SpeedWind\" = @SpeedWind, \"GustWind\" = @GustWind, \"Pressure\" = @Pressure, \"Humidity\" = @Humidity, \"Country\" = @Country WHERE \"CityName\" = @CityName";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CityName", cityName);
            command.Parameters.AddWithValue("Temp", cityWeather.Main.Temp);
            command.Parameters.AddWithValue("Time", DateTime.Now);
            command.Parameters.AddWithValue("Visibility", cityWeather.Visibility);
            command.Parameters.AddWithValue("SpeedWind", cityWeather.Wind.Speed);
            command.Parameters.AddWithValue("Humidity", cityWeather.Main.Humidity);
            command.Parameters.AddWithValue("Pressure", cityWeather.Main.Pressure);
            command.Parameters.AddWithValue("GustWind", cityWeather.Wind.Gust);
            command.Parameters.AddWithValue("Country", cityWeather.Sys.Country);

            await command.ExecuteNonQueryAsync();
            await connection.CloseAsync();
        }


    }
}
