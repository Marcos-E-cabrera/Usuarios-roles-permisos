namespace AutTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod] // Todo lo que tenga TestMethod se va a ser ejecutado como prubaUnitaria
		public void TestMethod1()
		{
			string result = AutTesting.Program.Something();
			Assert.AreEqual("Algo",result);
		}

		[TestMethod]
		public void TestLogin()
		{
			bool result = AutTesting.Program.Login("Marcos", "123456");
			Assert.AreEqual(true,result);
		}
	}
}