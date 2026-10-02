namespace UmarSons.Mobile.Services.Models;

public class GrandSummaryResponse
{
    public bool Success { get; set; }
    public List<GrandSummaryRow> Rows { get; set; } = new();
    public decimal TotalReceived { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal ClosingBalance { get; set; }
}

public class GrandSummaryRow
{
    public int No { get; set; }
    public string Date { get; set; } = "";
    public decimal CashReceived { get; set; }
    public decimal Expenses { get; set; }
    public decimal TotalPayment { get; set; }
}