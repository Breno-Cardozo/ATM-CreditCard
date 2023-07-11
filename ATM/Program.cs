using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder (string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    
    public string getNum()
    { return cardNum;
    }

    public int getPin()
    { return pin; }

    public string getFirstName() 
    { return firstName; }

    public string getLastName() 
    { return lastName; }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    { cardNum = newCardNum; }

    public void setPin(int newPin)
    { pin = newPin; }

    public void setFirstName(string newFirstName) 
    {  firstName = newFirstName; }

    public void setLastName (string newLastName)
    { lastName = newLastName; }

    public void setBalance (double newBalance)
    { balance = newBalance; } 

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Por favor escolha uma das seguintes opções...");
            Console.WriteLine("1. Depósito");
            Console.WriteLine("2. Sacar");
            Console.WriteLine("3. Ver seu balanço");
            Console.WriteLine("4. Sair dessa operação");
        }

        void deposit (cardHolder currentUser)
        {
            Console.WriteLine("Quantos reais você gostaria de depositar? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit + currentUser.getBalance());
            Console.WriteLine($"Obrigado pelo seu R$. Seu novo balanço é: {currentUser.getBalance()}");
        }

        void withdraw (cardHolder currentUser)
        {
            Console.WriteLine("Quantos reais você deseja sacar: ");
            double withdrawal= Double.Parse(Console.ReadLine());
            //Validação se o usuário tem dinheiro o suficiente para sacar
            if (currentUser.getBalance() < withdrawal) {
                Console.WriteLine("Valor insuficiente");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine($"O seu novo saldo é {currentUser.getBalance()}");
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Balanço atual: "+currentUser.getBalance());
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "Breno", "Fagundes", 150.31));
        cardHolders.Add(new cardHolder("4532772818527396", 4321, "Gustavo", "Sotz", 321.31));
        cardHolders.Add(new cardHolder("4532772818527397", 9999, "Laura", "Jeronimo", 105.94));
        cardHolders.Add(new cardHolder("4532772818527398", 2468, "Julia", "Ferri", 851.84));
        cardHolders.Add(new cardHolder("4532772818527399", 4826, "Lois", "Reis", 54.27));

        Console.WriteLine("Bem vindo ao SimpleATM");
        Console.WriteLine("Por favor insira seu cartão de débito: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine().ToString();
                //Validação se bate o número do cartão
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Cartão não reconhecido. Por favor tente novamente"); }
            }
            catch { Console.WriteLine("Cartão não reconhecido. Por favor tente novamente"); }
        }
        Console.WriteLine("Por favor insira a sua senha: ");
        int userPin;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Senha incorreta. Por favor tente novamente"); }
            }
            catch { Console.WriteLine("Senha incorreta. Por favor tente novamente"); }
        }
        Console.WriteLine("Bem vindo " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Obrigado! Tenha um ótimo dia!");

    }
}