CREATE TABLE `hl7defsegment` (
  `HL7DefSegmentNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `HL7DefMessageNum` bigint(20) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `CanRepeat` tinyint(4) NOT NULL,
  `IsOptional` tinyint(4) NOT NULL,
  `SegmentName` varchar(255) NOT NULL,
  `Note` text NOT NULL,
  PRIMARY KEY (`HL7DefSegmentNum`),
  KEY `HL7DefMessageNum` (`HL7DefMessageNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
