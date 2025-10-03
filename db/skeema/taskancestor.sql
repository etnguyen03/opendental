CREATE TABLE `taskancestor` (
  `TaskAncestorNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `TaskNum` bigint(20) NOT NULL,
  `TaskListNum` bigint(20) NOT NULL,
  PRIMARY KEY (`TaskAncestorNum`),
  KEY `TaskNum` (`TaskNum`),
  KEY `TaskListCov` (`TaskListNum`,`TaskNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
