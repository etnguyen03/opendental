CREATE TABLE `eserviceshortguid` (
  `EServiceShortGuidNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EServiceCode` varchar(255) NOT NULL,
  `ShortGuid` varchar(255) NOT NULL,
  `ShortURL` varchar(255) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `FKeyType` varchar(255) NOT NULL,
  `DateTimeExpiration` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`EServiceShortGuidNum`),
  KEY `FKey` (`FKey`),
  KEY `ShortGuid` (`ShortGuid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
