using System;
using TemplateFwExample.Utilities.Helpers;

namespace TemplateFwExample.Dtos.Views
{

    public class ItemModificationDto
    {
        public string CreationAt {
            get {
                return CreationDate.ConvertToDashboardInputTextDateTime();
            }
        }

        public string ModificationBy {
            get {
                if (string.IsNullOrEmpty(LastModifiedBy))
                    return "";
                return LastModifiedBy;
            }
        }

        public string ModificationAt {
            get {
                if (LastModificationDate == null)
                    return "";
                return LastModificationDate.Value.ConvertToDashboardInputTextDateTime();
            }
        }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }

        public string LastActivationBy { get; set; }
        public DateTime? LastActivationDate { get; set; }
        public string LastDectivationBy { get; set; }
        public DateTime? LastDectivationDate { get; set; }
        public bool ShowTitleReplyBy { get; set; }
    }

}
