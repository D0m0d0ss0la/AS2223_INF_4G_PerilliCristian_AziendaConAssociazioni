using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

public class Company
{
    // has no utility since I didn't think it was necessary for the excercise. its just to make everything look nicer + has a random object cuz why not
        protected Random rand = new Random();

}

public class Department : Company 
{
     List<Worker> employees = new List<Worker>();
    public string DName = "";
    public Department(){    }
    public Department(string name)
    {
        DName = name;
    }

     public string AddEmployee(string employeeX)
    {

        string FullIdentity = string.Concat(employeeX, DName);
        employees.Add(new Worker() { idWorker = employeeX});
        return FullIdentity;

    }

    public void GetEmployees()
    {
        foreach (Worker idW in employees)
        {
            Console.WriteLine(idW);
        }
    }
    
    public void GetEmployees(int index)
    {
        int innerIndex = 0;
        foreach (Worker worker in employees)
        {
            if (innerIndex == index)
            {
                Console.WriteLine(worker);
            }
            index++;
        }
    }
}

public class Worker : Company
{
    public string idWorker { get; set; }
    protected string[] lastNames = { "Rossi,", "Fabbrizzi,", "Giacomini,", "Soldoni," };
    protected string[] names = { "Marco,", "Antonio,", "Fabbrizio,", "Osvaldo," };


    public override string ToString()
    {
        return idWorker;
    }
}


public class Developer : Worker
{
    string[] codingLanguages = { "C#,", "C++,", "C,", "Java,", "Python,", "Web Developing," };
    public string Dev(string desc)
    {
        return (string.Concat(names[rand.Next(names.Length)], lastNames[rand.Next(lastNames.Length)], desc,  " - ", "Developer,", codingLanguages[rand.Next(codingLanguages.Length)], " - "));
    }
}

public class UserInterface : Worker
{
    int yearsOfExperience;

    public string Uinterface(string desc)
    {
        yearsOfExperience = rand.Next(0,40); // INDICATIVE NUMBER, people in reality may even have more than 40 years of experience, but i thought that would be enough
        return (string.Concat(names[rand.Next(names.Length)], lastNames[rand.Next(lastNames.Length)],
            desc, " - UserInterface, ", Convert.ToString(yearsOfExperience),"y", " - "));
    }
}

public class HeadDeveloper : Worker
{
    //attributes
    string[] softwares = { "Excell,", "Word,", "EveryAdobe,", "DeepKnowelegde in Coding Softwares," };
    string nameHolder;
    string surnameHolder;  // <--- very bad solution because its late at night, since we only got 1 admin x Deparment, this can work!

    //...
    public string Hdeveloper(string desc)
    {
        return (string.Concat(nameHolder, surnameHolder, desc , " - ","HeadDeveloper,", softwares[rand.Next(softwares.Length)]," - "));
    }
    public string Hdeveloper()
    {
        nameHolder = names[rand.Next(names.Length)];
        surnameHolder = lastNames[rand.Next(lastNames.Length)];
        //remove the last comma to make sure it doesnt have it at the end of the surname! ( there's nothing on the right of it )
        surnameHolder = surnameHolder.Remove(surnameHolder.Length - 1);
        return (string.Concat(nameHolder,surnameHolder));
    }
}