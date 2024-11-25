using BankSystem.Loans;

namespace BankSystem;

public class Users
{
    public string Name { get; private set; }
    
    private int _phoneNumber;

    public int PhoneNumber
    {
        get { return _phoneNumber; }
        set
        {
            if (value.ToString().Length < 10 || value.ToString().Length > 10)
            {
                throw new Exception("Your number must be 10 nums.");
            }

            _phoneNumber = value;
        }
    }

    private readonly int _age;
    public List<Loan> Loans; 
    public double Money { get; set; }
    public bool IsWorker;
    public Dictionary<string, double> OnlineTransactions;
    
    private int _pin;

    public int Pin
    {
        get { return _pin; }
        set
        {
            if (value.ToString().Length < 4 || value.ToString().Length > 4)
            {
                throw new Exception("Your pin must 4 digits long");
            }

            _pin = value;
        }
    }
    

    public Users(string name, int phoneNumber, int age, int myPin)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        _age = age;
        Money = 0;
        Pin = myPin;
        IsWorker = false;
        Loans = new List<Loan>();
        OnlineTransactions = new Dictionary<string, double>();
    }

    public string UserDetails()
    {
        string loanString = "";
        foreach (var loan in Loans)
        {
            
            loanString = loanString + loan.Name + ", ";
        }
        string details = $"{Name} on {_age} with phone number {_phoneNumber} and have loans" +
                         $"{loanString} ";
        return details;
    }

    public void PastTransactions()
    {
        foreach (KeyValuePair<string, double> kvp in OnlineTransactions)
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }

        Console.WriteLine($"My current balance is {Money}");
    }

    public void ChangePhoneNumber(string newNumber)
    {
        PhoneNumber = int.Parse(newNumber);
    }

    public void ChangeName(string newName)
    {
        Name = newName;
    }

    public void ChangePin(string pin)
    {
        Pin = int.Parse(pin);
    }
    
}
