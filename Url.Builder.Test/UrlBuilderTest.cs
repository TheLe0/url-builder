namespace Url.Builder.Test;

public class UrlBuilderTest
{
    [InlineData("https://leotosin.com.br/", "https://leotosin.com.br/")]
    [InlineData("http://leotosin.com.br/", "http://leotosin.com.br/")]
    [InlineData("www.leotosin.com.br/", "www.leotosin.com.br/")]
    [InlineData("https://leotosin.com.br:9090", "https://leotosin.com.br:9090")]
    [Theory]
    public void BaseUrlTest(string input, string output)
    {
        var url = new UrlBuilder(input);

        Assert.Equal(url.ToString(), output);
    }

    [Fact]
    public void BaseUrlWithSegmentsTest()
    {
        var input = "https://leotosin.com.br/";
        var output = "https://leotosin.com.br/foo/bar";

        var url = new UrlBuilder(input);

        url.AddSegment("foo");
        url.AddSegment("bar");
        url.AddSegment("xyz");

        url.RemoveSegment("xyz");

        Assert.Equal(output, url.ToString());
    }

    [Fact]
    public void BaseUrlWithParametersTest()
    {
        var input = "https://leotosin.com.br/";
        var output = "https://leotosin.com.br?foo=bar&bar=foo";

        var url = new UrlBuilder(input);

        url.AddParameter("foo", "bar");
        url.AddParameter("bar", "foo");

        Assert.Equal(output, url.ToString());
    }
}