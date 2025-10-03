CREATE TABLE `claimsnapshot` (
  `ClaimSnapshotNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProcNum` bigint(20) NOT NULL,
  `ClaimType` varchar(255) NOT NULL,
  `Writeoff` double NOT NULL,
  `InsPayEst` double NOT NULL,
  `Fee` double NOT NULL,
  `DateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `ClaimProcNum` bigint(20) NOT NULL,
  `SnapshotTrigger` tinyint(4) NOT NULL,
  PRIMARY KEY (`ClaimSnapshotNum`),
  KEY `ProcNum` (`ProcNum`),
  KEY `ClaimProcNum` (`ClaimProcNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
