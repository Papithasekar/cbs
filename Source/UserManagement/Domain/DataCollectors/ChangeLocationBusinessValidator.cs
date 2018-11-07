using Concepts.DataCollectors;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.DataCollectors
{
    public class ChangeLocationBusinessValidator : CommandBusinessValidatorFor<ChangeLocation>
    {
        public ChangeLocationBusinessValidator(MustExist beAnActualDataCollector)
        {
            RuleFor(_ => _.DataCollectorId)
                .Must(_ => beAnActualDataCollector(_))
                .WithMessage(_ => $"Data Collector with id {_.DataCollectorId.Value} is not registered");
        }
    }
}