# C19 Office Tracker (Red Badge Individual MVC Project)
## Developer:  Lisa Jeffers
#### Software Development Bootcamp @ Eleven Fifty Academy

The final requirement to earn the Red Badge for this program was to build a .NET Framework MVC 5 Web Application using n-tier architecture covering a topic of your choice.

My project choice was to create an application that tracks the daily health status of employees that are required to report to work in an office during the Covid19 Pandemic.  
The purpose of the application is to ensure employees in the office do not spread Covid19 to the other employees working in the office. Employees must signin and answer key
questions before starting work each day.  If they have any symptoms, have been in contact with a Covid19 positive individual, or if their temperature is higher than 100, 
they will not be allowed to work.  The application will direct them as to whether they are able to work or instead must contact their manager for instructions.  
In the case that an employee tests positive it will be much easier to identify other employees that have been in close proximity at work. This not only helps prevent the spread
of Covid19 but also keeps the Company on track during these trying economic times by protecting it's employees.
<br />
### Database Tables:

#### Building (allows for companies to be spread across multiple buildings by department)
(seeded for testing)
BuildingId int (key),
BuildingName string,
Address string,
City string,
State string,
Postal string,

#### Department
(seeded for testing)
DeptId int (key),
DeptName string,
BuildingId (foreignkey),
Location string,
Room string,

#### Employee
EmpId int (key),
IndividualId guid,
Fullname string,
Phone string,
Email string,
HireDate datetime,
Birthdate datetime,
Gender string,
Position enum,
DeptId int (foreignkey)

#### Tracking
TrackingId int (key),
IndividualId guid,
TrackDate datetime,
SymptomAnswer string,
ContactAnswer string,
TempAnswer string,
Temperature double,
MaskAnswer string,
GroupAnswer string,
EmpId int (foreignkey)



#### How to install the project locally:
<br />
<i>(This application was built and tested in Visual Studio)</i>
<br />
<br />
1.	Go to https://github.com/ljeffers0106/C19OfficeTracker
<br />
2.	On this page, make sure you are on the master branch (located directly above the blue box containing the name of the last committed changes)
<br />
3.	Once you know you are on the master branch, click the green box containing “Code” and copy the URL given in the dropdown menu, either by copying the link manually or clicking the clipboard icon. 
<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/GITHUBCODE.PNG" align="left" width="500" height="180"/>
<br />
<br />

<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
4.	Now you can navigate to where you’d like the project to be stored, and open your command prompt. 
<br />
5.	In your command prompt, type “git clone”, put a space after “clone”, then paste the URL you copied from Github. Press enter and the project should clone to your local computer.
<br />



<br />
