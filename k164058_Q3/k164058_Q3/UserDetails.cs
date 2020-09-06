namespace k164058_Q3
{
    internal class UserDetails
    {
        public string datetime { get; set; }
        public Value value { get; set; } // a class whose return type is value

        public UserDetails()
        {
            value = new Value();
        }
    }
}