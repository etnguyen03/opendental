CREATE TABLE `inssub` (
  `InsSubNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PlanNum` bigint(20) NOT NULL,
  `Subscriber` bigint(20) NOT NULL,
  `DateEffective` date NOT NULL DEFAULT '0001-01-01',
  `DateTerm` date NOT NULL DEFAULT '0001-01-01',
  `ReleaseInfo` tinyint(4) NOT NULL,
  `AssignBen` tinyint(4) NOT NULL,
  `SubscriberID` varchar(255) NOT NULL,
  `BenefitNotes` text NOT NULL,
  `SubscNote` text NOT NULL,
  `SecUserNumEntry` bigint(20) NOT NULL,
  `SecDateEntry` date NOT NULL DEFAULT '0001-01-01',
  `SecDateTEdit` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`InsSubNum`),
  KEY `PlanNum` (`PlanNum`),
  KEY `Subscriber` (`Subscriber`),
  KEY `SecUserNumEntry` (`SecUserNumEntry`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
