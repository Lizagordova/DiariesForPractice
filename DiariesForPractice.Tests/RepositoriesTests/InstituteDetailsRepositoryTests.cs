using System;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;
using NUnit.Framework;

namespace DiariesForPractice.Tests.RepositoriesTests
{
    [TestFixture]
    public class InstituteDetailsRepositoryTests
    {
        private readonly InstituteDetailsRepository _instituteDetailsRepository;

        public InstituteDetailsRepositoryTests()
        {
            var mapperService = new MapperService();
            _instituteDetailsRepository = new InstituteDetailsRepository(mapperService);
        }

        [Test]
        public void AddOrUpdateInstitute_Expected_Result()
        {
            var institute = new Institute()
            {
                Name = "ИНМИН"
            };
            var instituteId = _instituteDetailsRepository.AddOrUpdateInstitute(institute);
            var result = instituteId != 0;
            Console.WriteLine(instituteId);
            Assert.That(result == true);
        }
        
        [Test]
        public void AddOrUpdateCafedra_Expected_Result()
        {
            var cafedra = new Cafedra()
            {
                InstituteId = 2,
                Name = "Кафедра физики"
            };
            var cafedraId = _instituteDetailsRepository.AddOrUpdateCafedra(cafedra);
            var result = cafedraId != 0;
            Console.WriteLine($"cafedraId={cafedraId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void AddOrUpdateDirection_Expected_Result()
        {
            var direction = new Direction()
            {
                CafedraId = 6,
                Name = "03.03.02 - Физика"
            };
            var directionId = _instituteDetailsRepository.AddOrUpdateDirection(direction);
            var result = directionId != 0;
            Console.WriteLine($"directionId={directionId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void AddOrUpdateDegree_Expected_Result()
        {
            var degree = new Degree()
            {
                Name = "Магистратура"
            };
            var degreeId = _instituteDetailsRepository.AddOrUpdateDegree(degree);
            var result = degreeId != 0;
            Console.WriteLine($"degreeId={degreeId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void AddOrUpdateCourse_Expected_Result()
        {
            var course = new Course()
            {
                Name = "1"
            };
            var courseId = _instituteDetailsRepository.AddOrUpdateCourse(course, 2);
            var result = courseId != 0;
            Console.WriteLine($"courseId={courseId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void AddOrUpdateGroup_Expected_Result()
        {
            var group = new Group()
            {
                DirectionId= 1,
                CourseId = 1,
                Name = "БИВТ-17-2"
            };
            var groupId = _instituteDetailsRepository.AddOrUpdateGroup(group);
            var result = groupId != 0;
            Console.WriteLine($"groupId={groupId}");
            Assert.That(result == true);
        }

        [Test]
        public void GetInstitutes()
        {
            var institutes = _instituteDetailsRepository.GetInstitutes();
            foreach (var institute in institutes)
            {
                Console.WriteLine($"Id={institute.Id}; Name={institute.Name}");
            }
        }
        
        [Test]
        public void GetCafedras()
        {
            var cafedras = _instituteDetailsRepository.GetCafedras(1);
            foreach (var cafedra in cafedras)
            {
                Console.WriteLine($"Id={cafedra.Id}; Name={cafedra.Name}");
            }
        }
        
        [Test]
        public void GetDirections()
        {
            var cafedras = _instituteDetailsRepository.GetDirections(1);
            foreach (var cafedra in cafedras)
            {
                Console.WriteLine($"Id={cafedra.Id}; Name={cafedra.Name}");
            }
        }
        
        [Test]
        public void GetCourses()
        {
            var courses = _instituteDetailsRepository.GetCourses(2);
            foreach (var course in courses)
            {
                Console.WriteLine($"Id={course.Id}; Name={course.Name}");
            }
        }
        
        [Test]
        public void GetGroups()
        {
            var groups = _instituteDetailsRepository.GetGroups();
            foreach (var group in groups)
            {
                Console.WriteLine($"Id={group.Id}; Name={group.Name}; CourseId={group.CourseId}");
                Console.WriteLine("================STUDENTS================");
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"Id={student.Id}; Name={student.FullName}");
                }
                Console.WriteLine("================GroupDetails================");
                Console.WriteLine($"Id={group.GroupDetails.Id}; Name={group.GroupDetails.NumberRegisteredStudents}");
                Console.WriteLine("============================================");
            }
        }
        
        [Test]
        public void GetDegrees()
        {
            var degrees = _instituteDetailsRepository.GetDegrees();
            foreach (var degree in degrees)
            {
                Console.WriteLine($"Id={degree.Id}; Name={degree.Name}");
                foreach (var course in degree.Courses)
                {
                    Console.WriteLine($"Id={course.Id}, Name={course.Name}");
                }
            }
            Console.WriteLine("================================");
        }

        [Test]
        public void GetInstitute()
        {
            var institute = _instituteDetailsRepository.GetInstitute(1);
            Console.WriteLine($"Id={institute.Id}, Name={institute.Name}");
        }
        
        [Test]
        public void GetCafedra()
        {
            var cafedra = _instituteDetailsRepository.GetCafedra(1);
            Console.WriteLine($"Id={cafedra.Id}, Name={cafedra.Name}");
        }
        
        [Test]
        public void GetDirection()
        {
            var direction = _instituteDetailsRepository.GetDirection(1);
            Console.WriteLine($"Id={direction.Id}, Name={direction.Name}");
        }
        
        [Test]
        public void GetCourse()
        {
            var course = _instituteDetailsRepository.GetCourse(1);
            Console.WriteLine($"Id={course.Id}, Name={course.Name}");
        }
        
        [Test]
        public void GetDegree()
        {
            var degree = _instituteDetailsRepository.GetDegree(1);
            Console.WriteLine($"Id={degree.Id}, Name={degree.Name}");
        }
        
        [Test]
        public void GetGroup()
        {
            var group = _instituteDetailsRepository.GetGroup(1);
            Console.WriteLine($"Id={group.Id}, Name={group.Name}");
        }
        
        [Test]
        public void AttachStudentToGroup()
        {
            _instituteDetailsRepository.AttachStudentToGroup(9, 1);
        }
    }
}