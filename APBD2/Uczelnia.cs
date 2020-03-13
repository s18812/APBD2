using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD2
{
    public class Uczelnia
    {

        [XmlAttribute] public string createdAt = DateTime.Today.ToShortDateString();
        [XmlAttribute] public string author = "Krzysztof Luśtyk";
        
        public HashSet<Student> students { get; set; }
        public Uczelnia() 
        {
            this.students = new HashSet<Student>(new MyComparer());
        }
    }
}
