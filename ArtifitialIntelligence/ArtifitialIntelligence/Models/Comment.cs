using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtifitialIntelligence.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

      
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        public Guid GuestId { get; set; }
        public string CommentDescription { get; set; }
        public int Rating { get; set; }
        public DateTime CommentedOn { get; set; }

    }
}
