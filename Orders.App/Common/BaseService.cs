namespace Orders.App.Common;
public class BaseService<T> : IService<T> where T : BaseEntity
{
    public List<T> Items { get; set; }

    public BaseService()
    {
        Items = new List<T>();
    }

    public List<T> GetAllItems()
    {
        return Items;
    }

    public T GetItemById(int id)
    {
        var entity = Items.FirstOrDefault(p => p.Id == id);
        return entity;
    }

    public int GetLastId()
    {
        int lastId;
        if (Items.Any())
        {
            lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
        }
        else
        {
            lastId = 0;
        }
        return lastId;
    }

    public int AddItem(T item)
    {
        item.CreatedById = User.Id;
        item.CreatedDateTime = DateTime.Now;
        Items.Add(item);
        return item.Id;
    }

    public void RemoveItem(T item)
    {
        Items.Remove(item);
    }
    public void RemoveItemById(int id)
    {
        Items.Remove(GetItemById(id));
    }

    public bool UpdateItem(T item)
    {
        //to nie działa
        bool changed = false;
        T entity = GetItemById(item.Id);
        if (entity != null)
        {
            item.ModifiedById = User.Id;
            item.ModifiedDateTime = DateTime.Now;
            entity = item;
            changed = true;
        }
        return changed;
    }
}