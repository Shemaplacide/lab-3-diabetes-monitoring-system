USE diabetes_monitoring_db;

INSERT INTO Users (Username, FullName, `Role`, PasswordHash, PasswordSalt, PasswordIterations)
SELECT 'demo_admin', 'Demo Admin', 'Admin', 0x5f9ea9614679fd39d3f25e419785145add7782449e2860f3a2f5a0b53233de06, 0x5368f4760822f85929567008f308356c, 600000 FROM DUAL
WHERE NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'demo_admin');

INSERT INTO Users (Username, FullName, `Role`, PasswordHash, PasswordSalt, PasswordIterations)
SELECT 'demo_doctor', 'Demo Doctor', 'Doctor', 0xaaa2a70a60772ea154627f4c2ce9ca00e44b2e6d44adc27948c84db8aef516e2, 0x4e096e1a93ddaf4d46f587e6f4f90663, 600000 FROM DUAL
WHERE NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'demo_doctor');

INSERT INTO Users (Username, FullName, `Role`, PasswordHash, PasswordSalt, PasswordIterations)
SELECT 'demo_doctor2', 'Second Demo Doctor', 'Doctor', 0xe206eef63c70f09537940929f85252f595dba04d6b8d3c90bf534c6cb89fb3eb, 0x9859502d69eeef0962e2c1632e5cd0a5, 600000 FROM DUAL
WHERE NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'demo_doctor2');

INSERT INTO Users (Username, FullName, `Role`, PasswordHash, PasswordSalt, PasswordIterations)
SELECT 'demo_patient', 'Demo Patient', 'Patient', 0x78725cbd701d47ca4b51546395a3ebacb765867eadfe437f49f57cb7876d8d82, 0x117cb6596e268a1140f773ac0cbb1a9f, 600000 FROM DUAL
WHERE NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'demo_patient');

