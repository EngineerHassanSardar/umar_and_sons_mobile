using System.Net.Http.Json;
using System.Text.Json;
using UmarSons.Mobile.Services.Models;

namespace UmarSons.Mobile.Services;

public class ApiService
{
    private readonly HttpClient _http;

    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public ApiService(HttpClient http)
    {
        _http = http;
    }

    private string Url(string endpoint) => $"{ApiSettings.BaseUrl}{ApiSettings.ApiPrefix}{endpoint}";

    // No auth header needed — the HttpClient cookie container attaches the
    // Identity cookie automatically on every request.

    public async Task<GrandSummaryResponse?> GetGrandSummaryAsync(string? from = null, string? to = null)
    {
        var url = Url("/grand-summary");
        if (!string.IsNullOrEmpty(from) || !string.IsNullOrEmpty(to))
            url += $"?from={from}&to={to}";
        return await _http.GetFromJsonAsync<GrandSummaryResponse>(url, JsonOpts);
    }

    public async Task<CustomerLedgerListResponse?> GetCustomerLedgerListAsync()
    {
        return await _http.GetFromJsonAsync<CustomerLedgerListResponse>(Url("/customer-ledger-list"), JsonOpts);
    }

    public async Task<CustomerLedgerResponse?> GetCustomerLedgerAsync(int customerId, string? from = null, string? to = null)
    {
        var url = Url($"/customer-ledger?customerId={customerId}");
        if (!string.IsNullOrEmpty(from)) url += $"&from={from}";
        if (!string.IsNullOrEmpty(to)) url += $"&to={to}";
        return await _http.GetFromJsonAsync<CustomerLedgerResponse>(url, JsonOpts);
    }

    public async Task<ExpensesResponse?> GetExpensesAsync()
    {
        return await _http.GetFromJsonAsync<ExpensesResponse>(Url("/expenses"), JsonOpts);
    }

    public async Task<ContainersListResponse?> GetContainersListAsync()
    {
        return await _http.GetFromJsonAsync<ContainersListResponse>(Url("/containers-list"), JsonOpts);
    }

    public async Task<ProductsListResponse?> GetProductsListAsync()
    {
        return await _http.GetFromJsonAsync<ProductsListResponse>(Url("/products-list"), JsonOpts);
    }

    public async Task<ProductHistoryListResponse?> GetProductsHistoryListAsync()
    {
        return await _http.GetFromJsonAsync<ProductHistoryListResponse>(Url("/products-history-list"), JsonOpts);
    }

    public async Task<ReceivingProductsListResponse?> GetReceivingProductsListAsync()
    {
        return await _http.GetFromJsonAsync<ReceivingProductsListResponse>(Url("/receiving-products-list"), JsonOpts);
    }

    public async Task<CustomerDeliveryListResponse?> GetCustomerDeliveryListAllAsync()
    {
        return await _http.GetFromJsonAsync<CustomerDeliveryListResponse>(Url("/customer-delivery-list-all"), JsonOpts);
    }
}