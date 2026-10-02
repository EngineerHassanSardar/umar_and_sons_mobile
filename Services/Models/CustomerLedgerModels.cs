namespace UmarSons.Mobile.Services.Models;

public class CustomerLedgerListResponse
{
    public bool Success { get; set; }
    public List<CustomerLedgerListItem> Data { get; set; } = new();
}

public class CustomerLedgerListItem
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal RemainingAmount { get; set; }
}

public class CustomerLedgerResponse
{
    public bool Success { get; set; }
    public CustomerLedgerCustomer? Customer { get; set; }
    public List<CustomerLedgerEntry> Entries { get; set; } = new();
    public CustomerLedgerSummary? Summary { get; set; }
}

public class CustomerLedgerCustomer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
}

public class CustomerLedgerEntry
{
    public string Date { get; set; } = "";
    public string ContainerNo { get; set; } = "";
    public decimal TotalAmount { get; set; }
    public decimal PaymentReceived { get; set; }
    public decimal Remaining { get; set; }
}

public class CustomerLedgerSummary
{
    public decimal OpeningBalance { get; set; }
    public decimal InvoicedAmount { get; set; }
    public decimal NetAmount { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal AmountDue { get; set; }
}