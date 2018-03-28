using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OurTasks
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public Command SaveItemCommand { get; set; }
        public Command DeleteItemCommand { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;

            SaveItemCommand = new Command(async () => await ExecuteSaveItemCommand());
            DeleteItemCommand = new Command(async () => await ExecuteDeleteItemCommand());
        }

        async Task ExecuteSaveItemCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await App.DataStore.SaveItemAsync(Item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteDeleteItemCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await App.DataStore.DeleteItemAsync(Item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void SetLocation(int index)
        {
            switch (index)
            {
                case 0:
                    Item.Location = "Home";
                    break;
                 case 1:
                   Item.Location = "Work";
                    break;
                 case 2:
                   Item.Location = "Other";
                    break;
                default:
                    break;
            }
        }

        public int GetLocation(string location)
        {
            int index = 0;

            switch (location)
            {
                case "Home":
                    index = 0;
                    break;
                 case "Work":
                    index = 1;
                    break;
                 case "Other":
                    index = 2;
                    break;
                default:
                    break;
            }

            return index;
        }

        public void SetAssignedTo(int index)
        {
            switch (index)
            {
                case 0:
                    Item.AssignedTo = "Robert";
                    break;
                 case 1:
                   Item.AssignedTo = "Colette";
                    break;
                 case 2:
                   Item.AssignedTo = "Nobody";
                    break;
                default:
                    break;
            }
        }

        public int GetAssignedTo(string assignedTo)
        {
            int index = 0;

            switch (assignedTo)
            {
                case "Robert":
                    index = 0;
                    break;
                case "Colette":
                    index = 1;
                    break;
                case "Nobody":
                    index = 2;
                    break;
                default:
                    break;
            }

            return index;
        }

    }
}
