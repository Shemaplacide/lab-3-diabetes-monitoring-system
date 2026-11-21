# Diabetes Monitoring & Management System

A Windows desktop application that helps patients record blood glucose readings and allows their assigned doctors to review those readings and manage follow-up appointments.

I developed this project for Lab 3 in INSY 8411 Dot Net at the Adventist University of Central Africa (AUCA). The project uses Rwanda Diabetes Association (RDA) as its case study.

| Academic detail | Information |
| --- | --- |
| Student | Shema Placide |
| Course | INSY 8411 Dot Net |
| Class | Group D |
| Submission | Lab 3 |
| Project | Diabetes Monitoring & Management System |

## Project features

The application provides separate dashboards for Admin, Patient, and Doctor accounts.

| User | Available actions |
| --- | --- |
| Admin | Create Patient and Doctor accounts, update their full names and usernames, deactivate accounts, and assign or reassign patients to active doctors. |
| Patient | Create a Patient account, log in, record glucose readings with the measurement date and time, filter personal glucose history, and view follow-up appointments. |
| Doctor | View assigned patients, review their glucose history, and schedule, reschedule, or cancel appointments. |

Each patient has one current doctor assignment. Patients access their own records, while doctors access the records of patients currently assigned to them. Deactivating an account prevents login and retains its saved records.

## Technologies used

| Technology | Purpose |
| --- | --- |
| C# | Application logic |
| .NET Framework 4.8 | Desktop application framework |
| Windows Forms | Editable forms and user controls |
| MVC | Organization of interface, application rules, and data access |
| ADO.NET | Running database queries from C# |
| MySqlConnector | Connecting the application to MariaDB |
| XAMPP MariaDB | Storing accounts, assignments, readings, and appointments |
| phpMyAdmin | Creating and inspecting the database |
| Visual Studio | Designing forms, building, and running the application |

## MVC structure

The project follows a lightweight MVC structure adapted to Windows Forms.

| Part | Main files | Responsibility |
| --- | --- | --- |
| Model | `User.cs`, `UserRepository.cs`, `CareRepository.cs`, `Database.cs` | Represents signed-in user information, prepares SQL queries, and communicates with the database. |
| View | Forms inside `Views` | Collects input, handles button events, displays tables, and shows messages. |
| Controller | `AccountController.cs`, `CareController.cs` | Validates input, checks roles, verifies passwords, and coordinates repository operations. |

For example, when a patient saves a reading, `RecordGlucoseForm` collects the value and measurement time. `CareController` validates the reading and uses the signed-in patient's ID. `CareRepository` prepares the insert, and `Database.cs` executes it. After a successful save, the form confirms that the reading was recorded.

The repositories use SQL parameters for entered values. Read operations load query results into a `DataTable`, which the forms display in a `DataGridView`.

## Repository contents

| Path | Contents |
| --- | --- |
| `DiabetesMonitoringSystem.sln` | Solution to open in Visual Studio |
| `DiabetesMonitoringSystem/Models/` | User information and database repositories |
| `DiabetesMonitoringSystem/Views/` | Windows Forms and their Designer files |
| `DiabetesMonitoringSystem/Controllers/` | Account and patient-care operations |
| `DiabetesMonitoringSystem/App.config` | Database connection settings |
| `DiabetesMonitoringSystem/Program.cs` | Application startup |
| `Database/Setup.sql` | Database and table creation |
| `Database/DemoAccounts.sql` | Sample accounts for exploring the roles |
| `START_HERE.md` | Additional setup instructions and a demonstration walkthrough |

## Application screens

| Form | Purpose |
| --- | --- |
| `LoginForm` | Log in and open the correct dashboard |
| `RegisterForm` | Create a Patient account |
| `AdminDashboardForm` | Open account and assignment tools |
| `UserAccountsForm` | Create, update, and deactivate accounts |
| `PatientAssignmentsForm` | Assign a patient to a doctor |
| `PatientDashboardForm` | Open glucose tools and view appointments |
| `RecordGlucoseForm` | Save a glucose reading |
| `GlucoseHistoryForm` | Display and filter readings for a Patient or assigned Doctor |
| `DoctorDashboardForm` | Select an assigned patient |
| `DoctorAppointmentsForm` | Schedule, reschedule, and cancel follow-ups |

To edit a screen in Visual Studio, expand `Views`, right-click the form's `.cs` file, and select **View Designer**. Select a control and press **F4** to inspect its name, text, size, and position.

## Requirements

- Windows with Visual Studio and the **.NET desktop development** workload.
- The **.NET Framework 4.8 targeting pack**.
- XAMPP with MariaDB and phpMyAdmin.
- Internet access to restore the MySqlConnector NuGet package.

## Set up and run

### 1. Download the project

Clone the repository using Git, or select **Code → Download ZIP** on GitHub and extract the ZIP.

```bash
git clone https://github.com/Shemaplacide/lab-3-diabetes-monitoring-system.git
```

Open `DiabetesMonitoringSystem.sln` in Visual Studio.

### 2. Start XAMPP

Open the XAMPP Control Panel and start **MySQL** and **Apache**. Click **Admin** beside MySQL to open phpMyAdmin.

### 3. Create the database

In phpMyAdmin, select the server home and open **Import**. Choose `Database/Setup.sql` and run the import.

The script creates a database named `diabetes_monitoring_db` containing four tables.

| Table | Stored information |
| --- | --- |
| `Users` | Names, usernames, roles, account status, and password hash information |
| `PatientAssignments` | Each patient's current doctor |
| `GlucoseReadings` | Patient glucose values and measurement times |
| `Appointments` | Patient follow-up dates, times, and statuses |

Select `diabetes_monitoring_db`, then import `Database/DemoAccounts.sql` to add the sample accounts. Both scripts keep existing rows. The table creation script expects the included schema when tables already exist.

### 4. Check the connection settings

Open `DiabetesMonitoringSystem/App.config`. The included local connection settings are:

```xml
<connectionStrings>
  <add name="DiabetesDatabase"
       connectionString="Server=127.0.0.1;Port=3306;Database=diabetes_monitoring_db;User ID=root;Password=;Connection Timeout=5;Use Affected Rows=False" />
</connectionStrings>
```

Change the port and database password to match your local XAMPP settings. The included example assumes port `3306` and a blank password for the local `root` account.

### 5. Build and launch

In Visual Studio, right-click the solution and select **Restore NuGet Packages**. Build with **Ctrl + Shift + B**, then press **F5**.

The application starts at the login form. A new patient can choose **Create account**. The sample accounts below allow the other roles to be explored after importing the demo script.

## Sample accounts

Import `Database/DemoAccounts.sql` to create an Admin, two Doctors, and a Patient for local demonstrations. The account details are documented in [START_HERE.md](START_HERE.md).

## How to demonstrate the project

1. Create a Patient account with a unique username and matching passwords.
2. Log in as the Patient and record a glucose reading in `mg/dL`.
3. Open glucose history and apply a date filter.
4. Log in as Admin and assign the Patient to Demo Doctor.
5. Log in as Demo Doctor, select the Patient, and open their readings.
6. Schedule an appointment, select it, and reschedule it.
7. Return to the Patient dashboard and check the updated appointment time.
8. Cancel the appointment as the Doctor, then refresh the Patient's appointment list to see its status.
9. Use the second Doctor account to check access before and after reassigning the Patient.
10. Deactivate a test account as Admin and confirm that its login is rejected.

## Validation and account protection

- Usernames must be unique.
- Passwords must contain 8 to 128 characters, and registration requires matching passwords.
- Password verification uses PBKDF2 with SHA-256, a random salt, and 600,000 iterations.
- Glucose readings must be positive numbers with up to three decimal places.
- History displays the newest readings first and supports an inclusive date range.
- Account and assignment operations check Admin access.
- Patient-care queries check the signed-in Patient or current Doctor assignment.
- Cancelling appointments retains their records with a `Cancelled` status.
- Database failures display an error so the user can correct the connection or retry.

## What I practiced

Through this project, I practiced designing Windows Forms, connecting button events to C# methods, organizing code with MVC, using ADO.NET and parameterized SQL, displaying database records in grids, validating input, managing user roles, and publishing a Visual Studio solution to GitHub.
