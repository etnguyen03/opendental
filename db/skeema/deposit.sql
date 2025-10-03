CREATE TABLE `deposit` (
  `DepositNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DateDeposit` date NOT NULL DEFAULT '0001-01-01',
  `BankAccountInfo` text DEFAULT NULL,
  `Amount` double NOT NULL DEFAULT 0,
  `Memo` varchar(255) NOT NULL,
  `Batch` varchar(25) NOT NULL,
  `DepositAccountNum` bigint(20) NOT NULL,
  `IsSentToQuickBooksOnline` tinyint(4) NOT NULL,
  PRIMARY KEY (`DepositNum`),
  KEY `DepositAccountNum` (`DepositAccountNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
