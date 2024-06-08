namespace SupplyStack.Model;

public class Warehouse
{
    private SupplyStack<string>[]_supplyStack;

    public Warehouse(SupplyStack<string>[]supplyStack)
    {
        _supplyStack = supplyStack;
    }

    public void Print()
    {
        foreach (var stack in _supplyStack)
        {
            // stack.Print();
        }
    }
}