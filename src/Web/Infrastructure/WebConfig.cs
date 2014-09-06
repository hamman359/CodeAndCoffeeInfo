using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using CodeAndCoffeeInfo.Core;

namespace CodeAndCoffeeInfo.Web.Infrastructure {

	public interface IWebConfig {
		 
	}

	public class WebConfig : CoreConfig, IWebConfig {

		public WebConfig(NameValueCollection p_settings) : base(p_settings) {
			
		}
	}
}