﻿/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class CaseReportForListing extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: 'ae0ce1c9-9f27-47a3-a21e-e584483e2cb6',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.extraElements = [];
        this.status = {};
        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.dataCollectorDisplayName = '';
        this.dataCollectorRegion = '';
        this.dataCollectorDistrict = '';
        this.dataCollectorVillage = '';
        this.healthRiskId = '00000000-0000-0000-0000-000000000000';
        this.healthRisk = '';
        this.message = '';
        this.numberOfMalesUnder5 = 0;
        this.numberOfMalesAged5AndOlder = 0;
        this.numberOfFemalesUnder5 = 0;
        this.numberOfFemalesAged5AndOlder = 0;
        this.timestamp = new Date();
        this.location = {};
        this.origin = '';
        this.parsingErrorMessage = [];
    }
}