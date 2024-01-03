using System.Runtime.CompilerServices;
using System.Xml.Linq;
using TimeTracker.Contexts;
using TimeTracker.Model;

namespace TimeTracker.Components.Pages
{
    public partial class Entry
    {
        public TimeRecord Record { get; set; } = new TimeRecord();
        public Entry()

        {

           // AddTimeEntry();
          
        }

        public void AddTimeEntry()
        {

            TimeRecord timeEntry = new TimeRecord()

            {
                Name = "santhosh",

                Description = "Designed UI",

                Date = DateOnly.FromDateTime(DateTime.Now),

                StartTime = DateTime.Now,

                EndTime = DateTime.Now.AddHours(5),

            };
            SendTimeEntryToDatabase(timeEntry);

        }

            private void SendTimeEntryToDatabase(TimeRecord timeEntry)
            {
                using (TrackerDbContext trackerDbContext = new TrackerDbContext())

                {

                    trackerDbContext.TimeRecords.Add(timeEntry);

                    trackerDbContext.SaveChanges();

                }
            }
            
        

        public void SaveEntry()
        {
            TimeRecord newrow = new TimeRecord();
            newrow.Name= Record.Name;
            newrow.Description= Record.Description;
            newrow.Date= Record.Date;
            newrow.StartTime= Record.StartTime;
            newrow.EndTime = Record.EndTime;
            SendTimeEntryToDatabase(newrow);
        }

        public void Clear()
        {
            TimeRecord delrow = new TimeRecord();
            delrow.Name = string.Empty;
            delrow.Description= string.Empty;
        }

    }
}




