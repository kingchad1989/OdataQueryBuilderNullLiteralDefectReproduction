using NUnit.Framework;

namespace OdataNullLiteralRepro
{
    using OData.QueryBuilder.Builders;

    public class Tests
    {
        [Test]
        public void Test1()
        {
            bool? nullableBool = null;

            var uri = new ODataQueryBuilder<DataObject>("http://localhost/")
                .For<DataObject>(x => x)
                .ByList()
                .Filter(x => x.NullableBool == nullableBool)
                .ToUri();
            
            Assert.That(uri.OriginalString, Is.EqualTo("http://localhost/?$filter=NullableBool eq null"));
        }
    }

    public class DataObject
    {
        public bool? NullableBool { get; set; }
    }
}