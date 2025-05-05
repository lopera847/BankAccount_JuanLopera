using System;

public class BankAccount
{
    // Propiedades
    public string AccountNumber { get; }
    public string OwnerName { get; }
    public decimal Balance { get; private set; }

    // Constructor
    public BankAccount(string accountNumber, string ownerName, decimal initialBalance = 100000)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    // Método para depositar
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("El monto a depositar debe ser mayor que cero.");
            return;
        }

        Balance += amount;
        Console.WriteLine($"Depósito exitoso de {amount}. Nuevo saldo: {Balance}");
    }

    // Método para retirar
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("El monto a retirar debe ser mayor que cero.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("Fondos insuficientes para realizar el retiro.");
            return;
        }

        Balance -= amount;
        Console.WriteLine($"Retiro exitoso de {amount}. Nuevo saldo: {Balance}");
    }

    // Método para transferir a otra cuenta
    public void Transfer(BankAccount destinationAccount, decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("El monto a transferir debe ser mayor que cero.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("Fondos insuficientes para realizar la transferencia.");
            return;
        }

        this.Withdraw(amount);
        destinationAccount.Deposit(amount);
        Console.WriteLine($"Transferencia exitosa de {amount} a la cuenta {destinationAccount.AccountNumber}.");
    }

    // Método para mostrar el saldo
    public void ShowBalance()
    {
        Console.WriteLine($"Saldo actual de la cuenta {AccountNumber}: {Balance}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear una nueva cuenta bancaria
        BankAccount account = new BankAccount("123456789", "Juan Pérez");

        // Mostrar saldo inicial
        account.ShowBalance();

        // Realizar un depósito de 200000
        account.Deposit(200000);
        account.ShowBalance();

        // Realizar un retiro de 150000
        account.Withdraw(150000);
        account.ShowBalance();

        // Crear una segunda cuenta para probar transferencia
        BankAccount account2 = new BankAccount("987654321", "María Gómez");
        Console.WriteLine("\nAntes de la transferencia:");
        account.ShowBalance();
        account2.ShowBalance();

        // Transferir 100000 de account a account2
        account.Transfer(account2, 100000);

        Console.WriteLine("\nDespués de la transferencia:");
        account.ShowBalance();
        account2.ShowBalance();
    }
}