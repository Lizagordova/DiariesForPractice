using DiariesForPractice.Domain.Services.Diaries;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiariesForPractice.MailWorker.Services
{
    public class MailRecipientService
    {
        private readonly IDiariesEditorService _diaryEditor;

        public MailRecipientService(
            IDiariesEditorService diariesEditor
            )
        {
            _diaryEditor = diariesEditor;
        }

        public void GetMail()
        {
            var client = new Pop3Client();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate("elizavetagordova1@gmail.com", "uav7bha2309");//todo: это тоже лучше из конфига 
            var count = client.GetMessageCount();
            var message = client.GetMessage(count);
            Console.WriteLine(message.Headers.Subject);
        }
    }
}
