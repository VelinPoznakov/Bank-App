namespace BankSystem.Loans;

public class StudentLoan: Loan
{
    public double Interest;

    public StudentLoan(string name, int term, double price) : base(name, term, price)
    {
        Interest = 0.05;
    }

    public string FullPriceToPay()
    {
        return $"The full price that you have to pay is {Price + (Price * Interest)}";
    }
}