using BankSystem.Loans;

namespace BankSystem;

public class Bank
{
    public string Name { get; set; }
    private List<Loan> _availableLoans;
    private List<Users> _users;
    private List<Worker> _workers;

    public Bank(string name)
    {
        Name = name;
        _availableLoans = new List<Loan>();
        _users = new List<Users>();
        _workers = new List<Worker>();
    }

    public string CreateUser(string name, int phoneNumber, int age, int myPin)
    {
        foreach (var user in _users)
        {
            if (user.Name == name)
            {
                return $"User {name} already exists";
            }
        }
        Users newUser = new Users(name,  phoneNumber,  age, myPin);
        _users.Add(newUser);

        foreach (var worker in _workers)
        {
            if (worker.Name == newUser.Name)
            {
                newUser.IsWorker = true;
            }
        }
        
        return $"New user {name} was created";
    }

    public string GetUserDetails(string name)
    {
        foreach (Users user in _users)
        {
            if (user.Name == name)
            {
                return user.UserDetails();
            }
        }

        return "User not found";
    }

    public string GetWorkerDetsils(string name)
    {
        foreach (Worker worker in _workers)
        {
            if (worker.Name == name)
            {
                return worker.WorkerDetails();
            }
        }

        return "Worker not found";
    }

    public string TakeLoan(string typeLoan, string username)
    {
        Loan? myAvLoan = null;
        foreach (var loan in _availableLoans)
        {
            if (loan.Name == typeLoan)
            {
                myAvLoan = loan;
            }
        }

        if (myAvLoan != null)
        {
            foreach (var user in _users)
            {
                if (user.Name == username)
                {
                    user.Loans.Add(myAvLoan);
                    user.Money += myAvLoan.Price;
                    return $"User {username} took {myAvLoan.Name} with {myAvLoan.Price}.";
                }
            }
            return $"User not found";
        }
        return $"Loan not found.";
    }

    public void AllLoansDetails()
    {
        foreach (var loan in _availableLoans)
        {
            Console.WriteLine($"Loan {loan.Name} for {loan.Price} for {loan.Term}");
        }
    }

    public string Deposit(double depositMoney, string name)
    {
        foreach (var user in _users)
        {
            if (user.Name == name)
            {
                user.Money += depositMoney;
                return $"{depositMoney} transferred to {user.Name}.";
            }
        }
        return $"User not found.";
    }

    public string MakeOnlineTransaction(string username, string transactionName, double price)
    {
        Users? currentUser = null;
        foreach (var user in _users)
        {
            if (user.Name == username)
            {
                currentUser = user;
            }
        }

        if (currentUser == null)
        {
            return "User not found";
        }

        if (currentUser.Money - price >= 0)
        { 
            currentUser.Money -= price;
            foreach (string transactionNameIn in currentUser.OnlineTransactions.Keys)
            {
                if (transactionNameIn == transactionName)
                {
                    currentUser.OnlineTransactions[transactionNameIn] += price;
                    return $"Successfull online transaction for {price}.";
                }
            }
            currentUser.OnlineTransactions[transactionName] = price;
            return $"Successfull online transaction for {price}.";
        }
        return $"Not enough money in your bank account.";
    }

    public string MoneyTransaction(string fromAccount, string toAccount, double money)
    {
        Users? currentUser1 = null;
        Users? currentUser2 = null;

        foreach (var user in _users)
        {
            if (user.Name == fromAccount)
            {
                currentUser1 = user;
            }
        }

        foreach (var user in _users)
        {
            if (user.Name == toAccount)
            {
                currentUser2 = user;
            }
        }

        if (currentUser1 == null || currentUser2 == null)
        {
            return "Invalid data, please enter valid date";
        }

        currentUser1.Money -= money;
        currentUser2.Money += money;
        return $"{money} transferred from {currentUser1.Name} to {currentUser2.Name}";
    }

    public string Atm(string name, double price, int pin)
    {
        foreach (var user in _users)
        {
            if (user.Name == name && user.Pin == pin)
            {
                user.Money -= price;
                return $"You got {price} from your bank account";
            }
        }

        return "Invalid date";
    }

    public string PermissionToChangeName(string client, string worker, string name)
    {
        Users? person = null;
        Worker? employee = null;

        foreach (Users user in _users)
        {
            if (user.Name == client)
            {
                person = user;
            }
        }

        foreach (Worker empl in _workers)
        {
            if (empl.Name == worker)
            {
                employee = empl;
            }
        }

        if (employee == null || person == null)
        {
            return "Something from the data is wrong.";
        }
        
        person.ChangeName(client);

        return $"Worker {employee.Name} gave the permission to change name to {person.Name}";
    }
    
    
    
    
    //TODO
    // imoti, loan time past, create loans,
    // transfer salaries, bills pay,
    // permission to change phone, pin, kura mi qnko
    
    
}