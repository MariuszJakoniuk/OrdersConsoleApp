namespace OrdersConsole.App.Common;
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

    public T? GetItemById(int id)
    {
        T? entity = Items.FirstOrDefault(p => p.Id == id);
        return entity;
    }

    public int GetLastId()
    {
        int lastId = 0;
        T? itemLast = Items.OrderBy(p => p.Id).LastOrDefault();
        if (itemLast != null)
        {
            lastId = itemLast.Id;
        }
        else
        {
            lastId = 0;
        }
        return lastId;
    }

    public int AddItem(T item)
    {
        item.CreatedById = StaticData.UserName;
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
        T? item = GetItemById(id);
        if (item != null)
        {
            Items.Remove(item);
        }
    }

    //to nie działa dla Order - CZEMU, nadpisane w OrderService
    public virtual bool UpdateItem(T item)
    {
        var entity = GetItemById(item.Id);
        if (entity == null)
        {
            return false;
        }
        entity = item;
        EditModifedItems(entity);
        return true;
    }

    public void EditModifedItems(T item)
    {
        item.ModifiedById = StaticData.UserName;
        item.ModifiedDateTime = DateTime.Now;
    }
}