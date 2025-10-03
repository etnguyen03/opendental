CREATE TABLE `transactioninvoice` (
  `TransactionInvoiceNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FileName` varchar(255) NOT NULL,
  `InvoiceData` mediumtext DEFAULT NULL,
  `FilePath` varchar(255) NOT NULL,
  PRIMARY KEY (`TransactionInvoiceNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
