namespace StudentRegistration;

public class Course
{
    public Course(int id, string? cCode, string? cName, int credit, string? instructor, string? classTime)
    {
        this.ID = id;
        this.CourseCode = cCode;
        this.CourseName = cName;
        this.Credit = credit;
        this.Instructor = instructor;
        this.ClassTime = classTime;
    }

    public int ID { get; set; }
    public string? CourseCode { get; set; }
    public string? CourseName { get; set; }
    public int Credit { get; set; }
    public string? Instructor { get; set; }
    public string? ClassTime { get; set; }

}