using System;
using System.Collections.Generic;

namespace ReevooMark {

	public class Parameters : Dictionary<string, string> {

		public Parameters(params string[] paramList) {
			if (paramList.Length % 2 != 0) {
				throw new ArgumentException("You have to have odd number of arguments.");
			}

			for (int i = 0; i < paramList.Length; i += 2) {
				string key = paramList[i];
				string value = paramList[i + 1];
				this[key] = value;
			}
		}

		public Parameters () {

		}

		public Parameters Compact() {
			Parameters parameters = new Parameters ();

			foreach (KeyValuePair<string, string> pair in this) {
				if (pair.Value == null || pair.Value == "")
					continue;

				parameters[pair.Key] = pair.Value;
			}

			return parameters;
		}

		public void Update(Parameters other) {
			foreach (KeyValuePair<string, string> pair in other) {
				this [pair.Key] = pair.Value;
			}
		}

		public Parameters Merge(Parameters other) {
			Parameters result = new Parameters();

			result.Update(this);
			result.Update(other);

			return result;
		}

		public Parameters Merge(params string[] paramList) {
			return this.Merge(new Parameters(paramList));
		}

		public string ToQueryString () {
			List<string> paramList = new List<string>();

			foreach (KeyValuePair<string, string> pair in this) {
				string value = pair.Value == null ? "" : pair.Value;

				if (pair.Value == null || pair.Value == "")
					continue;

				paramList.Add (pair.Key + "=" + value);
			}

			return String.Join ("&", paramList.ToArray ());
		}

		public override string ToString () {
			return string.Format ("[Parameters(" + ToQueryString() + ")]");
		}

		public override bool Equals (object obj) {
			if (obj == null)
				return false;

			Parameters other = ((Parameters) obj).Compact();
			Parameters compactThis = this.Compact ();

			if (compactThis.Count != other.Count) {
				return false;
			}

			foreach (KeyValuePair<string, string> pair in compactThis) {
				if (pair.Value != other [pair.Key]) {
					return false;
				}
			}

			return true;
		}

		public static bool operator ==(Parameters p1, Parameters p2) {
			return p1.Equals(p2);
		}

		public static bool operator !=(Parameters p1, Parameters p2) {
			return !p1.Equals(p2);
		}

		public override int GetHashCode () {
			return ToQueryString().GetHashCode();
		}
	}
}