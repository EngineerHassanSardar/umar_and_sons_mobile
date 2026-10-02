namespace UmarSons.Mobile.Services.Models;

public class ProductsListResponse
{
    public bool Success { get; set; }
    public List<ProductItem> Data { get; set; } = new();
}

public class ProductItem
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
    public decimal CBM { get; set; }
    public DateTime? ArrivalDate { get; set; }
    public string? Description { get; set; }
    public bool Published { get; set; }
}