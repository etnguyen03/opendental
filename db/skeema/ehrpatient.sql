CREATE TABLE `ehrpatient` (
  `PatNum` bigint(20) NOT NULL,
  `MotherMaidenFname` varchar(255) NOT NULL,
  `MotherMaidenLname` varchar(255) NOT NULL,
  `VacShareOk` tinyint(4) NOT NULL,
  `MedicaidState` varchar(50) NOT NULL,
  `SexualOrientation` varchar(255) NOT NULL,
  `GenderIdentity` varchar(255) NOT NULL,
  `SexualOrientationNote` varchar(255) NOT NULL,
  `GenderIdentityNote` varchar(255) NOT NULL,
  `DischargeDate` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
