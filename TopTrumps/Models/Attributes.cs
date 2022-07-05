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
        switch(attrnum)
        {
            case 0: return Attr1;
            case 1: return Attr2;
            case 2: return Attr3;
            case 3: return Attr4;
            case 4: return Attr5;
            default:return "";
        }
    }
    }
    
}