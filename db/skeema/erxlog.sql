CREATE TABLE `erxlog` (
  `ErxLogNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `MsgText` mediumtext NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `ProvNum` bigint(20) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ErxLogNum`),
  KEY `PatNum` (`PatNum`),
  KEY `ProvNum` (`ProvNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
