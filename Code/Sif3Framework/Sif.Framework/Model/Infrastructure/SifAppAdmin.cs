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

using Sif.Framework.Model.Persistence;

namespace Sif.Framework.Model.Infrastructure
{
    public class SifAppAdmin : IPersistable<long>
    {
        /// <summary>
        /// Internal identifier used by hibernate. Do not use/alter this.
        /// </summary>
        public virtual long Id { get; set; }

        /// <summary>
        /// The administrator's application key
        /// </summary>
        public virtual string AdminApplicationKey { get; set; }

        /// <summary>
        /// The application key of the SIF application to be managed by the applicaton indicated by the AdminApplicationKey
        /// </summary>
        public virtual string ApplicationKey { get; set; }
    }
}
