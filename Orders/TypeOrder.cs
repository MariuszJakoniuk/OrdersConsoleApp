namespace Orders;
public class TypeOrder
{
    public TypeOrder()
    {
    }

    public TypeOrder(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}