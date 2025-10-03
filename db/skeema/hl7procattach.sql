CREATE TABLE `hl7procattach` (
  `HL7ProcAttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `HL7MsgNum` bigint(20) NOT NULL,
  `ProcNum` bigint(20) NOT NULL,
  PRIMARY KEY (`HL7ProcAttachNum`),
  KEY `HL7MsgNum` (`HL7MsgNum`),
  KEY `ProcNum` (`ProcNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
