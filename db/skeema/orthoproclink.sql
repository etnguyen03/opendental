CREATE TABLE `orthoproclink` (
  `OrthoProcLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `OrthoCaseNum` bigint(20) NOT NULL,
  `ProcNum` bigint(20) NOT NULL,
  `SecDateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `SecUserNumEntry` bigint(20) NOT NULL,
  `ProcLinkType` tinyint(4) NOT NULL,
  PRIMARY KEY (`OrthoProcLinkNum`),
  KEY `OrthoCaseNum` (`OrthoCaseNum`),
  KEY `ProcNum` (`ProcNum`),
  KEY `SecUserNumEntry` (`SecUserNumEntry`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
