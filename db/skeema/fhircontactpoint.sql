CREATE TABLE `fhircontactpoint` (
  `FHIRContactPointNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FHIRSubscriptionNum` bigint(20) NOT NULL,
  `ContactSystem` tinyint(4) NOT NULL,
  `ContactValue` varchar(255) NOT NULL,
  `ContactUse` tinyint(4) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `DateStart` date NOT NULL DEFAULT '0001-01-01',
  `DateEnd` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`FHIRContactPointNum`),
  KEY `FHIRSubscriptionNum` (`FHIRSubscriptionNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
