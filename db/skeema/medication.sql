CREATE TABLE `medication` (
  `MedicationNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `MedName` varchar(255) DEFAULT '',
  `GenericNum` bigint(20) NOT NULL,
  `Notes` text DEFAULT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `RxCui` bigint(20) NOT NULL,
  PRIMARY KEY (`MedicationNum`),
  KEY `RxCui` (`RxCui`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
