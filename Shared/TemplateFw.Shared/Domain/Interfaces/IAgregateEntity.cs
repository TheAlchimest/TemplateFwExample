using System;

namespace TemplateFwExample.Shared.Domain.Interfaces
{
    public interface IAgregateEntity
    {
        bool IsAvailable { get; set; }
        string CreatedBy { get; set; }
        DateTime CreationDate { get; set; }
        string LastModifiedBy { get; set; }
        DateTime? LastModificationDate { get; set; }

    }
}
