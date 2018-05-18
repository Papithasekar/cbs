/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Project
{
    public class UpdateProjectHealthRiskThresholdValidator : CommandInputValidatorFor<UpdateProjectHealthRiskThreshold>
    {
        public UpdateProjectHealthRiskThresholdValidator()
        {
            RuleFor(v => v.Threshold).GreaterThan(0).WithMessage("The threshold can not be zero or negative");
        }
    }
}