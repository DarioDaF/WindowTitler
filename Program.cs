using WindowTitler;

// See https://aka.ms/new-console-template for more information

if (args.Length != 1)
{
    Console.Error.WriteLine($"Usage: WindowTitler \"old window title\"");
    return 1;
}

var titlePrefix = args[0];

var wList = new List<Tuple<IntPtr, string>>();

WinStuff.EnumWindows(delegate (IntPtr hWnd, int lParam) {
    var title = WinStuff.GetWindowText(hWnd);

    if (title != null && title.StartsWith(titlePrefix))
    {
        wList.Add(Tuple.Create(hWnd, title));
    }

    return true;
}, 0);

int i = 0;
foreach(var (w, title) in wList)
{
    var newTitle = titlePrefix + " - " + i;
    
    Console.WriteLine($"{title} -> {newTitle}");

    WinStuff.SetWindowText(w, newTitle);
    i += 1;
}

Console.ReadLine();

return 0;
