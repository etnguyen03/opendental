CREATE TABLE `emailsecureattach` (
  `EmailSecureAttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `EmailAttachNum` bigint(20) NOT NULL,
  `EmailSecureNum` bigint(20) NOT NULL,
  `AttachmentGuid` varchar(50) NOT NULL,
  `DisplayedFileName` varchar(255) NOT NULL,
  `Extension` varchar(255) NOT NULL,
  `DateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `SecDateTEdit` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`EmailSecureAttachNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `EmailAttachNum` (`EmailAttachNum`),
  KEY `EmailSecureNum` (`EmailSecureNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
