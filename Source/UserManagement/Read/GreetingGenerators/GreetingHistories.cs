using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class GreetingHistories : ExtendedReadModelRepositoryFor<GreetingHistory>,
        IGreetingHistories
    {

        public GreetingHistories(IMongoDatabase database) 
            : base(database, database.GetCollection<GreetingHistory>("GreetingHistories"))
        {
        }

        public IEnumerable<GreetingHistory> GetAll()
        {
            return GetMany(_ => true);
        }

        public Task<IEnumerable<GreetingHistory>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }

        public GreetingHistory GetById(Guid id)
        {
            return GetOne(d => d.DataCollectorId == id);
        }

        public Task<GreetingHistory> GetByIdAsync(Guid id)
        {
            return GetOneAsync(d => d.DataCollectorId == id);
        }

        public GreetingHistory GetByPhoneNumber(string phoneNumber)
        {
            return GetOne(d => d.PhoneNumber == phoneNumber);
        }

        public Task<GreetingHistory> GetByPhoneNumberAsync(string phoneNumber)
        {
            return GetOneAsync(d => d.PhoneNumber == phoneNumber);
        }

        public void Remove(string phoneNumber)
        {
            _collection.DeleteMany(g => g.PhoneNumber == phoneNumber);
        }

        public Task RemoveAsync(string phoneNumber)
        {
            return DeleteManyAsync(g => g.PhoneNumber == phoneNumber);
        }
    }
}
