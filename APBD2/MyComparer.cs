using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace APBD2
{
    class MyComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals($"{x.imie} {x.nazwisko} {x.idx}",
                $"{y.imie} {y.nazwisko} {y.idx}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer.CurrentCultureIgnoreCase.GetHashCode($"{obj.imie} {obj.nazwisko} {obj.idx}");
        }
    }
}
