using System.Collections.Generic;

public class GameManager
{
    private static List<IPauseHandler> _items =
        new List<IPauseHandler>();

    public static void Subscribe(IPauseHandler obj)
    {
        _items.Add(obj);
    }

    public static void Unsubscribe(IPauseHandler obj)
    {
        _items.Remove(obj);
    }

    public static void Unpause()
    {
        foreach (var item in _items)
            item.Unpause();
    }

    public static void Pause()
    {
        foreach (var item in _items)
            item.Pause();
    }
}
