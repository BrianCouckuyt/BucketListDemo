using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BucketList.Domain.Models
{
    public class Bucket
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFavorite { get; set; }
        public ICollection<BucketItem> BucketItems { get; set; }

        public bool IsCompleted => BucketItems.All(i => i.CompletionDate.HasValue);
        public float PercentCompleted
        {
            get
            {
                if (BucketItems?.Count > 0)
                    return BucketItems.Count(i => i.CompletionDate.HasValue) / BucketItems.Count;
                else
                    return 0f;
            }
        }
    }
}
