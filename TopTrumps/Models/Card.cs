namespace TopTrumps.Models
{
    public class Card
    {
        public Card(int iD, int deckid, string name, string description, int attr1, int attr2, int attr3, int attr4, int attr5, string imagepath)
        {
            ID = iD;
            Deckid = deckid;
            Name = name;
            Description = description;
            Attr1 = attr1;
            Attr2 = attr2;
            Attr3 = attr3;
            Attr4 = attr4;
            Attr5 = attr5;
            Imagepath = imagepath;
        }
        public int ID { get; set; }
        public int Deckid { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Attr1 { get; set; }
        public int Attr2 { get; set; }
        public int Attr3 { get; set; }
        public int Attr4 { get; set; }
        public int Attr5 { get; set; }
        public string Imagepath { get; set; }
        public string getName()
        {
            return Name;
        }
        public int getattr(int attributeNumber)
        {
            return attributeNumber switch
            {
                0 => Attr1,
                1 => Attr2,
                2 => Attr3,
                3 => Attr4,
                4 => Attr5,
                _ => 0,
            };
        }
        public string getImage()
        {
            return Imagepath;
        }
        public string? getDesc()
        {
            return Description;
        }
    }
}
