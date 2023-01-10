using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography;
//Programma realizzato da: Cristian Perilli 4G INF Rimini ( O'Belluzzi )
// Il programma tratta la gestione di un'azienda "x" con utilizzo di classi ed associazioni per 2 attributi:    Deparment < - - > Employee

// EXCERCISE NOT DONE!
void DotsDots()
{
    string PuntiAttesa = ". . .";
    for (int i = 0; i < PuntiAttesa.Length; i++)
    {
        Console.Write(PuntiAttesa[i]);
        Wait(169);
    }
}
string Read(string path,int interruptPoint) // use a for to get the whole txt file in case
{
    int count = 0;

        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                count++;
                if ( count > interruptPoint) { return line; }
            }
        }

    return Convert.ToString(count);
}
// - - - -
void WriteLine(string path)
{
    using (StreamWriter sw = new StreamWriter(path, true))
    {

        sw.WriteLine();

    }
}

void Write(string str, string path)
{
    using (StreamWriter sw = new StreamWriter(path,true))
    {
       
            sw.Write(str);
        
    }
}
void Wait(int t)
{
    System.Threading.Thread.Sleep(t);
}

// - - - - - - - - - - Main: - - - -
Random rnd = new Random();
int NDepartments;
int LinesEmployees;
string currentDep = "";
char tasto;
ConsoleKey tastok;
// rnd.Next(1, names.Length)
//                                              INIZIO MENU PROGRAMMA!

Console.WriteLine("Console PROGRAM for the simulation of a Company");
Console.WriteLine("Created by Cristian Perilli IVG INF on the 13 / 12 / 2022 for the 15 / 12 / 2022");
Console.Write("Press any key to begin! ");
//piccolo effetto visivo
DotsDots();
Console.ReadKey();
Console.Clear();
do
{
    do
    {
        NDepartments = Convert.ToInt32(Read("Departments.txt", 100));
        LinesEmployees = Convert.ToInt32(Read("Employees.txt", 1000));
        Console.WriteLine("Choose which Department of the company you would like to interact with'");
        Console.WriteLine();
        for (int i = 0; i < NDepartments; i++)
        {
            Console.WriteLine(i + " - for: " + Read("Departments.txt", i));
        }
        
            Console.WriteLine();
            Console.WriteLine("- - - - - - - - - Special Options: - - - - - - - - - - -");
            Console.WriteLine();
             
        if (NDepartments != 8)
        {
            Console.WriteLine((NDepartments) + " - To create 1 Department ");
        }
        else
        {
            Console.WriteLine("Some option have been removed since the max number of departments ( 7 )");
        }
        Console.WriteLine((NDepartments + 1) + " - to delete every department ( every employee will be erased )  ");
        Console.WriteLine(" 'Esc' - to stop the program ( if u close from here there won't be any risk of damaging the txt files)");
        Console.WriteLine();
            ConsoleKeyInfo key1 = Console.ReadKey();
            Console.Clear();
            tasto = key1.KeyChar;
            tastok = key1.Key;
            Console.Clear();
        
        if ( tasto == 9 + 48) { tasto = 'Ç'; }
        // creating a new department
        if (tasto == NDepartments + 48)  // - - - - -
        {
            Developer dev = new Developer();
            UserInterface uiW = new UserInterface();
            HeadDeveloper headDeveloper = new HeadDeveloper();
            // ^ just getting the classes ready for the usage of their methods,

            Console.Clear();
            Console.WriteLine("Write the name of the Department you want to add!"); Console.WriteLine();
            currentDep = Console.ReadLine();
            Department department = new Department(currentDep); // I give the name of the dep that is being created
            WriteLine("Departments.txt");
            Write(currentDep, "Departments.txt"); // writing it on the notepad
            Write(" - ", "Departments.txt");
            Console.WriteLine("Would you like to add any kind of description to each? if you change your mind during the");
            Console.WriteLine("process you can simply press 'Enter' without typing anything to speed things up!");
            do {
                
                Console.WriteLine("1 - No description");
                Console.WriteLine("2 - Yes description"); DotsDots(); 
                ConsoleKeyInfo key3 = Console.ReadKey();
                Console.Clear();
                tasto = key3.KeyChar;
            } while (tasto > 2 + 48);
            Console.Clear();

            Console.Write("Making workers....(randomly generated from 20 to 30)"); DotsDots(); Console.WriteLine();
            int nOfEmployees = rnd.Next(20, 30);
            int admin = rnd.Next(0, nOfEmployees - 1);
            int counterForWorkersGeneration = 0;
            string description = " ";
            int jobGenerated;
            // Developer dev = new Developer();
            WriteLine("Employees.txt"); // pre-spacing
            do
            {

                if (description != "" && tasto == 2 + 48) { 
                    Console.WriteLine("Insert the description for employee number " + counterForWorkersGeneration + "-");
                description = Console.ReadLine();
                Console.Clear();
                    }
                WriteLine("Employees.txt"); // spacing
                jobGenerated = rnd.Next(0, 2);
                //addemployee
                if (counterForWorkersGeneration == admin) { Write(headDeveloper.Hdeveloper(),"Departments.txt");
                    Write(department.AddEmployee(headDeveloper.Hdeveloper(description)), "Employees.txt"); // inserimento effettivo
                }
                else if(jobGenerated == 0)
                { 
                    Write(department.AddEmployee(dev.Dev(description)),"Employees.txt");
                }else if(jobGenerated == 1)
                {
                    Write(department.AddEmployee(uiW.Uinterface(description)),"Employees.txt");
                }
                counterForWorkersGeneration++;
        }while (counterForWorkersGeneration <= nOfEmployees) ;
            tasto = 'Ç';
        }
        else if (tasto == (NDepartments + 1) + 48)
        {
            Console.Clear();
            Console.WriteLine("Are you sure? this action is - -PERMANENT - -");
            Console.WriteLine("1 - Yes, I am");
            Console.WriteLine("2 - No, I am not");
            ConsoleKeyInfo key3 = Console.ReadKey();
            Console.Clear();
            tasto = key3.KeyChar;
            if (tasto == 1)
            {
                File.WriteAllText("Departments", String.Empty);
                File.WriteAllText("Employees", String.Empty);
                Console.WriteLine("All the data has been erased");
            }
            tasto = 'Ç';
        }

    } while (tasto > (NDepartments - 1)+48);

    if (tastok != ConsoleKey.Escape)
    {
        //getting the exact department
        for (int i = 0; i < NDepartments; i++)
        {
            if (tasto == (i + 48)) // == the department
            {
                currentDep = Read("Departments.txt", i);
                string[] stringHolder = currentDep.Split('-');
                currentDep = stringHolder[0];
                currentDep = String.Concat(" " + currentDep);
                currentDep = currentDep.Remove(currentDep.Length - 1);
                
            }
        }

        //setting the class to add the employees into ( attribute <list> )
        // only the employees of the "x" department will be added to the list tho!
        Department department = new Department(currentDep);
        string outBack;

        for (int i = 0; i < LinesEmployees;i++) {
            string[] stringHolder;
            outBack = (Read("Employees.txt", i));
            stringHolder = outBack.Split('-');
            try
            {
                if (stringHolder[2] == currentDep)
                {
                    department.AddEmployee(string.Concat(stringHolder[0], stringHolder[1]));
                }
            }
            catch { }
        }

        do
        {


            Console.WriteLine(" Currently checking the department = " + currentDep);
            Console.WriteLine("Options:"); Console.WriteLine();
            Console.WriteLine("1 - Print the employees");
            Console.WriteLine("2 - Back to main menu");
            ConsoleKeyInfo key4 = Console.ReadKey();
            Console.Clear();
            tasto = key4.KeyChar;
            //process....
            switch (tasto) // in the case we wanna add more things, we can easily 
            {
                case '1':
                    department.GetEmployees();
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key..."); DotsDots();
            Console.ReadKey(); Console.Clear();

        } while (tasto < 3);
    }

} while (tastok != ConsoleKey.Escape);
// - - - - - - - - - - - - - - - - -