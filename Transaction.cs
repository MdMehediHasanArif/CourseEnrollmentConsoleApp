namespace StudentRegistration;

public class Transaction: Enrollment
{
    public Transaction(int next) : base(next)
    {
        TransactionID = next;
    }
    
    public int TransactionID { get; set; }

    public int TransactionAmount(int credit)
    {
        return credit * 7000;
    }
}