namespace UmarSons.Mobile.Services.Models;

public class ExpensesResponse
{
    public bool Success { get; set; }
    public List<ExpenseItem> Data { get; set; } = new();
}

public class ExpenseItem
{
    public int Id { get; set; }
    public string ExpenseType { get; set; } = "";
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public string? GivenTo { get; set; }
    public string? PaymentMethod { get; set; }
    public string? Reference { get; set; }
    public string? AttachmentName { get; set; }
    public string? BankNo { get; set; }
    public string? ReceiptNo { get; set; }
    public string? AccountNo { get; set; }
    public int? PaidFromAccountId { get; set; }
    public string? PaidFromAccountName { get; set; }
}