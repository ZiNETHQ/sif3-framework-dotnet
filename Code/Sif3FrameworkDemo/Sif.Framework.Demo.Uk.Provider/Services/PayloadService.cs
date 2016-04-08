﻿/*
 * Crown Copyright © Department for Education (UK) 2016
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Sif.Framework.Demo.Uk.Provider.Actions;
using Sif.Framework.Model.Infrastructure;
using Sif.Framework.Service.Functional;
using System;
using System.Collections.Generic;

namespace Sif.Framework.Demo.Uk.Provider.Services
{

    public class PayloadService : BasicFunctionalService
    {
        public PayloadService() : base()
        {
            phaseActions.Add("default", new DefaultActions());
            phaseActions.Add("xml", new XmlActions());
            phaseActions.Add("json", new JsonActions());
        }

        protected override void addPhases(Job job)
        {
            job.addPhase(new Phase("default", true, Right.getRights(create: RightValue.APPROVED, query: RightValue.APPROVED, update: RightValue.APPROVED), PhaseStateType.NOTSTARTED, "A demonstration phase"));

            job.addPhase(new Phase("xml", true, Right.getRights(update: RightValue.APPROVED), PhaseStateType.NOTSTARTED, "A demonstration XML based phase"));

            job.addPhase(new Phase("json", true, Right.getRights(update: RightValue.APPROVED), PhaseStateType.NOTSTARTED, "A demonstration Json based phase"));
        }

        protected override Boolean JobShutdown()
        {
            // Can be used to prevent job deletion
            return true;
        }
    }
}
