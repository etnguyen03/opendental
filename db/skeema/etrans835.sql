CREATE TABLE `etrans835` (
  `Etrans835Num` bigint(20) NOT NULL AUTO_INCREMENT,
  `EtransNum` bigint(20) NOT NULL,
  `PayerName` varchar(60) NOT NULL,
  `TransRefNum` varchar(50) NOT NULL,
  `InsPaid` double NOT NULL,
  `ControlId` varchar(9) NOT NULL,
  `PaymentMethodCode` varchar(3) NOT NULL,
  `PatientName` varchar(100) NOT NULL,
  `Status` tinyint(4) NOT NULL,
  `AutoProcessed` tinyint(4) NOT NULL,
  `IsApproved` tinyint(4) NOT NULL,
  PRIMARY KEY (`Etrans835Num`),
  KEY `EtransNum` (`EtransNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
