CREATE TABLE `eclipboardimagecapturedef` (
  `EClipboardImageCaptureDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DefNum` bigint(20) NOT NULL,
  `IsSelfPortrait` tinyint(4) NOT NULL,
  `FrequencyDays` int(11) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `OcrCaptureType` tinyint(4) NOT NULL DEFAULT 0,
  `Frequency` tinyint(4) NOT NULL,
  `ResubmitInterval` bigint(20) NOT NULL,
  PRIMARY KEY (`EClipboardImageCaptureDefNum`),
  KEY `DefNum` (`DefNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `ResubmitInterval` (`ResubmitInterval`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
