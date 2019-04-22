using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingVisits
{
    public class Visit
    {
        public Guid Id { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime? DateOut { get; set; }  // "?" признак "можно хранить NULL" в поле DateOut
        public String Fio { get; set; }
        public String Document { get; set; }
        public String Purpose { get; set; }

        public Visit()
        {
            Id = Guid.NewGuid();
        }

    }
}
