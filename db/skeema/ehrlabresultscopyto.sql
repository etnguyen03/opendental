CREATE TABLE `ehrlabresultscopyto` (
  `EhrLabResultsCopyToNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EhrLabNum` bigint(20) NOT NULL,
  `CopyToID` varchar(255) NOT NULL,
  `CopyToLName` varchar(255) NOT NULL,
  `CopyToFName` varchar(255) NOT NULL,
  `CopyToMiddleNames` varchar(255) NOT NULL,
  `CopyToSuffix` varchar(255) NOT NULL,
  `CopyToPrefix` varchar(255) NOT NULL,
  `CopyToAssigningAuthorityNamespaceID` varchar(255) NOT NULL,
  `CopyToAssigningAuthorityUniversalID` varchar(255) NOT NULL,
  `CopyToAssigningAuthorityIDType` varchar(255) NOT NULL,
  `CopyToNameTypeCode` varchar(255) NOT NULL,
  `CopyToIdentifierTypeCode` varchar(255) NOT NULL,
  PRIMARY KEY (`EhrLabResultsCopyToNum`),
  KEY `EhrLabNum` (`EhrLabNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
