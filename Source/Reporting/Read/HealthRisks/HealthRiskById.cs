using System;
using System.Linq;
using Concepts;
using Concepts.HealthRisk;
using Dolittle.Queries;

namespace Read.HealthRisks
{
    public class HealthRiskById : IQueryFor<HealthRisk>
    {
        private readonly IHealthRisks _collection;

        public HealthRiskId HealthRiskId { get; set; }

        public HealthRiskById(IHealthRisks collection)
        {
            _collection = collection;
        }

        public IQueryable<HealthRisk> Query => _collection.Query.Where(h => h.Id == HealthRiskId);
    }
}