CREATE DATABASE IF NOT EXISTS diabetes_monitoring_db
    CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE diabetes_monitoring_db;

CREATE TABLE IF NOT EXISTS Users (
    UserId INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    FullName VARCHAR(100) NOT NULL,
    `Role` VARCHAR(10) NOT NULL CHECK (`Role` IN ('Admin','Doctor','Patient')),
    IsActive BOOLEAN NOT NULL DEFAULT TRUE,
    PasswordHash BINARY(32) NOT NULL,
    PasswordSalt BINARY(16) NOT NULL,
    PasswordIterations INT NOT NULL CHECK (PasswordIterations > 0)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS PatientAssignments (
    PatientId INT PRIMARY KEY,
    DoctorId INT NOT NULL,
    FOREIGN KEY (PatientId) REFERENCES Users(UserId),
    FOREIGN KEY (DoctorId) REFERENCES Users(UserId)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS GlucoseReadings (
    ReadingId INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    PatientId INT NOT NULL,
    GlucoseValue DECIMAL(12,3) NOT NULL CHECK (GlucoseValue > 0),
    MeasuredAt DATETIME NOT NULL,
    FOREIGN KEY (PatientId) REFERENCES Users(UserId),
    INDEX IX_Glucose_Patient_MeasuredAt (PatientId, MeasuredAt, ReadingId)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Appointments (
    AppointmentId INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    PatientId INT NOT NULL,
    AppointmentAt DATETIME NOT NULL,
    Status VARCHAR(10) NOT NULL DEFAULT 'Scheduled' CHECK (Status IN ('Scheduled','Cancelled')),
    FOREIGN KEY (PatientId) REFERENCES Users(UserId)
) ENGINE=InnoDB;
