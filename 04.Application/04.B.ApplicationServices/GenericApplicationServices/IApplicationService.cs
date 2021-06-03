using System.Collections.Generic;
using Utilities.BaseEntities;

namespace ApplicationService.GenericApplicationServices
{
    public interface IApplicationService<TApplicationDto,TEntity,Tkey> 
        where TApplicationDto :class where TEntity:BaseEntity<Tkey> where Tkey:struct 
    {
        public IEnumerable<TApplicationDto> GetAll();
        public TApplicationDto Get(Tkey id);
        public TApplicationDto Add(TApplicationDto entity, bool? doCommit);
        public void Delete(Tkey id, bool? doCommit);
        public void Delete(TApplicationDto applicationDto, bool? doCommit);
        public TApplicationDto Update(TApplicationDto applicationDto, bool? doCommit);



    }
}
