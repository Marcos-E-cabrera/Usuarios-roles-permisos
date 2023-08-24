namespace AutTesting
{
	public class Program
	{
		static void Main(string[] args)
		{

		}

		public static string Something()
		{
			return "Algo";
		}

		public static bool Login(string user, string pass)
			=> user == "Marcos" && pass == "123456" ? true:false;

	}
}