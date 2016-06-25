namespace TaskBankAccounts.Models.Customer
{
    using AbstractModels;

    public class Company : Customer
    {
        public Company(int clientId, string name)
            : base(clientId, name)
        {
        }
    }
}
