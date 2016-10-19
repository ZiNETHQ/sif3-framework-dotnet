/*
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

namespace Sif.Framework.Service.Mapper
{
    public class InfrastructureServicesConverter : ITypeConverter<infrastructureServiceType[], IDictionary<InfrastructureServiceNames, InfrastructureService>>
    {
        public IDictionary<InfrastructureServiceNames, InfrastructureService> Convert(infrastructureServiceType[] source, IDictionary<InfrastructureServiceNames, InfrastructureService> destination, ResolutionContext context)
        {
            ICollection<InfrastructureService> values = context.Mapper.Map<infrastructureServiceType[], ICollection<InfrastructureService>>(source);
            IDictionary<InfrastructureServiceNames, InfrastructureService> infrastructureServices = new Dictionary<InfrastructureServiceNames, InfrastructureService>();

            foreach (InfrastructureService infrastructureService in values)
            {
                infrastructureServices.Add(infrastructureService.Name, infrastructureService);
            }

            return infrastructureServices;
        }
    }
}
