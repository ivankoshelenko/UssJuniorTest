using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Repositories;
using UssJuniorTest.Infrastructure.Store;

namespace UssJuniorTest.Controllers;

[Route("api/driveLog")]
public class DriveLogController : Controller
{
    public DriveLogController()
    {

    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PresentationLog>))]
    public ActionResult<ArrayList> GetDriveLogsAggregation()
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
            presLog.Add(presentationLog);
        }
        return (presLog);
    }

    [HttpGet("{start_time}/{end_time}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PresentationLog>))]
    public JsonResult GetDriveLogsByTime(DateTime start_time, DateTime end_time)
    {
        InMemoryStore _store = new InMemoryStore();
        CarRepository carRep = new CarRepository(_store);
        DriveLogRepository logRep = new DriveLogRepository(_store);
        PersonRepository personRep = new PersonRepository(_store);
        Console.WriteLine(start_time);
        List<DriveLog> logs = logRep.GetAll().ToList();
        ArrayList presLog = new ArrayList();
        foreach (DriveLog log in logs)
        {
            if (log.StartDateTime <= end_time && log.EndDateTime > start_time)
            {
                PresentationLog presentationLog = new PresentationLog();
                presentationLog.Car = carRep.Get(log.CarId);
                presentationLog.Person = personRep.Get(log.PersonId);
                presentationLog.StartDateTime = log.StartDateTime;
                presentationLog.EndDateTime = log.EndDateTime;
                presentationLog.Id = log.Id;
                presLog.Add(presentationLog);
            } 
        }
        if (presLog.Count == 0)
            return Json("No drive Logs");
        return Json(presLog);
    }
}