CREATE TABLE `apikey` (
  `APIKeyNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CustApiKey` varchar(255) NOT NULL,
  `DevName` varchar(255) NOT NULL,
  PRIMARY KEY (`APIKeyNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
