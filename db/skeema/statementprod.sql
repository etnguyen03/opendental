CREATE TABLE `statementprod` (
  `StatementProdNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `StatementNum` bigint(20) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `ProdType` tinyint(4) NOT NULL,
  `LateChargeAdjNum` bigint(20) NOT NULL,
  `DocNum` bigint(20) NOT NULL,
  PRIMARY KEY (`StatementProdNum`),
  KEY `StatementNum` (`StatementNum`),
  KEY `FKey` (`FKey`),
  KEY `ProdType` (`ProdType`),
  KEY `LateChargeAdjNum` (`LateChargeAdjNum`),
  KEY `DocNum` (`DocNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
