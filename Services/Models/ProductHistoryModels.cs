namespace UmarSons.Mobile.Services.Models;

public class ProductHistoryListResponse
{
    public bool Success { get; set; }
    public List<ProductHistoryItem> Data { get; set; } = new();
}

public class ProductHistoryItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ShippingMark { get; set; }
    public decimal Weight { get; set; }
    public string? CustomerName { get; set; }
    public string? CategoryName { get; set; }
    public decimal Measurements { get; set; }
    public string? Brand { get; set; }
    public string? Unit { get; set; }
    public decimal NumberofCartons { get; set; }
    public decimal NumberofPCs { get; set; }
    public string? TransactionType { get; set; }
    public decimal CBM { get; set; }
    public DateTime? ArrivalDate { get; set; }
    public string? Description { get; set; }
    public bool Published { get; set; }
}