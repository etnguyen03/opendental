CREATE TABLE `requiredfieldcondition` (
  `RequiredFieldConditionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `RequiredFieldNum` bigint(20) NOT NULL,
  `ConditionType` varchar(50) NOT NULL,
  `Operator` tinyint(4) NOT NULL,
  `ConditionValue` varchar(255) NOT NULL,
  `ConditionRelationship` tinyint(4) NOT NULL,
  PRIMARY KEY (`RequiredFieldConditionNum`),
  KEY `RequiredFieldNum` (`RequiredFieldNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
