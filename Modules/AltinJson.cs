namespace SROBOT.Modules
{
    using System;
    using Newtonsoft.Json;

    public partial class DovizJson
    {
        [JsonProperty("Güncelleme Tarihi")]
        public DateTimeOffset GüncellemeTarihi { get; set; }

        [JsonProperty("ABD DOLARI")]
        public Kur AbdDolari { get; set; }

        [JsonProperty("EURO")]
        public Kur Euro { get; set; }

        [JsonProperty("Ons Altın")]
        public Kur OnsAltın { get; set; }

        [JsonProperty("Gram Altın")]
        public Kur GramAltın { get; set; }

        [JsonProperty("Çeyrek Altın")]
        public Kur ÇeyrekAltın { get; set; }

        [JsonProperty("Yarım Altın")]
        public Kur YarımAltın { get; set; }

        [JsonProperty("Tam Altın")]
        public Kur TamAltın { get; set; }

        [JsonProperty("Gümüş")]
        public Kur Gümüş { get; set; }
    }

    public partial class Kur
    {
        [JsonProperty("Alış")]
        public string Alış { get; set; }

        [JsonProperty("Satış")]
        public string Satış { get; set; }

        [JsonProperty("Tür")]
        public string Tür { get; set; }
    }
}