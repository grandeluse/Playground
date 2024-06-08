using System.Text;

namespace SupplyStack.Model;

public class SupplyStack<T> : Stack<T>
{
    public string Print()
    {
        var builder = new StringBuilder();
        foreach (var element in this.Reverse())
        {
            builder.Append(element);
        }

        var elements = builder.ToString();
        return elements;
    }
}