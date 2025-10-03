CREATE TABLE `claimattach` (
  `ClaimAttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClaimNum` bigint(20) NOT NULL,
  `DisplayedFileName` varchar(255) DEFAULT NULL,
  `ActualFileName` varchar(255) DEFAULT NULL,
  `ImageReferenceId` int(11) NOT NULL,
  PRIMARY KEY (`ClaimAttachNum`),
  KEY `ClaimNum` (`ClaimNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
