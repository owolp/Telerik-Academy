namespace TaskBankAccounts.AbstractModels
{
    using System.Text;
    using Interfaces;
    using Models.Customer;

    public abstract class Account : IDeposit, ICalculateRate
    {
        private const decimal InterestRate = 6.8M;

        public Account(Customer customer, decimal balance, decimal monthlyInterestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public Customer Customer { get; set; }

        public decimal Balance { get; set; }

        public decimal MonthlyInterestRate { get; set; }

        public virtual void Deposit(decimal deposit)
        {
            this.Balance += deposit;
        }

        public virtual decimal CalculateMonthlyInteresetRate(int months)
        {
            return months * InterestRate;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("Customer type: " + this.Customer.GetType().Name);
            result.AppendLine("Customer: " + this.Customer);
            result.AppendLine("Balance: " + this.Balance);
            result.AppendLine("Interest rate: " + InterestRate);
            return result.ToString();
        }
    }
}
