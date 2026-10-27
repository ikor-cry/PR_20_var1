namespace PR_20
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public string DisplayName => $"{Name} (осталось: {Quantity})";

        public string CartDisplayName => $"{Name} (в корзине: {Quantity})";
        public string cartfinal => $"{Name} - {Quantity} шт";
    }
}