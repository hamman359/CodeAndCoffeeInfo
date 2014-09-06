using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndCoffeeInfo.Core {

	public interface ICoreConfig {
		
	} 

	public class CoreConfig : ICoreConfig {

		private readonly NameValueCollection m_settings;

		public CoreConfig(NameValueCollection p_settings) {

			Contract.Requires<ArgumentNullException>(p_settings != null, "p_settings cannot be null.");

			m_settings = p_settings;
		}

	}
}
