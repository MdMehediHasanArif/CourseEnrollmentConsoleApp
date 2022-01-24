namespace StudentRegistration;

public class Enrollment
{
    public Enrollment(int next)
    {
        EnrollmentID = next;
    }

    public int EnrollmentID { get; set; }

    public bool IsEnoughCreditTaken(int totalCredit)
    {
        if(totalCredit>7&&totalCredit<20) return true;
        else return false;
    }
}