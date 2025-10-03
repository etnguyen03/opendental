CREATE TABLE `taskunread` (
  `TaskUnreadNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `TaskNum` bigint(20) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  PRIMARY KEY (`TaskUnreadNum`),
  KEY `TaskNum` (`TaskNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
