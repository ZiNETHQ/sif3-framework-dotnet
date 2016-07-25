/*
 * Copyright 2014 Systemic Pty Ltd
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

using log4net;
using NHibernate;
using Sif.Framework.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sif.Framework.Persistence.NHibernate
{

    public class AppAdminRepository : GenericRepository<SifAppAdmin, long>, IAppAdminRepository
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public AppAdminRepository()
            : base(EnvironmentProviderSessionFactory.Instance)
        {

        }

        public virtual ICollection<string> RetrieveAdminKeys(string applicationKey)
        {
            if (string.IsNullOrWhiteSpace(applicationKey))
            {
                throw new ArgumentNullException("applicationKey");
            }

            List<string> admins = new List<string>();

            ICollection<SifAppAdmin> records = Retrieve(new SifAppAdmin()
            { ApplicationKey = applicationKey });

            foreach (SifAppAdmin record in records)
            {
                admins.Add(record.AdminApplicationKey);
                admins.AddRange(RetrieveAdminKeys(record.AdminApplicationKey));
            }
            return admins;
        }
    }
}
