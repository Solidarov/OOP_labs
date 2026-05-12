using LabWorkNo10.Models;

namespace LabWorkNo10.Proxy;

public class SecureStoreProxy : IFinancialStore
{
    private readonly FinancialStore _realStore;
    private readonly string _pin;
    private bool _isAuthenticated = false;

    public SecureStoreProxy(FinancialStore realStore, string pin)
    {
        _realStore = realStore;
        _pin = pin;
    }

    public void Authenticate(string pin)
    {
        if (_pin == pin)
        {
            _isAuthenticated = true;
            Console.WriteLine("[Proxy] Доступ дозволено.");
        }
        else
        {
            _isAuthenticated = false;
            Console.WriteLine("[Proxy] ПОМИЛКА: Невірний PIN-код!");
        }
    }

    public void AddOperation(IFinancialOperation operation)
    {
        if (_isAuthenticated)
        {
            _realStore.AddOperation(operation);
        }
        else
        {
            Console.WriteLine("[Proxy] Відмовлено: Потрібна авторизація для додавання операції.");
        }
    }

    public void PrintHistory()
    {
        if (_isAuthenticated)
        {
            _realStore.PrintHistory();
        }
        else
        {
            Console.WriteLine("[Proxy] Відмовлено: Потрібна авторизація для перегляду історії.");
        }
    }
}
