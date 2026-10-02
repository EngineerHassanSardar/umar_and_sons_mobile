namespace UmarSons.Mobile.Services.Models;

public class CustomerDeliveryListResponse
{
    public bool Success { get; set; }
    public List<CustomerDeliveryItem> Data { get; set; } = new();
}

public class CustomerDeliveryItem
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? ShippingMark { get; set; }
    public string? ContainerNo { get; set; }
    public string? Route { get; set; }
    public string? ReceivedBy { get; set; }
    public string? Status { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public decimal TotalCartons { get; set; }
    public decimal Weight { get; set; }
    public decimal Amount { get; set; }
}