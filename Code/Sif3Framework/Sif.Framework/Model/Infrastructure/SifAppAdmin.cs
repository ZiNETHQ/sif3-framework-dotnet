using Sif.Framework.Model.DataModels;
using Sif.Framework.Model.Persistence;
using System;

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
