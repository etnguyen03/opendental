CREATE TABLE `hl7msg` (
  `HL7MsgNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `HL7Status` int(11) NOT NULL,
  `MsgText` mediumtext DEFAULT NULL,
  `AptNum` bigint(20) NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `PatNum` bigint(20) NOT NULL,
  `Note` text NOT NULL,
  PRIMARY KEY (`HL7MsgNum`),
  KEY `AptNum` (`AptNum`),
  KEY `HL7Status` (`HL7Status`),
  KEY `DateTStamp` (`DateTStamp`),
  KEY `PatNum` (`PatNum`),
  KEY `MsgText` (`MsgText`(100))
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
