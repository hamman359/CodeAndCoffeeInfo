using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAndCoffeeInfo.Core {

	public interface ICoreConfig {
		
	} 

	public class CoreConfig : ICoreConfig {

		private readonly NameValueCollection m_settings;

		public CoreConfig(NameValueCollection p_settings) {

			m_settings = p_settings;
		}

	}
}
