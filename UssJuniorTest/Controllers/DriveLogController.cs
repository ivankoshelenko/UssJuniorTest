using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using UssJuniorTest.Core;
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
        return FormResponse.FormLogResponse();
    }

    [HttpGet("{start_time}/{end_time}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PresentationLog>))]
    public JsonResult GetDriveLogsByTime(DateTime start_time, DateTime end_time)
    {
        return Json(FormResponse.DateResponse(start_time, end_time));   
    }

    [HttpGet("car-filter/{car_Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PresentationLog>))]
    public JsonResult GetDriveLogsByCars(long car_Id)
    {
        ArrayList presLog = FormResponse.FormLogResponse();
        foreach (PresentationLog log in presLog.ToArray())
        {
            if (log.Car.Id != car_Id)
            {
                presLog.Remove(log);
            }
        }
        return Json(presLog);
    }
    [HttpGet("person-filter/{person_Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PresentationLog>))]
    public JsonResult GetDriveLogsByPerson(long person_Id)
    {
        ArrayList presLog = FormResponse.FormLogResponse();
        foreach (PresentationLog log in presLog.ToArray())
        {
            if (log.Person.Id != person_Id)
            {
                presLog.Remove(log);
            }
        }
        return Json(presLog);
    }
    [HttpGet("pagination/{start}/{end}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PresentationLog>))]
    public JsonResult GetDriveLogsPaginated(int start, int end)
    {
        ArrayList presLog = FormResponse.FormLogResponse();
        foreach (PresentationLog log in presLog.ToArray())
        {
            if (log.Id < start || log.Id > end)
            {
                presLog.Remove(log);
            }
        }
        return Json(presLog);
    }

    [HttpGet("sort-by-car")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PresentationLog>))]
    public JsonResult GetDriveLogsSortedByCar(bool descending)
    {
        ArrayList presLog = FormResponse.FormLogResponse();
        //Console.WriteLine(presLog.Cast<PresentationLog>());
        
        if (!descending)
            presLog = new ArrayList(presLog.Cast<PresentationLog>().OrderBy(log => log.Car.Id).ToList());
        //presLog.Sort(new CarComparer());
        else
            presLog = new ArrayList(presLog.Cast<PresentationLog>().OrderByDescending(log => log.Car.Id).ToList());
        //presLog.Sort(new ReverseCarComparer());
        return Json(presLog);
    }
    [HttpGet("sort-by-person")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PresentationLog>))]
    public JsonResult GetDriveLogsSortedByPerson(bool descending)
    {
        ArrayList presLog = FormResponse.FormLogResponse();
        //Console.WriteLine(presLog.Cast<PresentationLog>());
        //presLog = new ArrayList(presLog.Cast<PresentationLog>().OrderBy(log => log.Car.Id).ToList());
        if (!descending)
            presLog.Sort(new PersonComparer());
        else
            presLog.Sort(new ReversePersonComparer());
        return Json(presLog);
    }
}