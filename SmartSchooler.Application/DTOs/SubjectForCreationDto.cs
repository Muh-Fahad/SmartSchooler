using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchooler.Application.DTOs
{
    public class SubjectForCreationDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
