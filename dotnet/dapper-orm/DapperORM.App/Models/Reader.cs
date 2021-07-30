namespace DapperORM.App.Models
{
    public record Reader(int Id, string DBName, string FristName, string LastName, bool IsAdult, string Phone, decimal Credit);
}