namespace TaskBankAccounts.AbstractModels
{
    public abstract class Customer
    {
        public Customer(int clientId, string name)
        {
            this.ClientId = clientId;
            this.Name = name;
        }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Name: " + this.Name);
        }
    }
}
