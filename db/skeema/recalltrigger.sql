CREATE TABLE `recalltrigger` (
  `RecallTriggerNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `RecallTypeNum` bigint(20) NOT NULL,
  `CodeNum` bigint(20) NOT NULL,
  PRIMARY KEY (`RecallTriggerNum`),
  KEY `CodeNum` (`CodeNum`),
  KEY `RecallTypeNum` (`RecallTypeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
