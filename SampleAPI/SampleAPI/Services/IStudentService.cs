using SampleAPI.DTOs.Requests;
using SampleAPI.DTOs.Responses;

namespace SampleAPI.Services
{
    public interface IStudentService
    {
        BaseResponse CreateStudent(CreateStudentRequest request);

        BaseResponse StudentList();

        BaseResponse GetStudentById(int id);

        BaseResponse UpdateStudentById(int id,UpdateStudentRequest request);

        public BaseResponse DeleteStudentById(int id);

    }
}
