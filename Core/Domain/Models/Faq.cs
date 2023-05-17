using System;
using TemplateFwExample.Shared.Domain.Interfaces;

#nullable disable

namespace TemplateFwExample.Domain.Models
{
    /// <summary>
    /// Represents a Frequently Asked Question (FAQ).
    /// </summary>
    public partial class Faq : IAgregateEntity
    {
        /// <summary>
        /// Initializes a new instance of the Faq class.
        /// </summary>
        public Faq()
        {
        }

        /// <summary>
        /// Gets or sets the unique identifier of the FAQ.
        /// </summary>
        public int FaqId { get; set; }

        /// <summary>
        /// Gets or sets the question in Arabic language.
        /// </summary>
        public string QuestionAr { get; set; }

        /// <summary>
        /// Gets or sets the question in English language.
        /// </summary>
        public string QuestionEn { get; set; }

        /// <summary>
        /// Gets or sets the answer in Arabic language.
        /// </summary>
        public string AnswerAr { get; set; }

        /// <summary>
        /// Gets or sets the answer in English language.
        /// </summary>
        public string AnswerEn { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the portal associated with the FAQ.
        /// </summary>
        public int PortalId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the service associated with the FAQ. It can be null.
        /// </summary>
        public int? ServiceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the FAQ is available.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the name or identifier of the user who created the FAQ.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the creation date and time of the FAQ.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the name or identifier of the user who last modified the FAQ.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the last modification date and time of the FAQ. It can be null.
        /// </summary>
        public DateTime? LastModificationDate { get; set; }

        /// <summary>
        /// Gets or sets the associated portal entity.
        /// </summary>
        public virtual Portal Portal { get; set; }
    }

}
