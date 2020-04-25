using System.Collections.Generic;

namespace NetCoreMiddlewareandDI.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        public List<object> ObjectList = new List<object>();
        public bool AddList(T model)
        {
            if (model != null)
            {
                ObjectList.Add(model);
                return true;
            }
            else
                return false;
        }

        public int GetListCount() => ObjectList.Count;
    }
}