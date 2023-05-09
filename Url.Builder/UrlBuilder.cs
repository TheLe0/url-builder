using System.Text;

namespace Url.Builder;

public class UrlBuilder : IUrlBuilder
{
    private readonly string _baseUrl;
    private List<string> _segments;
    private IDictionary<string, string> _parameters;

    public UrlBuilder(string baseUrl)
    {
        _baseUrl = baseUrl;
        Refresh();
    }

    public void AddSegment(string segment)
    {
        _segments.Add(segment);
    }

    public void AddParameter(string label, string value)
    {
        _parameters.Add(label, value);
    }

    public void RemoveSegment(string segment)
    {
        var list = new List<string>();

        foreach (var segmentRow in _segments)
        {
            if (segmentRow != segment)
            {
                list.Add(segmentRow);
            }
        }

        _segments = list;
    }

    public void RemoveParameter(string key)
    {
        _parameters.Remove(key);
    }

    public void Refresh()
    {
        _parameters = new Dictionary<string, string>();
        _segments = new List<string>();
    }

    public override string ToString()
    {
        var url = new StringBuilder(_baseUrl);

        foreach (var segment in _segments)
        {
            if (!url.ToString().EndsWith('/')) url.Append("/");

            url.Append(segment);
        }

        for (int index = 0; index < _parameters.Count; index++)
        {
            var item = _parameters.ElementAt(index);

            var label = item.Key;
            var value = item.Value;
            var separator = index == 0 ? "?" : "&";

            if (url.ToString().EndsWith('/')) url.Remove(url.Length - 1, 1);

            url.Append(separator);
            url.Append(label);
            url.Append("=");
            url.Append(value);
        }

        return url.ToString();
    }
}
