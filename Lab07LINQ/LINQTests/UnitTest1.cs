using System;
using System.Collections.Generic;

using Xunit;
using Lab07LINQ;
using Lab07LINQ.Classes;
using Newtonsoft.Json;


namespace LINQTests
{
    public class ReadFile
    {
        [Fact]
        public void ConvertsJSONToTypeScript()
        {
            Assert.IsType<string>(Program.ReadFile("../../../../Lab07LINQ/data.json"));
        }
    }
    public class AllNeighborhoods
    {

        [Fact]
        public void CreateCollectionOfNeighborhoodNames()
        {
            string jsonFile = Program.ReadFile("../../../../Lab07LINQ/data.json");
            RootObject locations = JsonConvert.DeserializeObject<RootObject>(jsonFile);
            
            Assert.Collection<RootObject>(locations, Program.AllNeighborhoods(locations));
        }
    }
    
}