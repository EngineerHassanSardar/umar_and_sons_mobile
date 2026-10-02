namespace UmarSons.Mobile.Services.Models;

public class ContainersListResponse
{
    public bool Success { get; set; }
    public List<ContainerItem> Data { get; set; } = new();
}

public class ContainerItem
{
    public int Id { get; set; }
    public string? BillLandingNumber { get; set; }
    public string? ContainerNumber { get; set; }
    public string? ExporterName { get; set; }
    public string? ExporterAddress { get; set; }
    public string? ImporterName { get; set; }
    public string? ImporterAddress { get; set; }
    public DateTime? LoadingDate { get; set; }
    public string? ShippingMark { get; set; }
    public string? Unit { get; set; }
    public string? ProductName { get; set; }
    public decimal TotalCartons { get; set; }
    public decimal TotalWeight { get; set; }
    public decimal NetWeight { get; set; }
    public decimal TotalCBM { get; set; }
    public decimal TotalPairs { get; set; }
    public List<ContainerCustomer> Customers { get; set; } = new();
}

public class ContainerCustomer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
}