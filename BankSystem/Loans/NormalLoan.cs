namespace BankSystem.Loans;

public class NormalLoan: Loans.Loan
{
    private readonly double _interest;

    public NormalLoan(string name, int term, double price) : base(name, term, price)
    {
        _interest = 0.1;
    }
    
    public string FullPriceToPay()
    {
        return $"The full price that you have to pay is {Price + (Price * _interest)}";
    }
    
}