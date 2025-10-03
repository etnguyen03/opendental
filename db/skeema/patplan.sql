CREATE TABLE `patplan` (
  `PatPlanNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `Ordinal` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `IsPending` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `Relationship` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `PatID` varchar(100) DEFAULT '',
  `InsSubNum` bigint(20) NOT NULL,
  `OrthoAutoFeeBilledOverride` double NOT NULL DEFAULT -1,
  `OrthoAutoNextClaimDate` date NOT NULL DEFAULT '0001-01-01',
  `SecDateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `SecDateTEdit` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`PatPlanNum`),
  KEY `indexPatNum` (`PatNum`),
  KEY `InsSubNum` (`InsSubNum`),
  KEY `SecDateTEdit` (`SecDateTEdit`),
  KEY `SecDateTEntry` (`SecDateTEntry`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
