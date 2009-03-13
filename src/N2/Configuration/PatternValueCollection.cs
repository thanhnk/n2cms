using System.Configuration;

namespace N2.Configuration
{
	/// <summary>
	/// A collection of pattern replacements for the name editor.
	/// </summary>
	public class PatternValueCollection : ConfigurationElementCollection
	{
		public PatternValueCollection()
		{
			BaseAdd(new PatterValueElement("smallA", "[������@]", "a", true));
			BaseAdd(new PatterValueElement("capitalA", "[������]", "a", true));
			BaseAdd(new PatterValueElement("smallAE", "[�]", "ae", true));
			BaseAdd(new PatterValueElement("capitalAE", "[�]", "AE", true));
			BaseAdd(new PatterValueElement("smallO", "[����]", "o", true));
			BaseAdd(new PatterValueElement("capitalO", "[����]", "O", true));
			BaseAdd(new PatterValueElement("theRest", "[^. a-zA-Z0-9_-]", "", true));
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new PatterValueElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((PatterValueElement) element).Name;
		}
	}
}