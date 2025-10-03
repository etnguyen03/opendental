CREATE TABLE `procmultivisit` (
  `ProcMultiVisitNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `GroupProcMultiVisitNum` bigint(20) NOT NULL,
  `ProcNum` bigint(20) NOT NULL,
  `ProcStatus` tinyint(4) NOT NULL,
  `IsInProcess` tinyint(4) NOT NULL,
  `SecDateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `SecDateTEdit` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `PatNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ProcMultiVisitNum`),
  KEY `GroupProcMultiVisitNum` (`GroupProcMultiVisitNum`),
  KEY `ProcNum` (`ProcNum`),
  KEY `IsInProcess` (`IsInProcess`),
  KEY `SecDateTEntry` (`SecDateTEntry`),
  KEY `SecDateTEdit` (`SecDateTEdit`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
