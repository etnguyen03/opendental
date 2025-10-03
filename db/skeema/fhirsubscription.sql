CREATE TABLE `fhirsubscription` (
  `FHIRSubscriptionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Criteria` varchar(255) NOT NULL,
  `Reason` varchar(255) NOT NULL,
  `SubStatus` tinyint(4) NOT NULL,
  `ErrorNote` text NOT NULL,
  `ChannelType` tinyint(4) NOT NULL,
  `ChannelEndpoint` varchar(255) NOT NULL,
  `ChannelPayLoad` varchar(255) NOT NULL,
  `ChannelHeader` varchar(255) NOT NULL,
  `DateEnd` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `APIKeyHash` varchar(255) NOT NULL,
  PRIMARY KEY (`FHIRSubscriptionNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
