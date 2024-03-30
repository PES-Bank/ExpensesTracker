using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Projections.Workers
{
    public record WorkerGeneralInfoProjection
    {
        public required Guid Id { get; init; }

        public required string Name { get; init; }
        public required string LastName { get; init; }
        public required string PesonalIndentificationNumber { get; init; }
        public required string DateOfBirth { get; init; }
        public required string Position { get; init; }
        public required string PhoneNumber { get; init; }
    }
}
