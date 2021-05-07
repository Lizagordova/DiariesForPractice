using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Services.Diaries;
using DiariesForPractice.MailWorker.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using DiariesForPractice.Domain.Services.Users;

namespace DiariesForPractice.MailWorker.Services
{
    public class MailSenderService
    {
        private readonly IDiariesReaderService _diariesReader;
        private readonly IDiariesEditorService _diariesEditor;
        private readonly IUserReaderService _userReader;
        
        public MailSenderService(
            IUserReaderService userReader,
            IDiariesReaderService diariesReader,
            IDiariesEditorService diariesEditor)
        {
            _diariesReader = diariesReader;
            _diariesEditor = diariesEditor;
            _userReader = userReader;
        }

        public void SendDiaries()
        {
            var diaries = GetDiaries();
            var students = GetStudentsForDiaries(diaries);
            AddStudentsForDiaries(diaries, students);
            SendDiariesToStudents(diaries);
        }

        private IReadOnlyCollection<Diary> GetDiaries()
        {
            var query = new DiaryQuery()
            {
                Generated = true
            };
            var neccessaryDiaries = new List<Diary>();
            var diaries = _diariesReader.GetDiaries(query);
            foreach(var diary in diaries)//todo: говно какое, мне не нравится
            {
                if(diary.Send && !diary.Perceived && diary.SendTime.AddDays(ConfigurationHelper.AllowedTimeInterval) > new DateTime())
                {
                    neccessaryDiaries.Add(diary);
                }
            }

            return neccessaryDiaries;
        }
        private IReadOnlyCollection<User> GetStudentsForDiaries(IReadOnlyCollection<Diary> diaries)
        {
            var studentsIds = diaries.Select(p => p.Student.Id).ToList();
            var students = _userReader.GetUsersByIds(studentsIds);

            return students;
        }

        private void AddStudentsForDiaries(IReadOnlyCollection<Diary> diaries, IReadOnlyCollection<User> students)
        {
            diaries.Join(students,
                p => p.Student.Id,
                s => s.Id,
                (p, s) => p.Student = s)
                .ToList();
        }

        private void SendDiariesToStudents(IReadOnlyCollection<Diary> diaries)
        {
             var from = new MailAddress("elizavetagordova1@gmail.com", "Lizonka");//todo: это лучше из конфига брать
            foreach(var diary in diaries)
            {
                SendMessage(diary, from);
                Thread.Sleep(5000);//todo: тоже из конфига можно
            }
        }
        
        private void SendMessage(Diary diary, MailAddress from)
        {
            var to = new MailAddress(diary.Student.Email);
            var message = GenerateMailMessage(diary, from, to);
            var smtp = new SmtpClient("smtp.gmail.com", 587);//todo: возможно разные порты понадобятся
            smtp.Credentials = new NetworkCredential("elizavetagordova1@gmail.com", "Uav7bha2309");//todo: это лучше из конфига брать
            smtp.EnableSsl = true;
            smtp.Send(message);
            UpdateDiaryAfterSendingAMessage(diary);
        }

        private MailMessage GenerateMailMessage(Diary diary, MailAddress from, MailAddress to)
        {
            var message = new MailMessage(from, to);
            message.Subject = "Дневник по практике";//todo: это лучше из конфига брать
            message.Body = GenerateLetterText(diary);
            message.IsBodyHtml = true;

            return message;
        }

        private string GenerateLetterText(Diary diary)
        {
            var message = $"Дорогой (-ая) {diary.Student.FirstName} {diary.Student.SecondName} {diary.Student.LastName}\n\n";
            message += $"Твой дневник по практике располагается по адресу: {diary.Path}\n";
            message += $"Если есть какая-то ошибка, то ответьте, пожалуйста, на этот адрес";

            return message;
        }

        private void UpdateDiaryAfterSendingAMessage(Diary diary)
        {
            diary.Send = true;
            diary.SendTime = new DateTime();
            _diariesEditor.AddOrUpdateDiary(diary);
        }
    }
}
