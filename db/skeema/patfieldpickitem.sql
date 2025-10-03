CREATE TABLE `patfieldpickitem` (
  `PatFieldPickItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatFieldDefNum` bigint(20) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Abbreviation` varchar(255) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  PRIMARY KEY (`PatFieldPickItemNum`),
  KEY `PatFieldDefNum` (`PatFieldDefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
