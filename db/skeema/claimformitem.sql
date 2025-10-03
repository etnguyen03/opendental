CREATE TABLE `claimformitem` (
  `ClaimFormItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClaimFormNum` bigint(20) NOT NULL,
  `ImageFileName` varchar(255) DEFAULT '',
  `FieldName` varchar(255) DEFAULT '',
  `FormatString` varchar(255) DEFAULT '',
  `XPos` float NOT NULL DEFAULT 0,
  `YPos` float NOT NULL DEFAULT 0,
  `Width` float NOT NULL DEFAULT 0,
  `Height` float NOT NULL DEFAULT 0,
  PRIMARY KEY (`ClaimFormItemNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
