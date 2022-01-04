namespace OrdersConsole.App.Concrete;
public class OrderService : BaseService<Order>
{
    string directoryData { get; set; } = $@"{StaticData.DataFolder}Data\";
    string file { get; set; } = $@"{StaticData.DataFolder}Data\Order.xml";
    public override bool UpdateItem(Order item)
    {
        var entity = GetItemById(item.Id);
        if (entity == null)
        {
            return false;
        }
        entity.TypeId = item.TypeId;
        entity.Name = item.Name;
        entity.OrderDate = item.OrderDate;
        entity.StatusId = item.StatusId;
        entity.Dedline = item.Dedline;
        EditModifedItems(entity);
        SaveItems();
        return true;
    }

    public override bool LoadItems()
    {
        if (!File.Exists(file))
        {
            return false;
        }

        XmlRootAttribute root = new XmlRootAttribute();
        root.ElementName = "Order";
        root.IsNullable = true;
        XmlSerializer serializer = new XmlSerializer(typeof(List<Order>), root);

        string xml = File.ReadAllText(file);
        if (string.IsNullOrEmpty(xml))
        {
            return false;
        }
        StringReader stringReader = new StringReader(xml);

        var xmlItems = (List<Order>)serializer.Deserialize(stringReader);

        if (xmlItems == null)
        {
            return false;
        }

        Items.AddRange(xmlItems);
        return false;
    }

    public override bool SaveItems()
    {
        if (Items.Count == 0)
        {
            return false;
        }
        if (!Directory.Exists(directoryData))
        {
            Directory.CreateDirectory(directoryData);
        }
        if (File.Exists(file))
        {
            File.Delete(file);
        }

        XmlRootAttribute root = new XmlRootAttribute();
        root.ElementName = "Order";
        root.IsNullable = true;
        XmlSerializer serializer = new XmlSerializer(typeof(List<Order>), root);

        using StreamWriter sw = new StreamWriter(file);
        serializer.Serialize(sw, Items);

        return true;
    }
}