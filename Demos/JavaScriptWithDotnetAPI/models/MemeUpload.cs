using System;
using Microsoft.AspNetCore.Http;

namespace models
{
    public class MemeUpload
    {
        public Guid PersonId { get; set; }
        public byte[] Meme { get; set; }
    }
}