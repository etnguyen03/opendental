CREATE TABLE `payplantemplate` (
  `PayPlanTemplateNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PayPlanTemplateName` varchar(255) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `APR` double NOT NULL,
  `InterestDelay` int(11) NOT NULL,
  `PayAmt` double NOT NULL,
  `NumberOfPayments` int(11) NOT NULL,
  `ChargeFrequency` tinyint(4) NOT NULL,
  `DownPayment` double NOT NULL,
  `DynamicPayPlanTPOption` tinyint(4) NOT NULL,
  `Note` varchar(255) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  PRIMARY KEY (`PayPlanTemplateNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
