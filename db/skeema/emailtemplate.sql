CREATE TABLE `emailtemplate` (
  `EmailTemplateNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Subject` text DEFAULT NULL,
  `BodyText` text DEFAULT NULL,
  `Description` text NOT NULL,
  `TemplateType` tinyint(4) NOT NULL,
  PRIMARY KEY (`EmailTemplateNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
