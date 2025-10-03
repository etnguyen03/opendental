CREATE TABLE `taskattachment` (
  `TaskAttachmentNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `TaskNum` bigint(20) NOT NULL,
  `DocNum` bigint(20) NOT NULL,
  `TextValue` text NOT NULL,
  `Description` varchar(255) NOT NULL,
  PRIMARY KEY (`TaskAttachmentNum`),
  KEY `TaskNum` (`TaskNum`),
  KEY `DocNum` (`DocNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
