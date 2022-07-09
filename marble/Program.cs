using marble.Model;
using marble.MarbleHandler;

List<Marble> marbles = new List<Marble> {
    new Marble { id = 1, color = "blue", name = "Bob", weight = 0.5 },
    new Marble { id = 2, color = "red", name = "John Smith", weight = 0.25 },
    new Marble { id = 3, color = "violet", name = "Bob O'Bob", weight = 0.5 },
    new Marble { id = 4, color = "indigo", name = "Bob Dad-Bob", weight = 0.75 },
    new Marble { id = 5, color = "yellow", name = "John", weight = 0.5 },
    new Marble { id = 6, color = "orange", name = "Bob", weight = 0.25 },
    new Marble { id = 7, color = "blue", name = "Smith", weight = 0.5 },
    new Marble { id = 8, color = "blue", name = "Bob", weight = 0.25 },
    new Marble { id = 9, color = "green", name = "Bobb Ob", weight = 0.75 },
    new Marble { id = 10, color = "blue", name = "Bob", weight = 0.5 }
};

MarbleHandler marbleHandler = new MarbleHandler();

List<Marble> finalMarbleList = new List<Marble>();

finalMarbleList = marbleHandler.validateMarbleList(marbles);

foreach (var marble in finalMarbleList)
{
    Console.WriteLine("id: " + marble.id +
        ", color: " + marble.color +
        ", name: " + marble.name +
        ", weight: " + marble.weight);
}