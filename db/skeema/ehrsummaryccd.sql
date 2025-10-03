CREATE TABLE `ehrsummaryccd` (
  `EhrSummaryCcdNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `DateSummary` date NOT NULL DEFAULT '0001-01-01',
  `ContentSummary` longtext NOT NULL,
  `EmailAttachNum` bigint(20) NOT NULL,
  PRIMARY KEY (`EhrSummaryCcdNum`),
  KEY `PatNum` (`PatNum`),
  KEY `EmailAttachNum` (`EmailAttachNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
