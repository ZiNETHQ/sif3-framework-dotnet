/*
 * Copyright 2016 Systemic Pty Ltd
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

    public static class MapperFactory
    {
        private static MapperConfiguration mapperConfiguration;
        private static IMapper mapper;

        static MapperFactory()
        {
            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SifFrameworkProfile>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            mapper = mapperConfiguration.CreateMapper();
        }

        public static D CreateInstance<S, D>(S source)
        {

            var types = mapperConfiguration.GetAllTypeMaps();

            D destination = default(D);
            destination = mapper.Map<D>(source);
            return destination;
        }

        public static ICollection<D> CreateInstances<S, D>(IEnumerable<S> source)
        {
            ICollection<D> destination = null;
            destination = mapper.Map<IEnumerable<S>, ICollection<D>>(source);
            return destination;
        }

    }

}
