using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InitEntity.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Client()
        {
        }
        
    }
}