using System;

namespace ReevooMark {

	public static class Config {
		public static string protocol = "http";
		//public static string host = "mark.reevoo.com";
		public static string host = "localhost:3001";

		public static string BaseUri() {
			return String.Format("{0}://{1}/", protocol, host);
		}

		public static string BaseUriAssets() {
			return String.Format("//{0}/", host);
		}
	}
}
