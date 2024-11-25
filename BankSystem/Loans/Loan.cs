namespace BankSystem.Loans;

public class Loan
{
    public string Name { get; private set; }
    public int Term { get; set; }
    public double Price { get; set; }

    public Loan(string name, int term, double price)
    {
        Name = name;
        Term = term;
        Price = price;
    }
    
}