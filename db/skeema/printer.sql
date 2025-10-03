CREATE TABLE `printer` (
  `PrinterNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ComputerNum` bigint(20) NOT NULL,
  `PrintSit` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `PrinterName` varchar(255) DEFAULT '',
  `DisplayPrompt` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `FileExtension` varchar(255) NOT NULL,
  `IsVirtualPrinter` tinyint(4) NOT NULL,
  PRIMARY KEY (`PrinterNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
