using System.Collections;
using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Core
{
    public class PersonComparer: IComparer
    {
        public int Compare(object? x, object? y)
        {
            PresentationLog logX = (PresentationLog)x;
            PresentationLog logY = (PresentationLog)y;
            //return ((new CaseInsensitiveComparer()).Compare(logX.Car.Id, logY.Car.Id));
            if (logX.Person.Id > logY.Person.Id)
                return 1;
            if (logX.Car.Id == logY.Car.Id)
                return 0;
            return -1;
        }
    }
    public class ReversePersonComparer : IComparer
    {
        public int Compare(object? y, object? x)
        {
            PresentationLog logX = (PresentationLog)x;
            PresentationLog logY = (PresentationLog)y;
            //return ((new CaseInsensitiveComparer()).Compare(logX.Car.Id, logY.Car.Id));
            if (logX.Person.Id > logY.Person.Id)
                return 1;
            if (logX.Person.Id == logY.Person.Id)
                return 0;
            return -1;
        }
    }
}
