CREATE TABLE `emailaddress` (
  `EmailAddressNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SMTPserver` varchar(255) NOT NULL,
  `EmailUsername` varchar(255) NOT NULL,
  `EmailPassword` varchar(255) NOT NULL,
  `ServerPort` int(11) NOT NULL,
  `UseSSL` tinyint(4) NOT NULL,
  `SenderAddress` varchar(255) NOT NULL,
  `Pop3ServerIncoming` varchar(255) NOT NULL,
  `ServerPortIncoming` int(11) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  `AccessToken` varchar(2000) NOT NULL,
  `RefreshToken` text NOT NULL,
  `DownloadInbox` tinyint(4) NOT NULL,
  `QueryString` varchar(1000) NOT NULL,
  `AuthenticationType` tinyint(4) NOT NULL,
  PRIMARY KEY (`EmailAddressNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
