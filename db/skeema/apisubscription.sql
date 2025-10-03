CREATE TABLE `apisubscription` (
  `ApiSubscriptionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EndPointUrl` varchar(255) NOT NULL,
  `Workstation` varchar(255) NOT NULL,
  `CustomerKey` varchar(255) NOT NULL,
  `WatchTable` varchar(255) NOT NULL,
  `PollingSeconds` int(11) NOT NULL,
  `UiEventType` varchar(255) NOT NULL,
  `DateTimeStart` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateTimeStop` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Note` varchar(255) NOT NULL,
  PRIMARY KEY (`ApiSubscriptionNum`),
  KEY `PollingSeconds` (`PollingSeconds`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
