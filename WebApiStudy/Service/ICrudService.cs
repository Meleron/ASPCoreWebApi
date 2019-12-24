using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiStudy.Service
{
    public interface ICrudService<TItem, TItemModel> where TItem : class where TItemModel : class
    {
        public TItemModel GetItem(int key);
        public IEnumerable<TItemModel> GetItemsList();
        public TItemModel AddItem(TItemModel item);
        public TItem DeleteItem(int key);
        public bool UpdateItem(int key, TItemModel model);
    }
}
