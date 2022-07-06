namespace TopTrumps.Models
{
    public class Attributes
    {
        public Attributes(int iD, int deckid, string attr1, string attr2, string attr3, string attr4, string attr5)
        {
            ID = iD;
            Deckid = deckid;
            Attr1 = attr1;
            Attr2 = attr2;
            Attr3 = attr3;
            Attr4 = attr4;
            Attr5 = attr5;
        }

        public int ID { get; set; }
        public int Deckid { get; set; }
        public string Attr1 { get; set; }
        public string Attr2 { get; set; }
        public string Attr3 { get; set; }
        public string Attr4 { get; set; }
        public string Attr5 { get; set; }
        public string getAttr(int attrnum)
    {
            return attrnum switch
            {
                0 => Attr1,
                1 => Attr2,
                2 => Attr3,
                3 => Attr4,
                4 => Attr5,
                _ => "",
            };
        }
    }
    
}