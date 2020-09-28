using Newtonsoft.Json;

namespace SROBOT.Modules
{
	public struct AltinJson
	{
		[JsonProperty("EURO")]
		public string Euro { get; private set; }
		[JsonProperty("ABD DOLARI")]
		public string Dolar { get; private set; }
		[JsonProperty("Ons Alt\u0131n")]
		public string Ons { get; private set; }
		[JsonProperty("Gram Alt\u0131n")]
		public string GramAltin { get; private set; }
	}
}