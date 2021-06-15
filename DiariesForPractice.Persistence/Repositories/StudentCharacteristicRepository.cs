using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
    public class StudentCharacteristicRepository : IStudentCharacteristicRepository
    {
        private readonly string AddOrUpdateStudentCharacteristicSp = "StudentCharacteristicRepository_AddOrUpdateStudentCharacteristic";
        private readonly string GetStudentCharacteristicSp = "StudentCharacteristicRepository_GetStudentCharacteristic";
        private readonly MapperService _mapper;
        public StudentCharacteristicRepository(
            MapperService mapper)
        {
            _mapper = mapper;
        }
        
        public int AddOrUpdateStudentCharacteristic(StudentCharacteristic studentCharacteristic, int practiceDetailsId)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetStudentCharacteristicParam(studentCharacteristic, practiceDetailsId);
            var studentId = conn
                .Query<int>(AddOrUpdateStudentCharacteristicSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return studentId;
        }

        public StudentCharacteristic GetStudentCharacteristic(int studentId)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetStudentParam(studentId);
            var studentCharacteristicUdt = conn
                .Query<StudentCharacteristicUdt>(GetStudentCharacteristicSp, param,
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            var studentCharacteristic =
                _mapper.Map<StudentCharacteristicUdt, StudentCharacteristic>(studentCharacteristicUdt);
            DatabaseHelper.CloseConnection(conn);

            return studentCharacteristic;
        }

        private DynamicTvpParameters GetStudentCharacteristicParam(StudentCharacteristic studentCharacteristic, int practiceDetailsId)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("studentCharacteristic", "UDT_StudentCharacteristic");
            var udt = _mapper.Map<StudentCharacteristic, StudentCharacteristicUdt>(studentCharacteristic);
            tvp.AddObjectAsRow(udt);
            param.Add(tvp);
            param.Add("practiceDetailsId", practiceDetailsId);
            
            return param;
        }

        private DynamicTvpParameters GetStudentParam(int studentId)
        {
            var param = new DynamicTvpParameters();
            param.Add("studentId", studentId);
            
            return param;
        }
    }
}