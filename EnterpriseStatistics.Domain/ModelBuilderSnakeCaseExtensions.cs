using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace EnterpriseStatistics.Domain;

public static class ModelBuilderSnakeCaseExtensions
{
    public static void ToSnakeCase(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(ToSnakeCase(property.Name));
            }
        }
    }

    private static string ToSnakeCase(string input)
    {
        return Regex.Replace(input, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }
}
