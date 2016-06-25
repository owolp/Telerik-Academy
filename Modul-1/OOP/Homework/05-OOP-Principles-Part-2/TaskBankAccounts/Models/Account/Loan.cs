namespace TaskBankAccounts.Models.Account
{
    using AbstractModels;
    using Customer;

    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateMonthlyInteresetRate(int months)
        {
            if ((this.Customer is Individual && months < 3) || (this.Customer is Company && months < 2))
            {
                return 0;
            }
            else
            {
                return base.CalculateMonthlyInteresetRate(months);
            }
        }
    }
}
