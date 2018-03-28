using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurTasks
{
    public class MockDataStore
    {
        List<Item> items = null;
        bool result = false;

        public MockDataStore()
        {
        }

        public void GenerateData()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Text = "Clean litter box",
                    Location="Home",
                    AssignedTo="Robert",
                    DueDate=DateTime.Today.AddDays(2)
                },
                new Item
                {
                    Id = 2,
                    Text = "Koko care",
                    Location="Home",
                    AssignedTo="Colette",
                    DueDate=DateTime.Today.AddDays(2)
                },
                new Item
                {
                    Id = 3,
                    Text = "Book vacation travel",
                    Location="Home",
                    AssignedTo="Robert",
                    DueDate=DateTime.Today.AddDays(-2)
                },
                new Item
                {
                    Id = 4,
                    Text = "Mow the lawn",
                    Location="Home",
                    AssignedTo="Robert",
                    DueDate=DateTime.Today.AddDays(5)
                },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<int> SaveItemAsync(Item item)
        {
            if (item.Id == 0)
            {
                //Todo: Write some code to really find the next Id. 
                item.Id = 99;
                items.Add(item);

                result = await Task.FromResult(true);

                return (result == true) ? 1 : 0;
            }
            else
            {
                var _item = items.Where(
                    (Item arg) => arg.Id == item.Id).FirstOrDefault();
                items.Remove(_item);
                items.Add(item);

                result = await Task.FromResult(true);

                return (result == true) ? 1 : 0;
            }
        }

        public async Task<int> DeleteItemAsync(Item item)
        {
            var _item = items.Where(
                (Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            result = await Task.FromResult(true);

            return (result == true) ? 1 : 0;
        }

    }

}

