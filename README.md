# C19 Office Tracker (Red Badge Individual MVC Project)
## Developer:  Lisa Jeffers
#### Software Development Bootcamp @ Eleven Fifty Academy

The final requirement to earn the Red Badge for this program was to build a .NET Framework MVC 5 Web Application using n-tier architecture covering a topic of your choice.

My project choice was to create an application that tracks the daily health status of employees that are required to report to work in an office during the Covid19 Pandemic.

The purpose of the application is to ensure employees in the office do not spread Covid19 to the other employees working in the office. Employees must signin and answer key
questions before starting work each day.  If they have any symptoms, have been in contact with a Covid19 positive individual, or if their temperature is higher than 100.4 degrees, they will not be allowed to work.  The application will direct them as to whether they are able to work or instead must contact their manager for instructions.

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
<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/assets/GITHUBCODE.PNG" align="left" width="500" height="200"/>
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
6.	After the project is cloned, if there are build errors then you may have to restore NuGet packages that come along with the project. Another solution may be restarting Visual Studio.
<br />
7.	Once the project is building with no errors, go to the search bar in Visual Studio and click on Tools -> NuGet Package Manager -> Package Manager Console.
<br />
8.	Now, inside the package manager console you must change the Default project to C19OfficeTracker.Data (see image below).
<br />
9.	Next, click inside the package manager console and type “update-database” (this will seed the ‘Building’and 'Department' tables).


<br />

### Running the Program
<br />
<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/assets/C19Landing.PNG" align="left" width="700" height="350"/>
<br/>
<br/>
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
<br />
<br />
<br />
<br />
1.  Register as a user
<br />
2.  Add yourself as an employee and use the drop down boxes for Gender, Position, and Departmert  (I would suggest setting up multiple employees for testing purposes)
<br />
<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/assets/C19Employees.PNG" align="left" width="700" height="350"/>
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
<br />
<br />
<br />

<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/assets/C19Employees1.PNG" align="left" width="700" height="350"/>
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
<br />
<br />
<br />
<br />
<br />
<br />

3.  Add some tracking records. It automatically uses todays date - you cannot change the date.  If you want you can delete and readd to get different messages.  
(I would suggest setting up multiple employees for testing purposes)
<br />

<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/assets/C19Tracking.PNG" align="left" width="700" height="350"/>
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
<br />
<br />
<br />
<br />
<br />
See the example of a message for someone who is told they cannot work below:
<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/assets/Tracking2.PNG" align="left" width="700" height="350"/>
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
<br />
<br />
<br />
<br />
<br />
4.  The Follow Up option alerts HR or Management to any Employees whose results require monitoring.
<br />

<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/assets/FollowUP.PNG" align="left" width="700" height="350"/>
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
<br />
<br />
<br />
<br />
<br />
5.  If you need to track down location information for an employee, go to the employee record to see department.  Then look at the department table.
You can see who else is in that department on the Department Detail screen.
<br />
<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/assets/DeptDetail.PNG" align="left" width="700" height="350"/>
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
<br />
<br />
<br />
<br />
<br />
<br />
5.  You can look at the Building table to see what Departments are in each Building.  This might be useful if you were trying to track exposure.
<br />
<img src="https://github.com/ljeffers0106/C19OfficeTracker/blob/master/assets/BuildingDetail.PNG" align="left" width="700" height="350"/>
