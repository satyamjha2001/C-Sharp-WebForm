using ModelsInASPCore.Models;

namespace ModelsInASPCore.Repository
{
    public class StudentRepository : IStudent
    {
        public List<StudentModel> getAllStudents()
        {
            List<StudentModel> students = DataSource();

            return students;
        }

        public StudentModel getStudentById(int id)
        {
            return DataSource().First(value => value.Rollno == id);   //linq
        }

        private List<StudentModel> DataSource()
        {
            return new List<StudentModel>
            {
                new StudentModel { Rollno = 1, Name = "Satyam", Gender="Male", Standard = 12},
                new StudentModel { Rollno = 2, Name = "Raj", Gender="Male", Standard = 1},
                new StudentModel { Rollno = 3, Name = "Pratibha", Gender="Female", Standard = 5},
                new StudentModel { Rollno = 4, Name = "Chirag", Gender="male", Standard = 8},
                new StudentModel { Rollno = 5, Name = "Brijmohan", Gender="male", Standard = 1}

            };
        }
    }
}
