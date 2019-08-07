using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailZAB.Models
{
    public interface IEmailRepository
    {
        Email GetEmail(int Id);
        IEnumerable<Email> GetAllEmails();
    }
}
