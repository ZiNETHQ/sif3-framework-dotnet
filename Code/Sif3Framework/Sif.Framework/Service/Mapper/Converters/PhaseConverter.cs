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

using AutoMapper;
using Sif.Framework.Model.Infrastructure;
using Sif.Specification.Infrastructure;
using System.Collections.Generic;

namespace Sif.Framework.Service.Mapper.Converters
{
    public class PhasesConverter : ITypeConverter<phaseType[], IDictionary<string, Phase>>
    {
        public IDictionary<string, Phase> Convert(phaseType[] source, IDictionary<string, Phase> destination, ResolutionContext context)
        {
            ICollection<Phase> values = context.Mapper.Map<phaseType[], ICollection<Phase>>(source);
            IDictionary<string, Phase> phases = new Dictionary<string, Phase>();

            foreach (Phase phase in values)
            {
                phases.Add(phase.Name, phase);
            }

            return phases;
        }
    }
}