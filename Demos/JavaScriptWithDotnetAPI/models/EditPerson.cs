using System;

namespace models
{
    public class EditPerson
    {
        public string PersonId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string NewPassword { get; set; }
        public string PasswordHash { get; set; }
        public string NewUsername { get; set; }
    }
}