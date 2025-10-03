CREATE TABLE `etrans835attach` (
  `Etrans835AttachNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EtransNum` bigint(20) NOT NULL,
  `ClaimNum` bigint(20) NOT NULL,
  `ClpSegmentIndex` int(11) NOT NULL,
  `DateTimeEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`Etrans835AttachNum`),
  KEY `EtransNum` (`EtransNum`),
  KEY `ClaimNum` (`ClaimNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
