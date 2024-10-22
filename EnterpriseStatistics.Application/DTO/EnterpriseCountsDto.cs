namespace EnterpriseStatistics.Application.DTO;

public class EnterpriseCountsDto
{
    public required int SupplierId { get; set; }
    public required string FullName { get; set; }
    public int EnterpriseCount { get; set; }
}
