CREATE TABLE `transaction` (
  `TransactionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DateTimeEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `UserNum` bigint(20) NOT NULL,
  `DepositNum` bigint(20) NOT NULL,
  `PayNum` bigint(20) NOT NULL,
  `SecUserNumEdit` bigint(20) NOT NULL,
  `SecDateTEdit` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `TransactionInvoiceNum` bigint(20) NOT NULL,
  PRIMARY KEY (`TransactionNum`),
  KEY `SecUserNumEdit` (`SecUserNumEdit`),
  KEY `TransactionInvoiceNum` (`TransactionInvoiceNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
