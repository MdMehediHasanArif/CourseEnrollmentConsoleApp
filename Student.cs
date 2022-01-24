namespace StudentRegistration;

public class Student: User
{
    public Student(string name, string pass, string email) : base(name, pass)
    {
        Email = email;
    }

    public string Email { get; set; }

}