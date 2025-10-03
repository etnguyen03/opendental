CREATE TABLE `stmtlink` (
  `StmtLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `StatementNum` bigint(20) NOT NULL,
  `StmtLinkType` tinyint(4) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  PRIMARY KEY (`StmtLinkNum`),
  KEY `StatementNum` (`StatementNum`),
  KEY `FKeyAndType` (`StmtLinkType`,`FKey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
