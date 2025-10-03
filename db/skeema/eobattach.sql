CREATE TABLE `eobattach` (
  `EobAttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClaimPaymentNum` bigint(20) NOT NULL,
  `DateTCreated` datetime NOT NULL,
  `FileName` varchar(255) NOT NULL,
  `RawBase64` text NOT NULL,
  PRIMARY KEY (`EobAttachNum`),
  KEY `ClaimPaymentNum` (`ClaimPaymentNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
