# Lab07-LINQ
C# console application to use and display skills of LINQ with JSON files.

This program takes a json file and creates a new collection with it. the program has methods to use LINQ to create an enumerable collection of neighborhood names in New York.

#### Deserialize JSON file
```c#
// Convert JSON to string

// First use StreamReader to Convert JSON to string file
 public static string ReadFile(string path)
{
    string x;
    using (StreamReader sr = new StreamReader(path))
    {
        x = sr.ReadToEnd();
    }
    return x;
}
// Second assign stringified JSON to variable
string jsonFile = ReadFile("../../../data.json");
  
// Last create objects from JSON string to create Collection
RootObject locations = JsonConvert.DeserializeObject<RootObject>(jsonFile);

```
#### Method to LINQ Query for All Neighborhoods from the List created by Deserialazing JSON
```c#
public static IEnumerable<string> AllNeighborhoods(RootObject locations)
{
    var queryAllNeighborhoods =
        from location in locations.features
        select location.properties.neighborhood;
   return queryAllNeighborhoods;
}
```
#### Method to LINQ Query deeper so no locations with "" are in List
```c#
public static IEnumerable<string> AllNeighborhoodsWithNames(IEnumerable<string> locations)
{
    var queryAllNeighborhoods =
        from location in locations
        where location != ""
        select location;

    return queryAllNeighborhoods;
}
```
### Lamda Query for all neighborhoods and no duplicates in List from original Deserialized JSON file
```c#
IEnumerable<string> neighborhoodsNoDupes = 
  locations.features.Select(x => x.properties.neighborhood).Where(n => n != "").Distinct();
```


just run the program. it will create a list to answer a question pertaining to the collection created from the provided JSON file.

![] = (./assets/LINQSH.png)
