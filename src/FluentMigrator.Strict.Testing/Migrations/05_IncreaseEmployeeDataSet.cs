using System;
using FluentMigrator;

namespace FluentMigrator.Strict.Testing.Migrations
{
    [Migration(5)]
    public class IncreaseEmployeeDataSet : Migration
    {
        public override void Up()
        {
            var rand = new Random();
            string[] firstNames = "JAMES,JOHN,ROBERT,MICHAEL,WILLIAM,DAVID,RICHARD,CHARLES,JOSEPH,THOMAS,CHRISTOPHER,DANIEL,PAUL,MARK,DONALD,GEORGE,KENNETH,STEVEN,EDWARD,BRIAN,RONALD,ANTHONY,KEVIN,JASON,MATTHEW,GARY,TIMOTHY,JOSE,LARRY,JEFFREY,FRANK,SCOTT,ERIC,STEPHEN,ANDREW,RAYMOND,GREGORY,JOSHUA,JERRY,DENNIS,WALTER,PATRICK,PETER,HAROLD,DOUGLAS,HENRY,CARL,ARTHUR,RYAN,ROGER,JOE,JUAN,JACK".Split(',');
            string[] lastNames = @"Adams,Alexander,Allen,Anderson,Bailey,Baker,Barnes,Bell,Bennett,Brooks,Brown,Bryant,Butler,Campbell,Carter,Clark,Coleman,Collins,Cook,Cooper,Cox,Davis,Edwards,Evans,Flores,Foster,Garcia,Gonzales,Gonzalez,Gray,Green,Griffin,Hall,Harris,Hayes,Henderson,Hernandez,Hill,Howard,Hughes,Jackson,James,Jenkins,Johnson,Jones,Kelly,King,Lee,Lewis,Long,Lopez,Martin,Martinez,Miller,Mitchell,Moore,Morgan,Morris,Murphy,Nelson,Parker,Patterson,Perez,Perry,Peterson,Phillips,Powell,Price,Ramirez,Reed,Richardson,Rivera,Roberts,Robinson,Rodriguez,Rogers,Ross,Sanchez,Sanders,Scott,Simmons,Smith,Stewart,Taylor,Thomas,Thompson,Torres,Turner,Walker,Ward,Washington,Watson,White,Williams,Wilson,Wood,Wright,Young".Split(',');

            for (int i = 0; i < 5000; i++)
            {
                var name = firstNames[(rand.Next(0, firstNames.Length))];
                var surname = lastNames[(rand.Next(0, firstNames.Length))];
                var age = rand.Next(18, 66);
                var salary = rand.Next(15000, 95001);
                var jobPos = rand.Next(1, 5);
                var pensionId = (i + 3);

                this.Insert.IntoTable("Employees").Row(new
                {
                    FirstName = name.Trim(),
                    LastName = surname.Trim(),
                    Age = age,
                    Salary = salary,
                    JobPositionId = jobPos,
                    PensionId = pensionId
                });
            }
        }

        public override void Down()
        {
            this.Delete.FromTable("Employees").AllRows();
        }
    }
}