namespace Orders.App.Abstract;
    public interface IService<T>
    {
    List<T> Items { get; set; }

    List<T> GetAllItems();
    T GetItemById(int id);
    int GetLastId();
    int AddItem(T item);
    int UpdateItem(T item);
    void RemoveItem(T item);
}