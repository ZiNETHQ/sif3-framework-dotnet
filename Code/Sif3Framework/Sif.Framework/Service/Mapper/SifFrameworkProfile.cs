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
using Sif.Framework.Model.Requests;
using Sif.Framework.Model.Responses;
using Sif.Framework.Utils;
using Sif.Specification.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml;
using Environment = Sif.Framework.Model.Infrastructure.Environment;

namespace Sif.Framework.Service.Mapper
{
    internal class SifFrameworkProfile : Profile
    {
        public SifFrameworkProfile()
        {
            CreateMap<ApplicationInfo, applicationInfoType>();
            CreateMap<applicationInfoType, ApplicationInfo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<InfrastructureService, infrastructureServiceType>()
                .ForMember(dest => dest.nameSpecified, opt => opt.UseValue<bool>(true))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name));
            CreateMap<infrastructureServiceType, InfrastructureService>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));
            CreateMap<infrastructureServiceType[], IDictionary<InfrastructureServiceNames, InfrastructureService>>()
                .ConvertUsing<InfrastructureServicesConverter>();

            CreateMap<Environment, environmentType>()
                .ForMember(dest => dest.infrastructureServices, opt => opt.MapFrom(src => src.InfrastructureServices.Values))
                .ForMember(dest => dest.provisionedZones, opt => opt.MapFrom(src => src.ProvisionedZones.Values))
                .ForMember(dest => dest.typeSpecified, opt => opt.UseValue<bool>(true));
            CreateMap<environmentType, Environment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => StringUtils.IsEmpty(src.id) ? Guid.Empty : Guid.Parse(src.id)));

            CreateMap<ProductIdentity, productIdentityType>();
            CreateMap<productIdentityType, ProductIdentity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Property, propertyType>();
            CreateMap<propertyType, Property>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<propertyType[], IDictionary<string, Property>>()
                .ConvertUsing<PropertiesConverter>();

            CreateMap<ProvisionedZone, provisionedZoneType>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.SifId));
            CreateMap<provisionedZoneType, ProvisionedZone>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SifId, opt => opt.MapFrom(src => src.id));
            CreateMap<provisionedZoneType[], IDictionary<string, ProvisionedZone>>()
                .ConvertUsing<ProvisionedZonesConverter>();

            CreateMap<Right, rightType>();
            CreateMap<rightType, Right>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<rightType[], IDictionary<string, Right>>()
                .ConvertUsing<RightsConverter>();

            CreateMap<Model.Infrastructure.Service, serviceType>()
                .ForMember(dest => dest.rights, opt => opt.MapFrom(src => src.Rights.Values));
            CreateMap<serviceType, Model.Infrastructure.Service>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Zone, zoneType>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.SifId))
                .ForMember(dest => dest.properties, opt => opt.MapFrom(src => src.Properties.Values));
            CreateMap<zoneType, Zone>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SifId, opt => opt.MapFrom(src => src.id));

            CreateMap<PhaseState, stateType>()
                .ForMember(dest => dest.createdSpecified, opt => opt.MapFrom(src => src.Created != null))
                .ForMember(dest => dest.lastModifiedSpecified, opt => opt.MapFrom(src => src.LastModified != null));
            CreateMap<stateType, PhaseState>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => StringUtils.IsEmpty(src.id) ? Guid.Empty : Guid.Parse(src.id)));
            CreateMap<stateType[], IList<PhaseState>>()
                .ConvertUsing<StatesConverter>();

            CreateMap<Phase, phaseType>()
                .ForMember(dest => dest.rights, opt => opt.MapFrom(src => src.Rights.Values))
                .ForMember(dest => dest.statesRights, opt => opt.MapFrom(src => src.StatesRights.Values));
            CreateMap<phaseType, Phase>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<phaseType[], IDictionary<string, Phase>>()
                .ConvertUsing<PhasesConverter>();

            CreateMap<Job, jobType>()
                .ForMember(dest => dest.phases, opt => opt.MapFrom(src => src.Phases.Values))
                .ForMember(dest => dest.createdSpecified, opt => opt.MapFrom(src => src.Created != null))
                .ForMember(dest => dest.lastModifiedSpecified, opt => opt.MapFrom(src => src.LastModified != null))
                .ForMember(dest => dest.stateSpecified, opt => opt.MapFrom(src => src.State != null))
                .ForMember(dest => dest.timeout, opt => opt.MapFrom(src => XmlConvert.ToString(src.Timeout)));
            CreateMap<jobType, Job>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => StringUtils.IsEmpty(src.id) ? Guid.Empty : Guid.Parse(src.id)))
                .ForMember(dest => dest.Timeout, opt => opt.MapFrom(src => XmlConvert.ToTimeSpan(src.timeout)));

            CreateMap<ResponseError, errorType>();
            CreateMap<errorType, ResponseError>();

            CreateMap<CreateStatus, createType>();
            CreateMap<createType, CreateStatus>();

            CreateMap<DeleteStatus, deleteStatus>();
            CreateMap<deleteStatus, DeleteStatus>();

            CreateMap<UpdateStatus, updateType>();
            CreateMap<updateType, UpdateStatus>();

            CreateMap<MultipleCreateResponse, createResponseType>()
                .ForMember(dest => dest.creates, opt => opt.MapFrom(src => src.StatusRecords));
            CreateMap<createResponseType, MultipleCreateResponse>()
                .ForMember(dest => dest.StatusRecords, opt => opt.MapFrom(src => src.creates));

            CreateMap<MultipleDeleteResponse, deleteResponseType>()
                .ForMember(dest => dest.deletes, opt => opt.MapFrom(src => src.StatusRecords));
            CreateMap<deleteResponseType, MultipleDeleteResponse>()
                .ForMember(dest => dest.StatusRecords, opt => opt.MapFrom(src => src.deletes));

            CreateMap<MultipleUpdateResponse, updateResponseType>()
                .ForMember(dest => dest.updates, opt => opt.MapFrom(src => src.StatusRecords));
            CreateMap<updateResponseType, MultipleUpdateResponse>()
                .ForMember(dest => dest.StatusRecords, opt => opt.MapFrom(src => src.updates));

            CreateMap<deleteIdType[], ICollection<string>>()
                .ConvertUsing<DeleteIdsConverter>();

            CreateMap<deleteRequestType, MultipleDeleteRequest>()
                .ForMember(dest => dest.RefIds, opt => opt.MapFrom(src => src.deletes));
        }
    }
}