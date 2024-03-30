using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Data.Entities
{
    public class Worker : IIdentifiable
	{
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string PesonalIndentificationNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
    }
}
