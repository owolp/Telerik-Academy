namespace TaskBankAccounts.Models.Account
{
    using AbstractModels;
    using Customer;

    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateMonthlyInteresetRate(int months)
        {
            if (this.Customer is Company && months < 12)
            {
                return base.CalculateMonthlyInteresetRate(months) / 2;
            }
            else if (this.Customer is Individual && months < 6)
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
