using System.Configuration;
using NHibernate.Mapping;
using System.Collections.Generic;

namespace N2.Configuration
{
	/// <summary>
	/// The configured collection of paths instructs N2's url rewriter to 
	/// ignore certain virtual paths when considering a path for rewrite.
	/// </summary>
	[ConfigurationCollection(typeof(VirtualPathElement))]
	public class VirtualPathCollection : LazyRemovableCollection<VirtualPathElement>
	{
		public VirtualPathCollection()
		{
			AddDefault(new VirtualPathElement("management", "~/N2/"));
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new VirtualPathElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((VirtualPathElement) element).Name;
		}

		public string[] GetPaths(N2.Web.IWebContext webContext)
		{
			List<string> paths = new List<string>();
			foreach (var vpe in AllElements)
			{
				paths.Add(webContext.ToAbsolute(vpe.VirtualPath));
			}

			return paths.ToArray();
		}
	}
}