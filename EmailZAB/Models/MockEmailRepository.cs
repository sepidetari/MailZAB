using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailZAB.Models
{
    public class MockEmailRepository : IEmailRepository
    {
        private List<Email> _emailList;
        public MockEmailRepository()
        {
            _emailList = new List<Email>() {
                new Email() {EmailId= 1, Sender= "Sep@gmail.com", Receiver = "Sup@gmail.com", Subject="greeting", HtmlMessage = "No message"}, 
                new Email() {EmailId= 2, Sender= "eps@gmail.com", Receiver = "pud@gmail.com", Subject="thing", HtmlMessage = "No message"} 

            };

        }

        public IEnumerable<Email> GetAllEmails()
        {
            return _emailList;
        }

        public Email GetEmail(int Id)
        {
            return _emailList.FirstOrDefault(e => e.EmailId == Id);
        }
    }
}
