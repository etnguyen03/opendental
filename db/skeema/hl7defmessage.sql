CREATE TABLE `hl7defmessage` (
  `HL7DefMessageNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `HL7DefNum` bigint(20) NOT NULL,
  `MessageType` varchar(255) NOT NULL,
  `EventType` varchar(255) NOT NULL,
  `InOrOut` tinyint(4) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `Note` text NOT NULL,
  `MessageStructure` varchar(255) NOT NULL,
  PRIMARY KEY (`HL7DefMessageNum`),
  KEY `HL7DefNum` (`HL7DefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
