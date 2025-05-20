using Microsoft.AspNetCore.Http.HttpResults;
using SampleAPI.DTOs;
using SampleAPI.DTOs.Requests;
using SampleAPI.DTOs.Responses;
using SampleAPI.Models;

namespace SampleAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext context;
        public StudentService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public BaseResponse CreateStudent(CreateStudentRequest request)
        {
            BaseResponse response;

            try
            {
                StudentModel newStudent = new StudentModel();
                newStudent.Name = request.Name;
                newStudent.Email = request.Email;
                newStudent.DOB = request.DOB;
                newStudent.Gender = request.Gender;

                using (context)
                {
                    context.Add(newStudent);
                    context.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully Created the new student" }
                };
                return response;

            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error : " + ex.Message }
                };

                return response;
            }
        }

        public BaseResponse StudentList()
        {
            BaseResponse response;

            try
            {
                List<StudentDTO> students = new List<StudentDTO>();

                using (context)
                {
                    context.Students.ToList().ForEach(student => students.Add(new StudentDTO
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Email = student.Email,
                        DOB = student.DOB,
                        Gender = student.Gender
                    }));
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { students }
                };
                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "internal server error " + ex.Message }
                };

                return response;
            }
        }

        public BaseResponse GetStudentById(int id)
        {
            BaseResponse response;

            try
            {
                StudentDTO student = new StudentDTO();

                using (context)
                {
                    StudentModel filteredStudent = context.Students.Where(student => student.Id == id).FirstOrDefault();

                    if (filteredStudent != null)
                    {
                        student.Id = filteredStudent.Id;
                        student.Name = filteredStudent.Name;
                        student.Email = filteredStudent.Email;
                        student.DOB = filteredStudent.DOB;
                        student.Gender = filteredStudent.Gender;
                    }
                    else
                    {
                        student = null;
                    }
                }
                if (student == null)
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { student }
                    };
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new { message = "No Student found" }
                    };
                }
                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Interal Server Error" + ex.Message }
                };

                return response;
            }
        }

        public BaseResponse UpdateStudentById(int id, UpdateStudentRequest request)
        {
            BaseResponse response;

            try
            {
                using (context)
                {
                    StudentModel filteredStudent = context.Students.Where(student => student.Id == id).FirstOrDefault();

                    if (filteredStudent != null)
                    {
                        filteredStudent.Name = request.Name;
                        filteredStudent.Email = request.Email;
                        filteredStudent.DOB = request.DOB;
                        filteredStudent.Gender = request.Gender;

                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Student Update Successfully" }

                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No student found" }
                        };

                    }
                }
                return response;
            }

            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server error : " + ex.Message }
                };
                return response;
            }
        }

        public BaseResponse DeleteStudentById(int id)
        {
            BaseResponse response;
            try
            {
                using (context)
                {
                    StudentModel studentToDelete = context.Students.Where(student => student.Id == id).FirstOrDefault();
                    if (studentToDelete != null)
                    {
                        context.Students.Remove(studentToDelete);
                        context.SaveChanges();

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = "Student deleted successfully" }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = "No student found" }
                        };
                    }
                    return response;

                }
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error..." + ex.Message }
                };
                return response;
            }

        }
    }
}