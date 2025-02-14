class Account
{
    public string Name { get; set; }
    private decimal balance;
    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value >= 0)
            {
                balance = value;
            }
        }
    }
    public decimal Debt { get; set; }

    public Account(string initName)
    {
        Name = initName;
        Balance = 30000;
    }

    public void DebtInc()
    {
        Debt *= 1.02m;
    }
}