namespace StudentRegistration;

class Program
{
    static void Main(string[] args)
    {
        Admin admin = new Admin("admin", "1234");
        
        List<Student> students = new List<Student>
        {
            new Student("Arif", "1234", "arif@gmail.com"),
            new Student("Rifat", "1234", "rifat@gmail.com"),
            new Student("Mehedi","1234","mehedi@gmail.com"),
            new Student("Hasan","1234","hasan@gmail.com")
        };

        List<Course> courses = new List<Course>
        {
            new Course(1, "101", "Math", 3, "Prof Sobhan", "11:00-1:00"),
            new Course(2, "102", "Economics", 2, "Ms Layla", "3:00-4:00"),
            new Course(3, "201", "Math-2", 3, "Prof Hassan", "9:00-11:00")
        };

        List<Course> myCourses = new List<Course>();

        while (true)
        {
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            
            int loopIterator = 1;

            if (username == admin.UserName && password == admin.Password)
            {
                while (loopIterator==1)
                {
                    Console.WriteLine("1.Show Courses\n2.Add Course\n3.Delete Course\n4.Logout\n");
                    var choice = Convert.ToInt32(Console.ReadLine());
                    
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(courses.ToStringTable(
                                new[] {"Id", "Course Code", "Course Name", "Course Credit", "Instructor","Class Time"},
                                a => a.ID, a => a.CourseCode, a => a.CourseName,a=>a.Credit,
                                a=>a.Instructor,a=>a.ClassTime));
                            break;
                        
                        case 2:
                            courses.Add(new Course(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(),
                                Console.ReadLine(), Convert.ToInt32(Console.ReadLine()),
                                Console.ReadLine(), Console.ReadLine()));
                            break;
                        
                        case 3:
                            Console.WriteLine("Input the id of the course you want to remove: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            courses.RemoveAt(id - 1);
                            Console.WriteLine($"Course removed successfully!\n");
                            break;
                        
                        case 4:
                            loopIterator = 0;
                            break;
                    }
                }
            }
            else if ((students.Find(x => x.UserName == username) != null) &&
                     (students.Find(x => x.Password == password) != null))
            {
                while (loopIterator==1)
                {
                    Console.WriteLine("1.View Courses\n2.My Courses\n3.Enroll in courses\n4.Logout\n");
                    var choice = Convert.ToInt32(Console.ReadLine());
                    
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(courses.ToStringTable(
                                new[] {"Id", "Course Code", "Course Name", "Course Credit", "Instructor","Class Time"},
                                a => a.ID, a => a.CourseCode, a => a.CourseName,a=>a.Credit,
                                a=>a.Instructor,a=>a.ClassTime));
                            break;
                        
                        case 2:
                            Console.WriteLine(myCourses.ToStringTable(
                                new[] {"Id", "Course Code", "Course Name", "Course Credit", "Instructor","Class Time"},
                                a => a.ID, a => a.CourseCode, a => a.CourseName,a=>a.Credit,
                                a=>a.Instructor,a=>a.ClassTime));
                            break;
                        
                        case 3:
                            Random rnd = new Random();
                            Enrollment enrollment = new Enrollment(rnd.Next());
                            
                            Console.WriteLine(courses.ToStringTable(
                                new[] {"Id", "Course Code", "Course Name", "Course Credit", "Instructor","Class Time"},
                                a => a.ID, a => a.CourseCode, a => a.CourseName,a=>a.Credit,
                                a=>a.Instructor,a=>a.ClassTime));
                            
                            Console.WriteLine("How many courses do you want to enroll in: ");
                            int numOfCourses = Convert.ToInt32(Console.ReadLine());
                            
                            Console.WriteLine("Input the id of courses you want to enroll in: ");
                            //int[] courseIds = new int[] { };
                            int totalCourseCredit = 0;
                            
                            while (numOfCourses != 0)
                            {
                                int courseIds = Convert.ToInt32(Console.ReadLine());
                                totalCourseCredit += courses[courseIds - 1].Credit;
                                myCourses.AddRange(courses.GetRange(courseIds - 1, 1));
                                numOfCourses--;
                            }

                            if (enrollment.IsEnoughCreditTaken(totalCourseCredit) == false)
                            {
                                Console.WriteLine("Not enough credit taken! Try again please.\n");
                            }
                            else
                            {
                                Console.WriteLine($"Congratulations. You can enroll. Your enrollment id is {enrollment.EnrollmentID}\n");
                                Transaction transaction = new Transaction(rnd.Next());
                                
                                Console.WriteLine($"Your total transaction amount is {transaction.TransactionAmount(totalCourseCredit)}\n");
                                Console.WriteLine("Do you want to make payment?\n1.Yes\n2.No\n");
                                
                                var decision = Console.ReadLine();
                                if (decision == "Yes")
                                {
                                    Console.WriteLine($"Congratulations! You have enrolled successfully.\nYour" +
                                                      $" enrollment id is {enrollment.EnrollmentID}" +
                                                      $" and\nYour transaction id is {transaction.TransactionID}\n");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        
                        case 4:
                            loopIterator = 0;
                            break;
                    }
                }
            }

            else
            {
                Console.WriteLine("Invalid Credentials!\nTry Again.\n");
            }
        }
    }
}

