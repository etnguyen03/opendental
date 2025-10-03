CREATE TABLE `usergroupattach` (
  `UserGroupAttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `UserGroupNum` bigint(20) NOT NULL,
  PRIMARY KEY (`UserGroupAttachNum`),
  KEY `UserGroupNum` (`UserGroupNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
