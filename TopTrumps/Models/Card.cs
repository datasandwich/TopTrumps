namespace TopTrumps.Models
{
    public class Card
    {
        public int ID { get; }
        public string Name { get; }
        public int Attr1 { get; }
        public int Attr2 { get; }
        public int Attr3 { get; }
        public int Attr4 { get; }
        public int Attr5 { get; }
        public Card(int iD, string name, int attr1, int attr2, int attr3, int attr4, int attr5)
        {
            ID = iD;
            Name = name;
            Attr1 = attr1;
            Attr2 = attr2;
            Attr3 = attr3;
            Attr4 = attr4;
            Attr5 = attr5;
        }
        public string getName()
        {
            return Name;
        }
        public int getattr(int attributeNumber)
        {
            switch (attributeNumber)
            {
                case 1: return Attr1;
                case 2: return Attr2;
                case 3: return Attr3;
                case 4: return Attr4;
                case 5: return Attr5;
                default: return 0;
            }
        }
    }
}
