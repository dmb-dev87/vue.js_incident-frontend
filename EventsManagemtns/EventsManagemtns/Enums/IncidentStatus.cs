using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsManagemtns.Enums
{
    public class Enums
    {
        public enum IncidentStatus
        {
            New = 1,
            Closed = 2,
            InProgress = 3
        }
        public enum Urgancey
        {
            Normal = 1,
            Urgent = 2,
            VeryUrgent = 3
        }

        public enum Category
        {
            HssanTarwada = 1,
            TaatelKhedma = 2,
            GehaMotaasra = 3,
            Egraa = 4
        }

        public enum Sverity
        {
            Fifth = 1,
            Forth = 2,
            Third = 3,
            Second = 4,
            First = 5
        }

    }
}
