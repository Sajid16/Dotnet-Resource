//IList<Student> studentList = new List<Student>()
//{
//    new Student() { StudentID = 1, StudentName = "John", Age = 13, ProgrammingLanguages = new List<string>{ "vvvvv", "C#", "JavaScript"} } ,
//    new Student() { StudentID = 2, StudentName = "Moin",  Age = 21, ProgrammingLanguages = new List<string>{ "C#", "C++", "TypeScript"}  } ,
//    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, ProgrammingLanguages = new List<string>{ "Mode.js", "C", "JavaScript"}  } ,
//    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, ProgrammingLanguages = new List<string>{ "PLSQL", "APEX", ".NetCore"} } ,
//    new Student() { StudentID = 5, StudentName = "Ron" , Age = 15, ProgrammingLanguages = new List<string>{ "Linq", "Angular", "TypeScript"}  }
//};

using Linq;

IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 13, ProgrammingLanguages = new List<Techs>{
                    new Techs() { Technology = "Linq" },
                    new Techs() { Technology = "C#" },
                    new Techs() { Technology = "JavaScript" } } } ,
                new Student() { StudentID = 2, StudentName = "John",  Age = 21, ProgrammingLanguages = new List<Techs>{
                    new Techs() { Technology = "Linq" },
                    new Techs() { Technology = "C#" },
                    new Techs() { Technology = "JavaScript" } }  } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, ProgrammingLanguages = new List<Techs>{
                    new Techs() { Technology = "Linq" },
                    new Techs() { Technology = "C#" },
                    new Techs() { Technology = "JavaScript" } }  } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, ProgrammingLanguages = new List<Techs>{
                    new Techs() { Technology = "Linq" },
                    new Techs() { Technology = "C#" },
                    new Techs() { Technology = "JavaScript" } } } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15, ProgrammingLanguages = new List<Techs>{
                    new Techs() { Technology = "Linq" },
                    new Techs() { Technology = "C#" },
                    new Techs() { Technology = "JavaScript" } }  }
            };

//---------------------------------------------------------------------
#region select

//var queryResult = (from student in studentList
//                   select student).ToList();
//var queryResult = (from student in studentList
//                   select new
//                   {
//                       studentName = student.StudentName,
//                       studentId = student.StudentID
//                   }).ToList();
//var methodResult = studentList.Select(student => student.Age).ToList();
//var methodResult = studentList.Select(student => new 
//{
//    studentName = student.StudentName,
//    studentAge = student.Age
//}).ToList();

//foreach (var student in queryResult)
//{
//    Console.WriteLine(student.studentName + " -> "+student.studentId);
//}
#endregion

// --------------------------------------------------------------------

#region selectMany

//var queryResult = (from student in studentList
//                   from skill in student.ProgrammingLanguages
//                   select skill).Distinct().ToList();

//var methodResult = studentList.SelectMany(student => student.ProgrammingLanguages).Distinct().ToList();

//var queryResult = (from student in studentList
//                   from skill in student.ProgrammingLanguages
//                   select skill).ToList();

//var methodResult = studentList.SelectMany(student => student.ProgrammingLanguages).ToList();

//foreach (var studentInfo in queryResult)
//{
//    Console.WriteLine(studentInfo.Technology);
//}

#endregion

// --------------------------------------------------------------------

#region where

//query syntax
//var filterResult = (from student in studentList
//                    where student.Age > 14 && student.Age < 21
//                    select new Student
//                    {
//                        StudentID = student.StudentID,
//                        StudentName = student.StudentName,
//                        Age = student.Age
//                    }).ToList();
//foreach (var student in filterResult)
//{
//    Console.WriteLine(student.StudentName);
//}

////method syntax
//var filterResult2 = studentList.Where(student => student.Age == 13 || student.Age == 21).ToList();
//foreach (var student in filterResult2)
//{
//    Console.WriteLine(student.StudentName);
//}

#endregion

// --------------------------------------------------------------------

#region oftype

//List<object> dataSource = new List<object>() { "Sajid", "Mahboob", "Upal", 1, 2, 3, 4 };

//var querySyntax = (from obj in dataSource
//                  where obj is string
//                  select obj).ToList();

//var methodSyntax = dataSource.OfType<int>().Where(obj => obj >= 2).ToList();

//foreach (var obj in methodSyntax)
//{
//    Console.WriteLine(obj);
//}

#endregion

// --------------------------------------------------------------------

#region orderby,thenby

//List<object> dataSource = new List<object>() { "Sajid", "Mahboob", "Upal", 1, 2, 3, 4 };

//var querySyntax = from student in studentList
//                  where student.Age > 18
//                  orderby student.Age descending
//                  select student;
//var querySyntax = from student in studentList
//                  orderby student.StudentName, student.Age descending
//                  select student;
// var querySyntax = from student in studentList
//                  where student.Age > 18
//                  orderby student.Age
//                  select student;

// var methodSyntax = studentList.Where(student => student.Age > 18).OrderBy(student => student.Age).ToList();
// var methodSyntax = studentList.Where(student => student.Age > 18).OrderByDescending(student => student.Age).ToList();
//var methodSyntax = studentList.OrderByDescending(student => student.StudentName).ThenByDescending(student => student.Age).ToList();

//foreach (var obj in methodSyntax)
//{
//    Console.WriteLine(obj.StudentID + "-> " + obj.StudentName + "-> " + obj.Age);
//}

#endregion

#region All

var allResult = studentList.Where(std => std.ProgrammingLanguages.All(lang => lang.Technology == "Linq"));
var allResult2 = studentList.All(std=> std.Age <= 13);

Console.WriteLine("hola");

#endregion

#region Any

var anyResult = studentList.Where(std => std.ProgrammingLanguages.Any(lang => lang.Technology == "Linq"));
var anyResult2 = studentList.Any(std=> std.Age == 21);

Console.WriteLine("hola");
#endregion
