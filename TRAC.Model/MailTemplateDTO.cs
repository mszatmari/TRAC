using System;
using System.Diagnostics;

namespace TRAC.Model
{
   
    public class MailTemplateDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string CC { get; set; }
    }
}
