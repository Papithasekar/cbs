using Dolittle.Domain;
using Dolittle.Events.Processing;
using Domain;
using Read.CaseReports;
using Read.DataCollectors;
using Read.InvalidCaseReports;
using Concepts.CaseReport;
using Concepts.DataCollector;
using Domain.CaseReports;
using Events.DataCollectors.PhoneNumber;

namespace Policy
{
    public class CaseReportIdentification : ICanProcessEvents
    {
        readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingAggregateRootRepository;
        readonly ICaseReportsFromUnknownDataCollectors _unknownReports;
        readonly IInvalidCaseReportsFromUnknownDataCollectors _invalidAndUnknownReports;
        readonly IDataCollectors _dataCollectors;

        public CaseReportIdentification(
            IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregateRootRepository,
            ICaseReportsFromUnknownDataCollectors unknownReports,
            IInvalidCaseReportsFromUnknownDataCollectors invalidAndUnknownReports,
            IDataCollectors dataCollectors)
        {
            _caseReportingAggregateRootRepository = caseReportingAggregateRootRepository;
            _unknownReports = unknownReports;
            _invalidAndUnknownReports = invalidAndUnknownReports;
            _dataCollectors = dataCollectors;
        }
        [EventProcessor("477d2b8e-41cb-4746-9870-e7a8b2012997")]
        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            
            var unknownReports = this._unknownReports.GetByPhoneNumber(@event.PhoneNumber);
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId); 
            foreach (var item in unknownReports)
            {
                var repo = _caseReportingAggregateRootRepository.Get(item.Id.Value);
                repo.Report(
                    @event.DataCollectorId,
                    item.HealthRiskId,
                    item.Origin,
                    item.NumberOfMalesUnder5,
                    item.NumberOfMalesAged5AndOlder,
                    item.NumberOfFemalesUnder5,
                    item.NumberOfFemalesAged5AndOlder,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    item.Timestamp,
                    item.Message
                    
                    );
                repo.ReportFromUnknownDataCollectorIdentiefied(@event.DataCollectorId);
            } 
            
            
            var invalidAndUnknownReports = this._invalidAndUnknownReports.GetByPhoneNumber(@event.PhoneNumber);
            foreach (var item in invalidAndUnknownReports)
            {
                var repo = _caseReportingAggregateRootRepository.Get(item.Id.Value);
                repo.ReportInvalidReport(
                    @event.DataCollectorId,
                    item.PhoneNumber,
                    item.Message,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    item.ParsingErrorMessage,
                    item.Timestamp
                    
                    );
                repo.ReportFromUnknownDataCollectorIdentiefied(@event.DataCollectorId);
            }
        }
    }
}
