using BusinessObjects;
using Microsoft.Data.SqlClient;
using Repositories;

public class CourtRepository : ICourtRepository
{
    private readonly string connectionString = @"Server=(local);Database=SportsBookingDB;User Id=sa;Password=1234567890;TrustServerCertificate=True;";

    public List<Court> GetAllCourts()
    {
        var courts = new List<Court>();
        using (var conn = new SqlConnection(connectionString))
        {
            string query = @"SELECT c.*, cs.StatusName 
                             FROM Courts c 
                             LEFT JOIN CourtStatus cs ON c.StatusID = cs.StatusID";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                courts.Add(new Court
                {
                    CourtId = (int)reader["CourtID"],
                    CourtName = reader["CourtName"].ToString() ?? "",
                    SportId = (int)reader["SportID"],
                    Location = reader["Location"] != DBNull.Value ? reader["Location"].ToString() : null,
                    PricePerHour = reader["PricePerHour"] != DBNull.Value ? (decimal?)reader["PricePerHour"] : null,
                    StatusId = reader["StatusID"] != DBNull.Value ? (int?)reader["StatusID"] : null,
                    Status = reader["StatusName"] != DBNull.Value ? reader["StatusName"].ToString() : null
                });
            }
        }
        return courts;
    }

    public List<CourtStatus> GetStatuses()
    {
        var list = new List<CourtStatus>();
        using (var conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM CourtStatus";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new CourtStatus
                {
                    StatusId = (int)reader["StatusID"],
                    StatusName = reader["StatusName"]?.ToString()
                });
            }
        }
        return list;
    }

    public void AddCourt(Court court)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO Courts (CourtName, SportID, Location, PricePerHour, StatusID)
                             VALUES (@name, @sport, @loc, @price, @status)";
            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", court.CourtName);
            cmd.Parameters.AddWithValue("@sport", court.SportId);
            cmd.Parameters.AddWithValue("@loc", (object?)court.Location ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@price", (object?)court.PricePerHour ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@status", (object?)court.StatusId ?? DBNull.Value);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateCourt(Court court)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            string query = @"UPDATE Courts SET 
                                CourtName = @name,
                                SportID = @sport,
                                Location = @loc,
                                PricePerHour = @price,
                                StatusID = @status
                             WHERE CourtID = @id";
            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", court.CourtName);
            cmd.Parameters.AddWithValue("@sport", court.SportId);
            cmd.Parameters.AddWithValue("@loc", (object?)court.Location ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@price", (object?)court.PricePerHour ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@status", (object?)court.StatusId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id", court.CourtId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteCourt(int courtId)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            var cmd = new SqlCommand("DELETE FROM Courts WHERE CourtID = @id", conn);
            cmd.Parameters.AddWithValue("@id", courtId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}