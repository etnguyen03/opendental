CREATE TABLE `ehrcareplan` (
  `EhrCarePlanNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `SnomedEducation` varchar(255) NOT NULL,
  `Instructions` varchar(255) NOT NULL,
  `DatePlanned` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`EhrCarePlanNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
