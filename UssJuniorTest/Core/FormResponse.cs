using System.Collections;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Repositories;
using UssJuniorTest.Infrastructure.Store;

namespace UssJuniorTest.Core
{
    public static class FormResponse
    {
        public static ArrayList FormLogResponse()
        {
            InMemoryStore _store = new InMemoryStore();
            CarRepository carRep = new CarRepository(_store);
            DriveLogRepository logRep = new DriveLogRepository(_store);
            PersonRepository personRep = new PersonRepository(_store);

            List<DriveLog> logs = logRep.GetAll().ToList();
            ArrayList presLog = new ArrayList();
            foreach (DriveLog log in logs)
            {
                PresentationLog presentationLog = new PresentationLog();
                presentationLog.Id = log.Id;
                presentationLog.Car = carRep.Get(log.CarId);
                presentationLog.Person = personRep.Get(log.PersonId);
                presentationLog.StartDateTime = log.StartDateTime;
                presentationLog.EndDateTime = log.EndDateTime;
                TimeSpan Timespentdriving = log.EndDateTime - log.StartDateTime;
                presentationLog.UsageTime += $"{Timespentdriving.Days}:{Timespentdriving.Hours}:{Timespentdriving.Minutes}";
                presLog.Add(presentationLog);
            }
            return presLog;
        }
        public static ArrayList DateResponse(DateTime start_time, DateTime end_time)
        {
            var presLog = FormLogResponse();
            foreach(PresentationLog log in presLog.ToArray())    
            {
                if (log.StartDateTime >= end_time || log.EndDateTime < start_time)
                {
                    presLog.Remove(log);
                }
            }
            return presLog;
        }
    }
}
