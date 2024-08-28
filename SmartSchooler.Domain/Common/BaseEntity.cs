﻿using SmartSchooler.Domain.Common.Interfaces;

namespace SmartSchooler.Domain.Common
{
    public abstract class BaseEntity : IAuditableEntity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
