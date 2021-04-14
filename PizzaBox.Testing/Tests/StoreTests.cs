namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore()
        {
            //check is AStore
            //gives its name
            //1st arrange: (Subj under test)
            var sut = new ChicagoStore();
            //act
            var actual = sut.Name;
            //assert
            Assert.True(actual == "ChicagoStore");
        }
    }
}