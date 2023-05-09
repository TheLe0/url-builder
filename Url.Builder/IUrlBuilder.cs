namespace Url.Builder;

public interface IUrlBuilder
{
    void AddSegment(string segment);
    void AddParameter(string label, string value);
    void RemoveSegment(string segment);
    void RemoveParameter(string key);
    void Refresh();
    string ToString();
}