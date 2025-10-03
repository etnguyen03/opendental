CREATE TABLE `medicationpat` (
  `MedicationPatNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `MedicationNum` bigint(20) NOT NULL,
  `PatNote` text DEFAULT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `DateStart` date NOT NULL DEFAULT '0001-01-01',
  `DateStop` date NOT NULL DEFAULT '0001-01-01',
  `ProvNum` bigint(20) NOT NULL,
  `MedDescript` varchar(255) NOT NULL,
  `RxCui` bigint(20) NOT NULL,
  `ErxGuid` varchar(255) NOT NULL,
  `IsCpoe` tinyint(4) NOT NULL,
  PRIMARY KEY (`MedicationPatNum`),
  KEY `ProvNum` (`ProvNum`),
  KEY `PatNum` (`PatNum`),
  KEY `RxCui` (`RxCui`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
