CREATE TABLE `procgroupitem` (
  `ProcGroupItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProcNum` bigint(20) NOT NULL,
  `GroupNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ProcGroupItemNum`),
  KEY `ProcNum` (`ProcNum`),
  KEY `GroupNum` (`GroupNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
