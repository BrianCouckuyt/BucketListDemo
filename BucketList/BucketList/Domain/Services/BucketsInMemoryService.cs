using BucketList.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Domain.Services
{
    public class BucketsInMemoryService
    {
        private static List<Bucket> bucketLists = new List<Bucket> {
            new Bucket
            {
                Id = Guid.NewGuid(),
                OwnerId = Guid.Empty,
                Title = "Mijn Bucketlist",
                Description = "Dingen die ik nog wil gaan doen",
                ImageUrl = null,
                IsFavorite = true,
                BucketItems = new List<BucketItem>{
                    new BucketItem
                    {
                        Id = Guid.NewGuid(),
                        ItemDescription = "Gekaptapulteerd worden",
                        Order = 1
                    },
                    new BucketItem
                    {
                        Id = Guid.NewGuid(),
                        ItemDescription = "Beter framework dan Xamarin uitvinden",
                        Order = 2
                    },
                    new BucketItem
                    {
                        Id = Guid.NewGuid(),
                        ItemDescription = "Zwemmen met haaien",
                        Order = 3
                    }
                }
            }
        };

        public async Task<IEnumerable<Bucket>> GetBucketListsForUser(Guid userid)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            return bucketLists.Where(b => b.OwnerId == userid);
        }

        public async Task<Bucket> GetBucketList(Guid bucketId)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            return bucketLists.FirstOrDefault(b => b.Id == bucketId);
        }

        public async Task SaveBucketList(Bucket bucket)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            var savedbucket = bucketLists.FirstOrDefault(b => b.Id == bucket.Id);
            if(savedbucket == null)
            {
                savedbucket = bucket;
                savedbucket.Id = Guid.NewGuid();
                bucketLists.Add(savedbucket);
            }
            savedbucket = bucket;
        }

        public async Task DeleteBucketList(Guid bucketId)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            var bucket = bucketLists.FirstOrDefault(b => b.Id == bucketId);
            bucketLists.Remove(bucket);
        }
    }
}
