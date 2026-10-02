namespace UmarSons.Mobile.Services.Models;

public class ReceivingProductsListResponse
{
    public bool Success { get; set; }
    public List<ReceivingProductItem> Data { get; set; } = new();
}

public class ReceivingProductItem
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public string? CustomerName { get; set; }
    public string? ShippingMark { get; set; }
    public decimal TotalCartons { get; set; }
    public decimal Weight { get; set; }
    public string? Route { get; set; }
    public DateTime? ArrivalDate { get; set; }
    public string? Description { get; set; }
}