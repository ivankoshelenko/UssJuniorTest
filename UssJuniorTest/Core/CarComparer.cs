using System.Collections;
using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Core
{
    public class CarComparer: IComparer
    {
        public int Compare(object? x, object? y)
        {
            PresentationLog logX = (PresentationLog)x;
            PresentationLog logY = (PresentationLog)y;
            //return ((new CaseInsensitiveComparer()).Compare(logX.Car.Id, logY.Car.Id));
            if (logX.Car.Id > logY.Car.Id)
                return 1;
            if (logX.Car.Id == logY.Car.Id)
                return 0;
            return -1;
        }
    }
    public class ReverseCarComparer : IComparer
    {
        public int Compare(object? y, object? x)
        {
            PresentationLog logX = (PresentationLog)x;
            PresentationLog logY = (PresentationLog)y;
            //return ((new CaseInsensitiveComparer()).Compare(logX.Car.Id, logY.Car.Id));
            if (logX.Car.Id > logY.Car.Id)
                return 1;
            if (logX.Car.Id == logY.Car.Id)
                return 0;
            return -1;
        }
    }
}
