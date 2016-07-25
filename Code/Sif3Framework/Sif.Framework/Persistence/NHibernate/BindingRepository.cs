using Sif.Framework.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sif.Framework.Persistence.NHibernate
{
    class BindingRepository : GenericRepository<SifObjectBinding, long>, IBindingRepository
    {
        public BindingRepository() : base(EnvironmentProviderSessionFactory.Instance) { }
        
        public string RetrieveOwnerId(Guid objectId)
        {
            SifObjectBinding binding = this.Retrieve(new SifObjectBinding()
            {
                RefId = objectId
            }).SingleOrDefault();

            if(binding == null)
            {
                throw new KeyNotFoundException("No owner specified for object with id " + objectId);
            }

            return binding.OwnerId;
        }
    }
}
