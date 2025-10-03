CREATE TABLE `emailhostingtemplate` (
  `EmailHostingTemplateNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `TemplateName` varchar(255) NOT NULL,
  `Subject` text NOT NULL,
  `BodyPlainText` mediumtext NOT NULL,
  `BodyHTML` mediumtext NOT NULL,
  `TemplateId` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `EmailTemplateType` varchar(255) NOT NULL,
  `TemplateType` varchar(255) NOT NULL,
  PRIMARY KEY (`EmailHostingTemplateNum`),
  KEY `TemplateId` (`TemplateId`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
