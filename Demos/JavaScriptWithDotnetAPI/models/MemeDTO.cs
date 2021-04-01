using System;
using System.Collections.Generic;

namespace models
{
    public class MemeDTO
    {
        public string MemeString { get; set; }
        public Guid MemeId { get; set; } = Guid.NewGuid();
        public DateTime UploadDate { get; set; } = new DateTime();
        public Guid PersonId { get; set; }// these together define the 1-many relationship
    }
}