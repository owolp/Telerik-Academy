namespace TaskBankAccounts.Models.Account
{
    using AbstractModels;
    using Interfaces;

    public class Deposit : Account, IWithdraw
    {
        public Deposit(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateMonthlyInteresetRate(int months)
        {
            if (0 < this.Balance && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateMonthlyInteresetRate(months);
            }
        }

        public void Withdraw(decimal withdraw)
        {
            this.Balance -= withdraw;
        }
    }
}
