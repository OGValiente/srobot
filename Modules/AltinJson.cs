using Newtonsoft.Json;

namespace SROBOT.Modules
{
    public class ABDDOLARI
    {
        public string Alış { get; set; }
        public string Satış { get; set; }
        public string Tür { get; set; }
    }

    public class EURO
    {
        public string Alış { get; set; }
        public string Satış { get; set; }
        public string Tür { get; set; }
    }

    public class OnsAltın
    {
        public string Alış { get; set; }
        public string Satış { get; set; }
        public string Tür { get; set; }
    }

    public class GramAltın
    {
        public string Alış { get; set; }
        public string Satış { get; set; }
        public string Tür { get; set; }
    }

    public class AltinJson
    {
        public ABDDOLARI ABDDOLARI { get; set; }
        public EURO EURO { get; set; }
        public OnsAltın OnsAltın { get; set; }
        public GramAltın GramAltın { get; set; }
    }
}