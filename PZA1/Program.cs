using System.Data;

var dateTimeNow = DateTime.UtcNow;
var highLevel = false;
var lowLevel = false;
var pump = false;

while (true)
{
    Console.WriteLine(
        """
        Enter option for your level:
        1. Set highLevel to !highLevel (default false)
        2. Set lowLevel to !lowLevel (default false) and highLevel to false
        3. Skip
        """);
    var option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            highLevel = !highLevel;
            dateTimeNow = DateTime.UtcNow;
            break;
        case 2:
            lowLevel = !lowLevel;
            highLevel = false;
            break;
        default: break;
    };

    Console.WriteLine();

    if (highLevel)
    {
        var timeNow = DateTime.UtcNow;
        var timeDifferenceInSeconds = (timeNow - dateTimeNow).TotalSeconds;
        Console.WriteLine($"Elapsed time: {timeDifferenceInSeconds}");

        if (timeDifferenceInSeconds >= 3)
        {
            pump = true;
            dateTimeNow = timeNow;
            Console.WriteLine("Pump has been activated");
        }
    }

    if (lowLevel && pump)
    {
        pump = false;
        lowLevel = false;
        highLevel = false;
        Console.WriteLine("Pump has been deactivated");
    }

    Console.WriteLine();
}
