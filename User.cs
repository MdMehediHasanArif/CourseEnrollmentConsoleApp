namespace StudentRegistration;

public class User
{
    public User(string name, string pass)
    {
        this.UserName = name;
        this.Password = pass;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
    
}