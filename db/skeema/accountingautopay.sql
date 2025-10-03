CREATE TABLE `accountingautopay` (
  `AccountingAutoPayNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PayType` bigint(20) NOT NULL,
  `PickList` varchar(255) DEFAULT '',
  PRIMARY KEY (`AccountingAutoPayNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
