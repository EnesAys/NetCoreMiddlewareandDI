using System.Collections.Generic;

namespace NetCoreMiddlewareandDI.Services
{
    public interface IGenericService <T>
    {
        bool AddList(T model);
        int GetListCount();
    }
}