# Diabetes Monitoring & Management System

C# Windows Forms class project by Shema Placide · AUCA · INSY 8411

## Open and run

1. In Windows, right-click the ZIP and choose **Extract All**. Open the extracted **DiabetesMonitoringSystem.sln** with **Visual Studio**.
2. Use the Visual Studio Installer to add **.NET desktop development** and the **.NET Framework 4.8 targeting pack** if Visual Studio asks for them.
3. Open **XAMPP Control Panel**. Click **Start** beside **Apache** and **MySQL**. In the MySQL row, click **Admin** to open phpMyAdmin.
4. In phpMyAdmin, click the server home, then **Import → Choose File**. Select **Database/Setup.sql** and click **Import** (or **Go**). It creates `diabetes_monitoring_db` and its four tables. Click the new database on the left, then import **Database/DemoAccounts.sql** using the same steps.
5. In Visual Studio, open **DiabetesMonitoringSystem → App.config**. The first-run settings are `127.0.0.1`, port `3306`, user `root`, and a blank password for a default local XAMPP setup. Change `Port` or `Password` if you configured different values. If your password contains semicolons or XML special characters, quote it for the connection string and escape XML characters as needed.
6. Right-click the solution in **Solution Explorer** and click **Restore NuGet Packages** to install MySqlConnector. Press **Ctrl + Shift + B**, then **F5**. Create a Patient account or use the sample logins below.

## Sample logins

| Username | Password | Role |
| --- | --- | --- |
| demo_admin | Demo!1d578a68c2bf | Admin |
| demo_doctor | Demo!ea83769abbf2 | Doctor |
| demo_doctor2 | Demo!1b55f7d537ee | Doctor |
| demo_patient | Demo!68e35c272ed3 | Patient |

## Screens in Solution Explorer

Expand **DiabetesMonitoringSystem → Views**. Right-click a form file and select **View Designer**. Each form has an editable Designer file. Press **F4** on any control to see its `(Name)`, `Text`, `Location` and `Size`.

| File | Screen |
| --- | --- |
| LoginForm.cs | Log in or open registration |
| RegisterForm.cs | Create a Patient account |
| AdminDashboardForm.cs | Open the Admin tools |
| UserAccountsForm.cs | Create, update or deactivate Patient and Doctor accounts |
| PatientAssignmentsForm.cs | Assign a patient to an active doctor or replace the assignment |
| PatientDashboardForm.cs | Open glucose tools and view personal appointments |
| RecordGlucoseForm.cs | Save a positive glucose reading and its measurement time |
| GlucoseHistoryForm.cs | View readings by date as the Patient or assigned Doctor |
| DoctorDashboardForm.cs | Select an assigned patient |
| DoctorAppointmentsForm.cs | Schedule, reschedule or cancel a follow-up |

## Walk through the assignment

1. On **Log in**, use **Create account** to register a test Patient. Enter a unique username and a matching password of at least eight characters. The app returns to Log in with the new username filled.
2. Log in as the Patient and save a glucose reading. Open **Glucose history** and check the dates and unit. Try zero or text and check that the input is rejected.
3. Sign out. Log in as `demo_admin`, open **Patient assignments**, assign the test Patient to **Demo Doctor**, then sign out.
4. Log in as `demo_doctor`. Select the Patient, open the reading, and schedule a follow-up. To edit its time, select the appointment, adjust its date or time, then choose **Reschedule selected**.
5. Log back in as the Patient. Check that the dashboard shows the new appointment time. After cancelling from the Doctor screen, the Patient should see **Cancelled** after reopening or refreshing the list.
6. Log in as `demo_doctor2` and confirm the Patient does not appear. Reassign the Patient from the Admin screen and confirm that access moves to the new Doctor.
7. Deactivate a test account from **User accounts** and confirm that it can no longer log in. Glucose and appointment rows remain saved.
8. Restart the application and check that saved readings and appointments remain. Verify the three-second history requirement on the class PC with 1,000 readings for the selected Patient.

## How the code is organized

- **Views** contains Windows Forms, button events and messages. Login is the startup form.
- **Controllers** validates user inputs, checks roles and verifies salted passwords.
- **Models** contains the signed-in User object and the ADO.NET repositories. The repositories use parameterized SQL and restrict records by the signed-in Patient or current Doctor assignment.
- **Database** includes the XAMPP MariaDB schema and demo account setup.

The Lab sample project and Working with Databases with ADO.NET use the MVC separation, parameterized commands and DataTable grid binding used here. This XAMPP edition uses MariaDB and MySqlConnector as requested. It creates a separate database from the SQL Server edition.
