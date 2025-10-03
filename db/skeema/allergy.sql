CREATE TABLE `allergy` (
  `AllergyNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `AllergyDefNum` bigint(20) NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `Reaction` varchar(255) NOT NULL,
  `StatusIsActive` tinyint(4) NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `DateAdverseReaction` date NOT NULL DEFAULT '0001-01-01',
  `SnomedReaction` varchar(255) NOT NULL,
  PRIMARY KEY (`AllergyNum`),
  KEY `AllergyDefNum` (`AllergyDefNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
