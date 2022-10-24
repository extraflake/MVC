using System;
using System.Collections.Generic;
using System.Text;

namespace MCC71.Models
{
    public class Division
    {
        public Division(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public enum Gender
        {
            Laki,
            Perempuan
        }

        public enum Status
        {
            Pending = 10, 
            OnProgress = 20,
            Done = 30
        }
    }
}
