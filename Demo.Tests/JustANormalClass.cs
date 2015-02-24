namespace Demo.Tests
{
    public class JustANormalClass
    {
        public JustANormalClass() : this(string.Empty)
        {
        }

        public JustANormalClass(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        private int InternalId { get; set; }

        protected void SetInternalId(int id)
        {
            InternalId = id;
        }
    }
}