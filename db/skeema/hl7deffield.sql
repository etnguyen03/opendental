CREATE TABLE `hl7deffield` (
  `HL7DefFieldNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `HL7DefSegmentNum` bigint(20) NOT NULL,
  `OrdinalPos` int(11) NOT NULL,
  `TableId` varchar(255) NOT NULL,
  `DataType` varchar(255) NOT NULL,
  `FieldName` varchar(255) NOT NULL,
  `FixedText` text NOT NULL,
  PRIMARY KEY (`HL7DefFieldNum`),
  KEY `HL7DefSegmentNum` (`HL7DefSegmentNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
