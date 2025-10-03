CREATE TABLE `emailmessageuid` (
  `EmailMessageUidNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `MsgId` text DEFAULT NULL,
  `RecipientAddress` varchar(255) NOT NULL,
  PRIMARY KEY (`EmailMessageUidNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
