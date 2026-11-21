# Diabetes Monitoring & Management System

I built this desktop application for Lab 3 in INSY 8411 Dot Net at AUCA. It helps patients keep a record of their blood glucose and lets their assigned doctors review the readings and arrange follow-up appointments.

The case study is Rwanda Diabetes Association (RDA). The project uses C# Windows Forms, MVC, ADO.NET, and the MariaDB database included with XAMPP.

**Author:** Shema Placide  
**Course:** INSY 8411 Dot Net, Group D  
**Submission:** Lab 3

## What the system does

| User | What they can do |
| --- | --- |
| Patient | Create an account, record glucose readings, filter their own history by date, and view appointments. |
| Doctor | View assigned patients, check their glucose history, and schedule, reschedule, or cancel appointments. |
| Admin | Create Patient and Doctor accounts, edit names and usernames, deactivate accounts, and assign patients to active doctors. |

Each patient has one current doctor. A doctor can access a patient's records while that patient is assigned to them. Patients can view their own records.

## How I used MVC

I organized the code into three folders so it is easier to follow where each task happens.

| Folder | What it contains |
| --- | --- |
| `Models` | The signed-in user's information and the classes that read and save database records. |
| `Views` | The Windows Forms, their controls, and button events. |
| `Controllers` | Input validation, password verification, and the operations called by the forms. |

For example, when a patient clicks **Save reading**, the form collects the value and measurement time. `CareController` checks the value and passes the patient's ID to `CareRepository`. The repository prepares the SQL command, and `Database.cs` runs it. The form displays a confirmation after the reading is saved.

`AccountController.cs` handles login, registration, account management, and assignments. `CareController.cs` handles readings and appointments. The repositories use SQL parameters, and query results are loaded into a `DataTable` for display in a `DataGridView`.

## Tools and requirements

To run the project, you need Windows, Visual Studio with the **.NET desktop development** workload, the **.NET Framework 4.8 targeting pack**, and XAMPP. Visual Studio restores the `MySqlConnector` package used for the database connection.

## Set up the project

1. Download this repository using **Code → Download ZIP** and extract it, or clone it with Git.

   ```bash
   git clone https://github.com/Shemaplacide/lab-3-diabetes-monitoring-system.git
   ```

2. Open XAMPP and start **Apache** and **MySQL**. Click **Admin** beside MySQL to open phpMyAdmin.

3. In phpMyAdmin, open **Import** from the server home page and import `Database/Setup.sql`. It creates `diabetes_monitoring_db` and its four tables.

4. Select that database and import `Database/DemoAccounts.sql` to add sample accounts for the different roles.

5. Open `DiabetesMonitoringSystem.sln` in Visual Studio. Check the connection in `DiabetesMonitoringSystem/App.config`.

   ```xml
   <connectionStrings>
     <add name="DiabetesDatabase"
          connectionString="Server=127.0.0.1;Port=3306;Database=diabetes_monitoring_db;User ID=root;Password=;Connection Timeout=5;Use Affected Rows=False" />
   </connectionStrings>
   ```

   These settings assume a local XAMPP installation on port `3306` with a blank password for `root`. Adjust the port and password to match your installation.

6. Right-click the solution and select **Restore NuGet Packages**. Press **Ctrl + Shift + B** to build, then **F5** to run. The login window opens first.

New patients can use **Create account**. The demo script also creates `demo_admin`, `demo_doctor`, `demo_doctor2`, and `demo_patient` for exploring the role dashboards.

## Database tables

| Table | Purpose |
| --- | --- |
| `Users` | Stores accounts, roles, active status, and password hash information. |
| `PatientAssignments` | Links each patient to their current doctor. |
| `GlucoseReadings` | Stores glucose values and measurement times for each patient. |
| `Appointments` | Stores appointment times and their current status. |

The setup scripts preserve existing rows. If you already have tables under the same names, their columns must match the included setup script.

## Forms

| Form | Purpose |
| --- | --- |
| `LoginForm` | Log in and open the appropriate dashboard. |
| `RegisterForm` | Create a Patient account. |
| `AdminDashboardForm` | Open account and assignment management. |
| `UserAccountsForm` | Create, edit, and deactivate accounts. |
| `PatientAssignmentsForm` | Assign or reassign a patient's doctor. |
| `PatientDashboardForm` | View appointments and open glucose tools. |
| `RecordGlucoseForm` | Save a reading with its measurement time. |
| `GlucoseHistoryForm` | View and filter readings as a Patient or assigned Doctor. |
| `DoctorDashboardForm` | Select an assigned patient. |
| `DoctorAppointmentsForm` | Manage the selected patient's follow-up appointments. |

To edit a screen, expand `Views` in Solution Explorer, right-click the form's `.cs` file, and choose **View Designer**. Press **F4** after selecting a control to inspect its properties.

## Try the main workflow

1. Register a Patient account and save a glucose reading.
2. Open the patient's glucose history and apply a date filter.
3. Log in as Admin and assign the patient to a doctor.
4. Log in as that doctor, open the patient's readings, and schedule an appointment.
5. Reschedule the appointment and check the updated time on the Patient dashboard.
6. Cancel it and refresh the patient's appointment list to see the cancelled status.
7. Reassign the patient to another doctor and check that access follows the new assignment.

The app checks unique usernames, matching registration passwords, positive glucose readings, and valid date ranges. Passwords are stored using salted PBKDF2 hashes. Deactivating an account prevents login while keeping its records. Cancelling an appointment keeps its row with a `Cancelled` status.

This project helped me practice Windows Forms design, C# events, MVC, database queries, input validation, and GitHub submission.
