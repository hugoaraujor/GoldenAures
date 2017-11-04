using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{
	public class IniFile
	{
		public string Path;

		[DllImport("kernel32.dll")]
		private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

		[DllImport("kernel32.dll")]
		private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

		public IniFile(string IniPath)
		{
			Path = IniPath;
		}

		public void Write(string Section, string Key, string Value)
		{
			WritePrivateProfileString(Section, Key, Value, this.Path);
		}

		public void Write(string Key, string Value)
		{
			WritePrivateProfileString(Assembly.GetExecutingAssembly().GetName().Name, Key, Value, this.Path);
		}

		public string Read(string Section, string Key)
		{
			StringBuilder temp = new StringBuilder(255);
			int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.Path);
			return temp.ToString();
		}

		public string Read(string Key)
		{
			StringBuilder temp = new StringBuilder(255);
			int i = GetPrivateProfileString(Assembly.GetExecutingAssembly().GetName().Name, Key, "", temp, 255, this.Path);
			return temp.ToString();
		}
	}
}
