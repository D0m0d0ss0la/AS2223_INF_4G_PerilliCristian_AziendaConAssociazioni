using System.ComponentModel;
using System.Linq.Expressions;

namespace UnitTestAzienda
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {        }

        [Test]
        public void ReadingOfDataInTxtFile()
        {
            Department dep = new Department();
            HeadDeveloper HD = new HeadDeveloper();
            Developer dev = new Developer();
            UserInterface UI = new UserInterface();
            int nOfSepartatedArguments = 3; // Number of separate Arguments ( name,surname,desc - Job ecc - Department


            string[] arrayStringH1 = HD.Hdeveloper("awdiawida").Split("-");
            string[] arrayStringH2 = dep.AddEmployee(dev.Dev("awdawdaw")).Split("-");
            string[] arrayStringH3 = dep.AddEmployee(UI.Uinterface("awdawdaw")).Split("-");
            for (int i = 0; i < nOfSepartatedArguments; i++)
            {
                try
                {
                    string h = arrayStringH1[i];
                    h = arrayStringH2[i];
                    h = arrayStringH2[i];
                    if( i == nOfSepartatedArguments)
                    {
                        if (arrayStringH1[i] != null)
                        {
                            Assert.IsTrue(false, "Reading can't be done since there isn't enough data inside");
                        }
                    }
                }
                catch (Exception e) { Assert.IsTrue(false, "Too many data inside the file, readin can't be don"); }
            }

            Assert.IsTrue(true, "No issues with the description");

        }
    }
}