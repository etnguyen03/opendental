CREATE TABLE `emailattach` (
  `EmailAttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EmailMessageNum` bigint(20) NOT NULL,
  `DisplayedFileName` varchar(255) DEFAULT '',
  `ActualFileName` varchar(255) DEFAULT '',
  `EmailTemplateNum` bigint(20) NOT NULL,
  PRIMARY KEY (`EmailAttachNum`),
  KEY `EmailMessageNum` (`EmailMessageNum`),
  KEY `EmailTemplateNum` (`EmailTemplateNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
