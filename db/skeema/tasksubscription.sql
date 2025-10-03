CREATE TABLE `tasksubscription` (
  `TaskSubscriptionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `TaskListNum` bigint(20) NOT NULL,
  `TaskNum` bigint(20) NOT NULL,
  PRIMARY KEY (`TaskSubscriptionNum`),
  KEY `UserNum` (`UserNum`),
  KEY `TaskNum` (`TaskNum`),
  KEY `TaskListNum` (`TaskListNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
